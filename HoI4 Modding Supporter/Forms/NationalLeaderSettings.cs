using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HoI4_Modding_Supporter.Database;
using HoI4_Modding_Supporter.Mediators;

namespace HoI4_Modding_Supporter.Forms
{
    public partial class NationalLeaderSettings : Form
    {
        InternalController ic = new InternalController();
        UserController uc = new UserController();

        public NationalLeaderSettings()
        {
            InitializeComponent();

            Variable variable = new Variable();

            if (variable.LeaderName == null)
            {
                textBox1.Text = "";
            }
            else
            {
                textBox1.Text = variable.LeaderName;
            }

            if (variable.LeaderDesc == null)
            {
                richTextBox1.Text = "";
            }
            else
            {
                richTextBox1.Text = variable.LeaderDesc;
            }

            if (variable.LeaderPicturePath == null)
            {
                textBox17.Text = "";
            }
            else
            {
                textBox17.Text = variable.LeaderPicturePath;
            }

            string[] ideologies = { "中道主義", "民主主義", "ファシズム", "共産主義" };
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ideologies);

            DisabledReflect();

            if (variable.LeaderIdeology == null)
            {
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
            }
            else
            {
                if (Properties.Settings.Default.neutralityDisabled == false)
                {
                    if (variable.LeaderIdeology == "despotism")
                    {
                        comboBox1.SelectedItem = "中道主義";
                        comboBox2.SelectedItem = "独裁主義者";
                    }
                    else if (variable.LeaderIdeology == "oligarchism")
                    {
                        comboBox1.SelectedItem = "中道主義";
                        comboBox2.SelectedItem = "寡頭主義者";
                    }
                    else if (variable.LeaderIdeology == "anarchism")
                    {
                        comboBox1.SelectedItem = "中道主義";
                        comboBox2.SelectedItem = "無政府主義者";
                    }
                    else if (variable.LeaderIdeology == "moderatism")
                    {
                        comboBox1.SelectedItem = "中道主義";
                        comboBox2.SelectedItem = "近代主義者";
                    }
                    else if (variable.LeaderIdeology == "centrism")
                    {
                        comboBox1.SelectedItem = "中道主義";
                        comboBox2.SelectedItem = "中道主義者";
                    }
                }

                if (Properties.Settings.Default.democraticDisabled == false)
                {
                    if (variable.LeaderIdeology == "conservatism")
                    {
                        comboBox1.SelectedItem = "民主主義";
                        comboBox2.SelectedItem = "保守主義者";
                    }
                    else if (variable.LeaderIdeology == "liberalism")
                    {
                        comboBox1.SelectedItem = "民主主義";
                        comboBox2.SelectedItem = "自由主義者";
                    }
                    else if (variable.LeaderIdeology == "socialism")
                    {
                        comboBox1.SelectedItem = "民主主義";
                        comboBox2.SelectedItem = "社会主義者";
                    }
                }

                if (Properties.Settings.Default.fascismDisabled == false)
                {
                    if (variable.LeaderIdeology == "nazism")
                    {
                        comboBox1.SelectedItem = "ファシズム";
                        comboBox2.SelectedItem = "国家社会主義者";
                    }
                    else if (variable.LeaderIdeology == "fascism_ideology")
                    {
                        comboBox1.SelectedItem = "ファシズム";
                        comboBox2.SelectedItem = "ファシスト";
                    }
                    else if (variable.LeaderIdeology == "falangism")
                    {
                        comboBox1.SelectedItem = "ファシズム";
                        comboBox2.SelectedItem = "ファランジスト";
                    }
                    else if (variable.LeaderIdeology == "rexism")
                    {
                        comboBox1.SelectedItem = "ファシズム";
                        comboBox2.SelectedItem = "レクシスト";
                    }
                }

                if (Properties.Settings.Default.communismDisabled == false)
                {
                    if (variable.LeaderIdeology == "marxism")
                    {
                        comboBox1.SelectedItem = "共産主義";
                        comboBox2.SelectedItem = "マルクス主義者";
                    }
                    else if (variable.LeaderIdeology == "leninism")
                    {
                        comboBox1.SelectedItem = "共産主義";
                        comboBox2.SelectedItem = "レーニン主義者";
                    }
                    else if (variable.LeaderIdeology == "stalinism")
                    {
                        comboBox1.SelectedItem = "共産主義";
                        comboBox2.SelectedItem = "スターリン主義者";
                    }
                    else if (variable.LeaderIdeology == "anti_revisionism")
                    {
                        comboBox1.SelectedItem = "共産主義";
                        comboBox2.SelectedItem = "反修正主義者";
                    }
                    else if (variable.LeaderIdeology == "anarchist_communism")
                    {
                        comboBox1.SelectedItem = "共産主義";
                        comboBox2.SelectedItem = "無政府共産主義者";
                    }
                }
            }

            if (variable.CustomLeaderEnabled == true)
            {
                checkBox1.Checked = true;
                ChangeCheckBox(true);
            }
            else
            {
                checkBox1.Checked = false;
                ChangeCheckBox(false);
            }
        }

        /// <summary>
        /// 入力ミスなどを検知する
        /// </summary>
        /// <returns></returns>
        private int Check()
        {
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox17);
            List<RichTextBox> richTextBoxes = new List<RichTextBox>();
            richTextBoxes.Add(richTextBox1);
            List<ComboBox> comboBoxes = new List<ComboBox>();
            comboBoxes.Add(comboBox1);
            comboBoxes.Add(comboBox2);

            return uc.NationalLeaderSettingsChecker(textBoxes, richTextBoxes, comboBoxes);
        }

        /// <summary>
        /// データの変数化処理
        /// </summary>
        private void DataAssignment()
        {
            Variable variable = new Variable();

            // カスタム国家指導者の有効化
            variable.CustomLeaderEnabled = checkBox1.Checked;
            // 名前
            variable.LeaderName = textBox1.Text;
            // 説明
            variable.LeaderDesc = richTextBox1.Text;
            // 画像
            variable.LeaderPicturePath = textBox17.Text;
            // 画像ファイル名（指導者名がファイル名になります）
            variable.LeaderPictureName = variable.LeaderName.Replace(" ", "_") + ".dds";
            // イデオロギー
            if (comboBox1.SelectedItem.ToString() == "中道主義")
            {
                // despotism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.LeaderIdeology = "despotism";
                }
                // oligarchism
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.LeaderIdeology = "oligarchism";
                }
                // anarchism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.LeaderIdeology = "anarchism";
                }
                // moderatism
                else if (comboBox2.SelectedIndex == 3)
                {
                    variable.LeaderIdeology = "moderatism";
                }
                // centrism
                else if (comboBox2.SelectedIndex == 4)
                {
                    variable.LeaderIdeology = "centrism";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "民主主義")
            {
                // conservatism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.LeaderIdeology = "conservatism";
                }
                // liberalism
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.LeaderIdeology = "liberalism";
                }
                // socialism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.LeaderIdeology = "socialism";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ファシズム")
            {
                // nazism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.LeaderIdeology = "nazism";
                }
                // fascism_ideology
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.LeaderIdeology = "fascism_ideology";
                }
                // falangism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.LeaderIdeology = "falangism";
                }
                // rexism
                else if (comboBox2.SelectedIndex == 3)
                {
                    variable.LeaderIdeology = "rexism";
                }
                
            }
            else if (comboBox1.SelectedItem.ToString() == "共産主義")
            {
                //marxism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.LeaderIdeology = "marxism";
                }
                // leninism
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.LeaderIdeology = "leninism";
                }
                // stalinism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.LeaderIdeology = "stalinism";
                }
                // anti_revisionism
                else if (comboBox2.SelectedIndex == 3)
                {
                    variable.LeaderIdeology = "anti_revisionism";
                }
                // anarchist_communism
                else if (comboBox2.SelectedIndex == 4)
                {
                    variable.LeaderIdeology = "anarchist_communism";
                }
            }

            // 登場しなくなる年月日 (YYYY/M/D)
            variable.WillNotAppear = numericUpDown16.Value.ToString() + "." + numericUpDown15.Value.ToString() + "." + numericUpDown14.Value.ToString();
        }

        /// <summary>
        /// チェックボックス変更時の処理
        /// </summary>
        /// <param name="check">チェックボックスの状態</param>
        private void ChangeCheckBox(bool check)
        {
            textBox1.Enabled = check;
            richTextBox1.Enabled = check;
            textBox17.Enabled = check;
            button3.Enabled = check;
            comboBox1.Enabled = check;
            comboBox2.Enabled = check;
            numericUpDown16.Enabled = check;
            numericUpDown15.Enabled = check;
            numericUpDown14.Enabled = check;
        }

        /// <summary>
        /// 無効設定の反映
        /// </summary>
        private void DisabledReflect()
        {
            if (Properties.Settings.Default.neutralityDisabled == true)
            {
                comboBox1.Items.Remove("中道主義");
            }

            if (Properties.Settings.Default.democraticDisabled == true)
            {
                comboBox1.Items.Remove("民主主義");
            }
            
            if (Properties.Settings.Default.fascismDisabled == true)
            {
                comboBox1.Items.Remove("ファシズム");
            }

            if (Properties.Settings.Default.communismDisabled == true)
            {
                comboBox1.Items.Remove("共産主義");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBox(checkBox1.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Variable variable = new Variable();

            if (checkBox1.Checked == false)
            {
                variable.CustomLeaderEnabled = false;
                this.Close();
            }
            else
            {
                if (Check() == 1)
                    return;
                else
                {
                    DataAssignment();
                    this.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { FileName = "Picture.dds", Filter = "DDSファイル|*.dds", RestoreDirectory = true, CheckFileExists= true, CheckPathExists = true })
            {
                if (ofd.ShowDialog() ==DialogResult.OK)
                {
                    textBox17.Text = ofd.FileName;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] nIdeologies = { "独裁主義者", "寡頭主義者", "無政府主義者", "近代主義者", "中道主義者" };
            string[] dIdeologies = { "保守主義者", "自由主義者", "社会主義者" };
            string[] fIdeologies = { "国家社会主義者", "ファシスト", "ファランジスト", "レクシスト" };
            string[] cIdeologies = { "マルクス主義者", "レーニン主義者", "スターリン主義者", "反修正主義者", "無政府共産主義者" };

            if (comboBox1.SelectedItem != null)
            {
                // 中道主義
                if (comboBox1.SelectedItem.ToString() == "中道主義")
                {
                    // despotism, oligarchism, anarchism, moderatism, centrism
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(nIdeologies);

                }
                // 民主主義
                else if (comboBox1.SelectedItem.ToString() == "民主主義")
                {
                    // conservatism, liberalism, socialism
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(dIdeologies);
                }
                // ファシズム
                else if (comboBox1.SelectedItem.ToString() == "ファシズム")
                {
                    // nazism, fascism_ideology, falangism, rexism
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(fIdeologies);
                }
                // 共産主義
                else if (comboBox1.SelectedItem.ToString() == "共産主義")
                {
                    // marxism, leninism, stalinism, anti_revisionism, anarchist_communism
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(cIdeologies);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            textBox17.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            numericUpDown16.Value = 1936;
            numericUpDown15.Value = 1;
            numericUpDown14.Value = 1;
        }
    }
}
