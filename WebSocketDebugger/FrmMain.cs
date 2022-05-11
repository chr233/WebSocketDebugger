using System.Runtime.InteropServices;
using WebSocketSharp;
using System.Text.Json.Serialization;

using WebSocketDebugger.Data;
using System.Text.Json;
using System.Media;

namespace WebSocketDebugger
{
    public partial class FrmMain : Form
    {
        private static Properties.Config Config => Properties.Config.Default;
        private static SystemSound Beep => SystemSounds.Beep;
        private Dictionary<string, TemplateData> Templates { get; }
        private WebSocket? Ws { get; set; } = null;

        private const string SEND = "-->";
        private const string RECV = "<--";
        private const string CONN = "-○-";
        private const string DISC = "-×-";


        public FrmMain()
        {
            InitializeComponent();

            try
            {
                string templates = Config.TemplatesJson;

                List<TemplateData> temps = JsonSerializer.Deserialize<List<TemplateData>>(templates) ?? new();

                Templates = new();

                foreach (TemplateData temp in temps)
                {
                    Templates.Add(temp.Name, temp);
                }
            }
            catch
            {
                Templates = new();
                Config.TemplatesJson = "{}";
                Config.Save();
            }

            Version version = typeof(Program).Assembly.GetName().Version ?? throw new ArgumentNullException(nameof(Version));

            Text = $"WebSocket 调试工具 {version.Major}.{version.Minor}.{version.Build}.{version.Revision} - By Chr_ - 2022";
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (Config.FormMaximised)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (Config.FormMinimised)
            {
                WindowState = FormWindowState.Minimized;
            }
            Size = Config.FormSize;

            txtWebSocketUri.Text = Config.WebSocketUri;
            chkKeepMessage.Checked = Config.FormKeepMessage;

            lvTemplates.BeginUpdate();

            foreach (TemplateData template in Templates.Values)
            {
                ListViewItem item = new(template.Name);
                item.SubItems.Add(template.Message);
                lvTemplates.Items.Add(item);
            }

            lvTemplates.EndUpdate();
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.FormMaximised = false;
            Config.FormMinimised = false;

            if (WindowState == FormWindowState.Maximized)
            {
                Config.FormSize = RestoreBounds.Size;
                Config.FormMaximised = true;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                Config.FormSize = RestoreBounds.Size;
                Config.FormMinimised = true;
            }
            else
            {
                Config.FormSize = Size;
            }

            Config.WebSocketUri = txtWebSocketUri.Text;
            Config.FormKeepMessage = chkKeepMessage.Checked;

            string tempJson = JsonSerializer.Serialize(Templates.Values.ToList());
            Config.TemplatesJson = tempJson;

            Config.Save();
        }

        private void StartWs()
        {
            if (Ws == null)
            {
                string url = txtWebSocketUri.Text;
                try
                {
                    Ws = new WebSocket(url);
                    Ws.OnClose += (sender, e) =>
                    {
                        Beep.Play();
                        Invoke(() =>
                        {
                            lblStatus.Text = "已断开";
                            AddLog("断开连接", false);
                            CloseWs();
                        });
                    };
                    Ws.OnError += (sender, e) =>
                    {
                        Beep.Play();
                        Invoke(() =>
                        {
                            lblStatus.Text = "连接出错";
                            AddLog("连接出错, 断开连接", false);
                            CloseWs();
                        });
                    };
                    Ws.OnOpen += (sender, e) =>
                    {
                        Invoke(() =>
                        {
                            lblStatus.Text = "连接成功";
                            btnWsControl.Text = "&C. 断开连接";
                            txtWebSocketUri.ReadOnly = true;
                            AddLog("连接成功", true);
                        });
                    };
                    Ws.OnMessage += (sender, e) =>
                    {
                        Invoke(() => AddHistory(e.Data.ToLower(), false));
                    };

                    Ws.WaitTime = TimeSpan.FromSeconds(5);

                    Ws.Connect();

                    Ws.WaitTime = TimeSpan.FromSeconds(5000);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"WebScoket连接失败\n{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloseWs()
        {
            if (Ws != null)
            {
                Ws.Close();
            }

            Ws = null;
            btnWsControl.Text = "&C. 打开连接";
            txtWebSocketUri.ReadOnly = false;
        }

        private void AddLog(string message, bool conn)
        {
            ListViewItem item = new((lvHistory.Items.Count + 1).ToString());
            item.SubItems.Add(DateTime.Now.ToString());
            item.SubItems.Add(conn ? CONN : DISC);
            item.SubItems.Add(message);
            lvHistory.Items.Add(item);
            item.EnsureVisible();
        }

        private void AddHistory(string message, bool send)
        {
            ListViewItem item = new((lvHistory.Items.Count + 1).ToString());
            item.SubItems.Add(DateTime.Now.ToString());
            item.SubItems.Add(send ? SEND : RECV);
            item.SubItems.Add(message);
            lvHistory.Items.Add(item);
            item.EnsureVisible();
        }

        private void BtnWsControl_Click(object sender, EventArgs e)
        {
            Action action = Ws == null ? StartWs : CloseWs;
            Invoke(action);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (Ws != null)
            {
                string data = txtMessage.Text;

                if (string.IsNullOrEmpty(data))
                {
                    Beep.Play();
                    txtMessage.Focus();
                    return;
                }

                try
                {
                    Ws.Send(data);

                    AddHistory(data, true);

                    if (!chkKeepMessage.Checked)
                    {
                        txtMessage.Text = "";
                    }
                }
                catch
                {
                }
            }
            else
            {
                Beep.Play();
                txtWebSocketUri.Focus();
            }
        }

        private void BtnSaveTemp_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            if (string.IsNullOrEmpty(name))
            {
                Beep.Play();
                txtName.Focus();
                return;
            }

            string message = txtMessage.Text;

            if (string.IsNullOrEmpty(message))
            {
                Beep.Play();
                txtMessage.Focus();
                return;
            }

            if (!Templates.ContainsKey(name))
            {
                Templates.Add(name, new()
                {
                    Name = name,
                    Message = message,
                });

                ListViewItem item = new(name);
                item.SubItems.Add(message);
                item.Selected = true;
                lvTemplates.Items.Add(item);
            }
            else
            {
                Templates[name].Message = message;

                foreach (ListViewItem item in lvTemplates.Items)
                {
                    if (item.Text == name)
                    {
                        item.SubItems[1].Text = message;
                        item.Selected = true;
                        break;
                    }
                }


            }


        }

        private void BtnJsonCompress_Click(object sender, EventArgs e)
        {
            try
            {
                string message = txtMessage.Text;

                object obj = JsonSerializer.Deserialize<object>(message) ?? throw new Exception();
                string result = JsonSerializer.Serialize(obj);

                txtMessage.Text = result;
            }
            catch
            {
                Beep.Play();
                txtMessage.Focus();
            }
        }

        private void BtnJsonFormat_Click(object sender, EventArgs e)
        {
            try
            {
                string message = txtMessage.Text;

                object obj = JsonSerializer.Deserialize<object>(message) ?? throw new Exception();
                string result = JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true });

                txtMessage.Text = result;
            }
            catch
            {
                Beep.Play();
                txtMessage.Focus();
            }
        }

        private void MenuUseTemp_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = lvTemplates.SelectedItems;
            if (items.Count > 0)
            {
                ListViewItem item = items[0];

                string name = item.Text;
                string message = item.SubItems[1].Text;

                txtName.Text = name;
                txtMessage.Text = message;
            }
        }

        private void MenuDeleteTemp_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = lvTemplates.SelectedItems;

            lvTemplates.BeginUpdate();

            if (items.Count > 0)
            {
                foreach (ListViewItem item in items)
                {
                    string name = item.Text;

                    if (Templates.ContainsKey(name))
                    {
                        Templates.Remove(name);
                    }

                    lvTemplates.Items.Remove(item);
                }
            }

            lvTemplates.EndUpdate();
        }

        private void MenuDetail_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = lvHistory.SelectedItems;
            if (items.Count > 0)
            {
                foreach (ListViewItem item in items)
                {
                    string content = item.SubItems[3].Text;

                    bool send = item.SubItems[2].Text == SEND;

                    FrmDetail frmDetail = new(content, send);

                    frmDetail.Show();
                }
            }
        }

        private void MenuClear_Click(object sender, EventArgs e)
        {
            lvHistory.Clear();
        }

        private static void ListViewMuliSelect(ListView lv, SelectMode mode)
        {
            lv.BeginUpdate();

            bool flag = mode == SelectMode.All;

            foreach (ListViewItem item in lv.Items)
            {
                if (mode == SelectMode.Not)
                {
                    item.Selected = !item.Selected;
                }
                else
                {
                    item.Selected = flag;
                }
            }

            lv.EndUpdate();
        }

        private void MenuAll_Click(object sender, EventArgs e)
        {
            ListViewMuliSelect(lvTemplates, SelectMode.All);
        }

        private void MenuNot_Click(object sender, EventArgs e)
        {
            ListViewMuliSelect(lvTemplates, SelectMode.Not);
        }

        private void MenuNone_Click(object sender, EventArgs e)
        {
            ListViewMuliSelect(lvTemplates, SelectMode.None);
        }

        private void MenuAll2_Click(object sender, EventArgs e)
        {
            ListViewMuliSelect(lvHistory, SelectMode.All);
        }

        private void MenuNot2_Click(object sender, EventArgs e)
        {
            ListViewMuliSelect(lvHistory, SelectMode.Not);
        }

        private void MenuNone2_Click(object sender, EventArgs e)
        {
            ListViewMuliSelect(lvHistory, SelectMode.None);
        }

        private void MenuTemp_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int count = lvTemplates.SelectedItems.Count;
            if (count == 0)
            {
                menuUseTemp.Enabled = false;
                menuDeleteTemp.Enabled = false;
            }
            else if (count == 1)
            {
                menuUseTemp.Enabled = true;
                menuDeleteTemp.Enabled = true;
            }
            else
            {
                menuUseTemp.Enabled = false;
                menuDeleteTemp.Enabled = true;
            }
        }

        private void MenuHistory_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int count = lvHistory.SelectedItems.Count;
            if (count == 0)
            {
                menuClear.Enabled = false;
                menuDetail.Enabled = false;
            }
            else
            {
                menuClear.Enabled = true;
                menuDetail.Enabled = true;
            }
        }
    }
}