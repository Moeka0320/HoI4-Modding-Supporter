using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            checkBox6.Checked = Properties.Settings.Default.customIdeologiesEnabled;

            if (Properties.Settings.Default.customIdeologiesInternalName.Contains("temp") == false && Properties.Settings.Default.customIdeologiesName.Contains("temp") == false)
            {
                string[] internalNames = Properties.Settings.Default.customIdeologiesInternalName.Cast<string>().ToArray();
                string[] names = Properties.Settings.Default.customIdeologiesName.Cast<string>().ToArray();

                // 再度確認
                if (internalNames.Length == names.Length)
                {
                    listBox1.Items.Clear();

                    // lengthはどちらでもOK
                    for (int cnt = 0; cnt <= internalNames.Length; cnt++)
                    {
                        if (internalNames[cnt] == null || names[cnt] == null)
                        {
                            break;
                        }

                        listBox1.Items.Add(names[cnt] + " (" + internalNames[cnt] + ")");
                    }
                }
            }

            CheckboxChanged();
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
                if (checkBox6.Checked == false)
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
            }
            else
            {

                Properties.Settings.Default.neutralityDisabled = checkBox2.Checked;
                Properties.Settings.Default.democraticDisabled = checkBox3.Checked;
                Properties.Settings.Default.fascismDisabled = checkBox4.Checked;
                Properties.Settings.Default.communismDisabled = checkBox5.Checked;
                Properties.Settings.Default.Save();
            }

            if (checkBox6.Checked == false)
            {
                Properties.Settings.Default.customIdeologiesEnabled = false;
                Properties.Settings.Default.customIdeologiesInternalName.Clear();
                Properties.Settings.Default.customIdeologiesInternalName.Add("temp");
                Properties.Settings.Default.customIdeologiesName.Clear();
                Properties.Settings.Default.customIdeologiesName.Add("temp");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.customIdeologiesEnabled = true;

                if (listBox1.Items.Count != 0)
                {
                    // 一度設定を初期化する
                    Properties.Settings.Default.customIdeologiesInternalName.Clear();
                    Properties.Settings.Default.customIdeologiesName.Clear();

                    string[] list = listBox1.Items.Cast<string>().ToArray();
                    string[] names = new string[listBox1.Items.Count + 1];
                    string[] internalNames = new string[listBox1.Items.Count + 1];

                    for (int cnt = 0; cnt < listBox1.Items.Count; cnt++)
                    {
                        names[cnt] = list[cnt].Substring(0, list[cnt].IndexOf(" ("));
                        internalNames[cnt] = list[cnt].Substring(list[cnt].IndexOf(" (") + 2).TrimEnd(')');
                    }

                    Properties.Settings.Default.customIdeologiesInternalName.AddRange(internalNames);
                    Properties.Settings.Default.customIdeologiesName.AddRange(names);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    ErrorMessage("カスタムイデオロギーの追加が有効化されている場合、カスタムイデオロギーリストを空にすることはできません。");
                    return;
                }
            }


            this.Close();
        }

        /// <summary>
        /// チェックボックス変更時の処理
        /// </summary>
        public void CheckboxChanged()
        {
            if (checkBox6.Checked == true)
            {
                listBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                listBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox3.Text) && 
                !string.IsNullOrWhiteSpace(textBox4.Text) && 
                listBox1.Items.IndexOf(textBox4.Text + " (" + textBox3.Text + ")") == -1 &&
                textBox3.Text != "neutrality" &&
                textBox3.Text != "democratic" &&
                textBox3.Text != "fascism" &&
                textBox3.Text != "communism" &&
                textBox3.Text.IndexOf(" ") == -1 && textBox3.Text.IndexOf("(") == -1 && textBox3.Text.IndexOf(")") == -1 &&
                textBox4.Text.IndexOf(" ") == -1 && textBox4.Text.IndexOf("(") == -1 && textBox4.Text.IndexOf(")") == -1)
            {
                listBox1.Items.Add(textBox4.Text + " (" + textBox3.Text + ")");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxChanged();
        }
    }
}
