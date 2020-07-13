using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
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
                this.Close();
            }
        }
    }
}
