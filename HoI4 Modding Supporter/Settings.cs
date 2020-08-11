using System;
using System.IO;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.hoi4dir;
            textBox2.Text = Properties.Settings.Default.moddir;
            checkBox1.Checked = Properties.Settings.Default.afterOpenFolder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() { FileName = "Folder", Filter = "フォルダー|.", CheckFileExists = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() { FileName = "Folder", Filter = "フォルダー|.", CheckFileExists = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("ディレクトリが選択されていません。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ここで設定を保存
                Properties.Settings.Default.hoi4dir = textBox1.Text;
                Properties.Settings.Default.moddir = textBox2.Text;
                Properties.Settings.Default.afterOpenFolder = checkBox1.Checked;

                Properties.Settings.Default.Save();

                this.Close();
            }
        }
    }
}
