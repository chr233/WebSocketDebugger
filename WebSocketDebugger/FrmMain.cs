using System.Media;
using System.Text.Json;
using WebSocketDebugger.Data;
using WebSocketSharp;
using WebSocketDebugger.Storage;

namespace WebSocketDebugger
{
    public partial class FrmMain : Form
    {
        private static Config MyConfig => Utils.GlobalConfig;
        private static SystemSound Beep => SystemSounds.Beep;
        private Dictionary<string, TemplateData> Templates { get; } = new();
        private WebSocket? Ws { get; set; } = null;

        private const string SEND = "-->";
        private const string RECV = "<--";
        private const string CONN = "-○-";
        private const string DISC = "-×-";


        public FrmMain()
        {
            InitializeComponent();

            Version version = typeof(Program).Assembly.GetName().Version ?? throw new ArgumentNullException(nameof(Version));

            Text = $"WebSocket 调试工具 {version.Major}.{version.Minor}.{version.Build}.{version.Revision} - By Chr_ - 2022";
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Utils.LoadConfig();

            if (MyConfig.FormMaximised)
            {
                WindowState = FormWindowState.Maximized;
            }
            Size = new Size(MyConfig.FormWidth, MyConfig.FormHeight);

            txtWebSocketUri.Text = MyConfig.WebSocketUri;
            chkKeepMessage.Checked = MyConfig.KeepMessage;

            int count = MyConfig.Headers.Count;
            btnHeaders.Text = count > 0 ? $"&H. 请求头 [{count}]" : "&H. 请求头";

            foreach (TemplateData temp in MyConfig.Templates)
            {
                Templates.Add(temp.Name, temp);
            }

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
            MyConfig.FormMaximised = false;

            Size size;

            if (WindowState != FormWindowState.Normal)
            {
                size = RestoreBounds.Size;
                MyConfig.FormMaximised = WindowState == FormWindowState.Maximized;
            }
            else
            {
                size = Size;
            }

            MyConfig.FormHeight = size.Height;
            MyConfig.FormWidth = size.Width;

            MyConfig.WebSocketUri = txtWebSocketUri.Text;
            MyConfig.KeepMessage = chkKeepMessage.Checked;

            MyConfig.Templates = Templates.Values.ToHashSet();

            Utils.SaveConfig();
        }

        private void StartWs()
        {
            if (Ws == null)
            {
                string url = txtWebSocketUri.Text;
                try
                {
                    Ws = new WebSocket(url);
                    Ws.CustomHeaders = MyConfig.Headers;
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
                        Ws.WaitTime = TimeSpan.FromMinutes(5);
                        Invoke(() =>
                        {
                            lblStatus.Text = "连接成功";
                            btnWsControl.Text = "&C. 断开连接";
                            btnHeaders.Enabled = false;
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"WebScoket连接失败\n{ex.Message}", "错�??", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnHeaders.Enabled = true;
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

        private void BtnHeaders_Click(object sender, EventArgs e)
        {
            FrmHeaders frmHeaders = new();
            frmHeaders.ShowDialog();
            frmHeaders.Dispose();

            int count = MyConfig.Headers.Count;
            btnHeaders.Text = count > 0 ? $"&H. 请求头 [{count}]" : "&H. 请求头";
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
                    // 错误处理由Ws完成
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
                JsonSerializerOptions option = new()
                {
                    WriteIndented = true
                };
                string result = JsonSerializer.Serialize(obj, option);

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

                    FrmDetail frmDetail = new(content);

                    frmDetail.Show();
                }
            }
        }

        private void MenuClear_Click(object sender, EventArgs e)
        {
            lvHistory.Items.Clear();
        }

        private void MenuAll_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvTemplates, SelectMode.All);
        }

        private void MenuNot_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvTemplates, SelectMode.Not);
        }

        private void MenuNone_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvTemplates, SelectMode.None);
        }

        private void MenuAll2_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvHistory, SelectMode.All);
        }

        private void MenuNot2_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvHistory, SelectMode.Not);
        }

        private void MenuNone2_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvHistory, SelectMode.None);
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
