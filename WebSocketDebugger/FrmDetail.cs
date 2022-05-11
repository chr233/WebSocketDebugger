using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketDebugger
{
    public partial class FrmDetail : Form
    {
        private static SystemSound Beep => SystemSounds.Beep;

        public FrmDetail(string message, bool send)
        {
            InitializeComponent();
            txtMessage.Text = message;
            Text = "消息详情 ";
            Text += send ? "-> 发送" : "<- 接收";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMessage.Text);
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
    }
}
