using System.Media;
using System.Text.Json;

namespace WebSocketDebugger
{
    public partial class FrmDetail : Form
    {
        private static SystemSound Beep => SystemSounds.Beep;

        public FrmDetail(string message)
        {
            InitializeComponent();
            txtMessage.Text = message;
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
