using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketDebugger.Data;

namespace WebSocketDebugger
{
    public partial class FrmHeaders : Form
    {
        private static SystemSound Beep => SystemSounds.Beep;
        private static Dictionary<string, string> Headers => Utils.GlobalConfig.Headers;
        public FrmHeaders()
        {
            InitializeComponent();
        }

        private void Frmheaders_Load(object sender, EventArgs e)
        {
            foreach (var a in Headers)
            {
                ListViewItem item = new(a.Key);
                item.SubItems.Add(a.Value);

                lvHeaders.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string value = txtValue.Text;

            if (string.IsNullOrEmpty(name))
            {
                Beep.Play();
                txtName.Focus();
            }

            if (Headers.ContainsKey(name))
            {
                Headers[name] = value;

                foreach (ListViewItem item in lvHeaders.Items)
                {
                    if (item.Text == name)
                    {
                        item.SubItems[1].Text = value;
                    }
                }

            }
            else
            {
                Headers.Add(name, value);

                ListViewItem item = new(name);
                item.SubItems.Add(value);

                lvHeaders.Items.Add(item);
            }
        }

        private void MenuAll_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvHeaders, SelectMode.All);
        }

        private void MenuNot_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvHeaders, SelectMode.Not);

        }

        private void MenuNone_Click(object sender, EventArgs e)
        {
            Utils.ListViewMuliSelect(lvHeaders, SelectMode.None);
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvHeaders.SelectedItems)
            {
                string name = item.Text;
                if (Headers.ContainsKey(name))
                {
                    Headers.Remove(name);
                }

                lvHeaders.Items.Remove(item);
            }
        }

        private void MenuHeaders_Opening(object sender, CancelEventArgs e)
        {
            int count = lvHeaders.SelectedItems.Count;

            if (count == 0)
            {
                menuEdit.Enabled = false;
                menuDelete.Enabled = false;
            }
            else if (count == 1)
            {
                menuEdit.Enabled = true;
                menuDelete.Enabled = true;
            }
            else
            {
                menuEdit.Enabled = false;
                menuDelete.Enabled = true;
            }
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = lvHeaders.SelectedItems;
            if (items.Count > 0)
            {
                ListViewItem item = items[0];

                string name = item.Text;
                string value = item.SubItems[1].Text;

                txtName.Text = name;
                txtValue.Text = value;
            }
        }
    }
}
