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
            checkBox2.Checked = Properties.Settings.Default.neutralityDisabled;
            checkBox3.Checked = Properties.Settings.Default.democraticDisabled;
            checkBox4.Checked = Properties.Settings.Default.fascismDisabled;
            checkBox5.Checked = Properties.Settings.Default.communismDisabled;
        }

        /// <summary>
        /// 設定を保存
        /// </summary>
        public void SaveSettings()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                ErrorMessage("ディレクトリが選択されていません。");
                return;
            }

            // HoI4本体ディレクトリが本当に合っているか（commonディレクトリとgfxディレクトリとhoi4.exeの存在確認）
            if (Directory.Exists(textBox1.Text + @"\common") == true && Directory.Exists(textBox1.Text + @"\gfx") == true && File.Exists(textBox1.Text + @"\hoi4.exe") == true)
            {
                Properties.Settings.Default.hoi4dir = textBox1.Text;
                Properties.Settings.Default.moddir = textBox2.Text;
                Properties.Settings.Default.afterOpenFolder = checkBox1.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                ErrorMessage("HoI4本体のディレクトリが間違っています。正しいディレクトリを選択してください。");
                return;
            }

            if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                ErrorMessage("デフォルトイデオロギーをすべて無効化するには、一つ以上カスタムイデオロギーを追加してください。");
                return;
            }
            else
            {

                Properties.Settings.Default.neutralityDisabled = checkBox2.Checked;
                Properties.Settings.Default.democraticDisabled = checkBox3.Checked;
                Properties.Settings.Default.fascismDisabled = checkBox4.Checked;
                Properties.Settings.Default.communismDisabled = checkBox5.Checked;

                Properties.Settings.Default.Save();
            }

            this.Close();
        }

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SaveSettings();
        }
    }
}
