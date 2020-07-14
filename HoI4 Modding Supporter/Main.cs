using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // 初期化
            allClear();

            // 従属国オプション
            if (checkBox2.Checked == false)
            {
                textBox36.Enabled = false;
            }
            else if (checkBox2.Checked == true)
            {
                textBox36.Enabled = true;
            }

            // 宗主国オプション
            if (checkBox3.Checked == false)
            {
                textBox37.Enabled = false;
                textBox38.Enabled = false;
            }
            else if (checkBox3.Checked == true)
            {
                textBox37.Enabled = true;
                textBox38.Enabled = true;
            }

            // 配色
            colorChange();
            // 初期政党支持率の合計
            partiesSupportTotal();
        }

        /// <summary>
        /// テキストボックスをすべてリセット
        /// </summary>
        public void allClear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 1;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown10.Value = 0;
            numericUpDown11.Value = 0;
            numericUpDown12.Value = 0;
            numericUpDown13.Value = 0;
            numericUpDown14.Value = 1;
            numericUpDown15.Value = 1;
            numericUpDown16.Value = 1000;
            numericUpDown17.Value = 1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        /// <summary>
        /// 配色の出力
        /// </summary>
        public void colorChange()
        {
            int r = (int)numericUpDown1.Value;
            int g = (int)numericUpDown2.Value;
            int b = (int)numericUpDown3.Value;
            Color color = Color.FromArgb(r, g, b);
            panel2.BackColor = color;
        }

        /// <summary>
        /// 政党支持率合計の出力
        /// </summary>
        public void partiesSupportTotal()
        {
            int nSupport = (int)numericUpDown12.Value;
            int dSupport = (int)numericUpDown11.Value;
            int fSupport = (int)numericUpDown10.Value;
            int cSupport = (int)numericUpDown9.Value;

            int total = nSupport + dSupport + fSupport + cSupport;

            textBox27.Text = total.ToString();
        }

        /// <summary>
        /// tgaファイル参照
        /// </summary>
        /// <param name="ideology">イデオロギー（n, d, f, c）</param>
        /// <param name="size">サイズ（big, medium, small）</param>
        public void openTGAFile(string ideology, string size)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { FileName = "Flag.tga", Filter = "TGAファイル|*.tga", RestoreDirectory = true, CheckFileExists = true, CheckPathExists = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    switch (ideology)
                    {
                        case "n":
                            switch (size)
                            {
                                case "big":
                                    textBox17.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox16.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox15.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case "d":
                            switch (size)
                            {
                                case "big":
                                    textBox23.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox22.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox21.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case "f":
                            switch (size)
                            {
                                case "big":
                                    textBox20.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox19.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox18.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case "c":
                            switch (size)
                            {
                                case "big":
                                    textBox26.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox25.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox24.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 生成直前に入るチェック
        /// 入力ミスなどを検知する
        /// </summary>
        public void check()
        {
            // hoi4ディレクトリ・modディレクトリ
            if (Properties.Settings.Default.hoi4dir == "" || Properties.Settings.Default.moddir == "")
            {
                errorMessage("HoI4本体のディレクトリ、またはmodディレクトリが設定されていません。\n[ツール] - [設定]からフォルダーパスを設定してください。");
                return;
            }

            // 国家タグ
            // テキストボックスが空っぽまたはスペース、大文字ではない
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorMessage("国家タグが無効です。");
                return;
            }

            // 国名
            // 内部処理用
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorMessage("[国名] - [内部処理用]が無効です。");
                return;
            }

            // 中道主義
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorMessage("[国名] - [中道主義] - [表示名]が無効です。");
                return;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorMessage("[国名] - [中道主義] - [イベント表示名]が無効です。");
                return;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                errorMessage("[国名] - [中道主義] - [通称名]が無効です。");
                return;
            }

            // 民主主義
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                errorMessage("[国名] - [民主主義] - [表示名]が無効です。");
                return;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                errorMessage("[国名] - [民主主義] - [イベント表示名]が無効です。");
                return;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                errorMessage("[国名] - [民主主義] - [通称名]が無効です。");
                return;
            }

            // ファシズム
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox11.Text))
            {
                errorMessage("[国名] - [ファシズム] - [表示名]が無効です。");
                return;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                errorMessage("[国名] - [ファシズム] - [イベント表示名]が無効です。");
                return;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                errorMessage("[国名] - [ファシズム] - [通称名]が無効です。");
                return;
            }

            // 共産主義
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox14.Text))
            {
                errorMessage("[国名] - [共産主義] - [表示名]が無効です。");
                return;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox13.Text))
            {
                errorMessage("[国名] - [共産主義] - [イベント表示名]が無効です。");
                return;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox12.Text))
            {
                errorMessage("[国名] - [共産主義] - [通称名]が無効です。");
                return;
            }

            // 国旗はファイルパスが指定されてなくてもOK

            // 政党名
            // 中道主義政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox30.Text))
            {
                errorMessage("[政党名] - [中道主義政党] - [通称名]が無効です。");
                return;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox29.Text))
            {
                errorMessage("[政党名] - [中道主義政党] - [正式名]が無効です。");
                return;
            }
            // 民主主義政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox35.Text))
            {
                errorMessage("[政党名] - [民主主義政党] - [通称名]が無効です。");
                return;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox34.Text))
            {
                errorMessage("[政党名] - [民主主義政党] - [正式名]が無効です。");
                return;
            }
            // ファシズム政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox31.Text))
            {
                errorMessage("[政党名] - [ファシズム政党] - [通称名]が無効です。");
                return;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox28.Text))
            {
                errorMessage("[政党名] - [ファシズム政党] - [正式名]が無効です。");
                return;
            }
            // 共産主義政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox33.Text))
            {
                errorMessage("[政党名] - [共産主義政党] - [通称名]が無効です。");
                return;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox32.Text))
            {
                errorMessage("[政党名] - [共産主義政党] - [正式名]が無効です。");
                return;
            }

            // 各種設定
            // 汎用顔グラフィックの地域設定
            if (comboBox1.SelectedItem == null)
            {
                errorMessage("[各種設定] - [汎用顔グラフィックの地域設定]が設定されていません。");
                return;
            }
            // 初期政党支持率（の合計が100%ではない場合）
            partiesSupportTotal();
            int total = int.Parse(textBox27.Text);
            if (total != 100)
            {
                errorMessage("[各種設定] - [初期政党支持率]の合計が100%ではありません。\n[合計]の値を確認してください。");
                return;
            }
            // 初期与党
            if (comboBox2.SelectedItem == null)
            {
                errorMessage("[各種設定] - [初期与党] - [イデオロギー]が設定されていません。");
                return;
            }
            // 従属国である場合
            if (checkBox2.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(textBox36.Text))
                {
                    errorMessage("[各種設定] - [宗主国の国家タグ]が無効です。");
                }
            }
            // 宗主国である場合
            if (checkBox3.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(textBox37.Text))
                {
                    errorMessage("[各種設定] - [従属国の国家タグ]が無効です。");
                }
            }
        }

        /// <summary>
        /// 新規国家の書き込み処理
        /// </summary>
        public void generateCountry()
        {
            // フォルダパス
            string hoi4dir = Properties.Settings.Default.hoi4dir + "\\";
            string moddir = Properties.Settings.Default.moddir + "\\";

            // データ
            // 国家タグ
            string countryTag = textBox1.Text;
            // 内部処理用国名
            string countryName = textBox2.Text;
            // 中道主義
            // 表示名
            string n_ViewName = textBox3.Text;
            // イベント表示名
            string n_EventViewName = textBox4.Text;
            // 通称名
            string n_AliasName = textBox5.Text;
            // 民主主義
            // 表示名
            string d_ViewName = textBox8.Text;
            // イベント表示名
            string d_EventViewName = textBox7.Text;
            // 通称名
            string d_AliasName = textBox6.Text;
            // ファシズム
            // 表示名
            string f_ViewName = textBox11.Text;
            // イベント表示名
            string f_EventViewName = textBox10.Text;
            // 通称名
            string f_AliasName = textBox9.Text;
            // 共産主義
            // 表示名
            string c_ViewName = textBox14.Text;
            // イベント表示名
            string c_EventViewName = textBox13.Text;
            // 通称名
            string c_AliasName = textBox12.Text;
            // 国旗ファイルパス
            // 中道主義
            // 大
            string n_FlagBig = textBox17.Text;
            // 中
            string n_FlagMid = textBox16.Text;
            // 小
            string n_FlagSma = textBox15.Text;
            // 民主主義
            // 大
            string d_FlagBig = textBox23.Text;
            // 中
            string d_FlagMid = textBox22.Text;
            // 小
            string d_FlagSma = textBox21.Text;
            // ファシズム
            // 大
            string f_FlagBig = textBox20.Text;
            // 中
            string f_FlagMid = textBox19.Text;
            // 小
            string f_FlagSma = textBox18.Text;
            // 共産主義
            // 大
            string c_FlagBig = textBox26.Text;
            // 中
            string c_FlagMid = textBox25.Text;
            // 小
            string c_FlagSma = textBox24.Text;
            // 政党名
            // 中道主義
            // 通称名
            string n_PartyAliasName = textBox30.Text;
            // 正式名
            string n_PartyFullName = textBox29.Text;
            // 民主主義
            // 通称名
            string d_PartyAliasName = textBox35.Text;
            // 正式名
            string d_PartyFullName = textBox34.Text;
            // ファシズム
            // 通称名
            string f_PartyAliasName = textBox31.Text;
            // 正式名
            string f_PartyFullName = textBox28.Text;
            // 共産主義
            // 通称名
            string c_PartyAliasName = textBox33.Text;
            // 正式名
            string c_PartyFullName = textBox32.Text;
            // 配色
            int colorR = (int)numericUpDown1.Value;
            int colorG = (int)numericUpDown2.Value;
            int colorB = (int)numericUpDown3.Value;
            // 汎用顔グラフィック
            string graphicalCulture;
            string graphicalCulture2d;
            if (comboBox1.SelectedIndex == 0)
            {
                // 東ヨーロッパ
                graphicalCulture = "eastern_european_gfx";
                graphicalCulture2d = "eastern_european_2d";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // 西ヨーロッパ
                graphicalCulture = "western_european_gfx";
                graphicalCulture2d = "western_european_2d";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                // 中東
                graphicalCulture = "middle_eastern_gfx";
                graphicalCulture2d = "middle_eastern_2d";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                // 南アメリカ
                graphicalCulture = "southamerican_gfx";
                graphicalCulture2d = "southamerican_2d";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                // アジア
                graphicalCulture = "asian_gfx";
                graphicalCulture2d = "asian_2d";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                // アフリカ
                graphicalCulture = "african_gfx";
                graphicalCulture2d = "african_2d";
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                // イギリス連邦
                graphicalCulture = "commonwealth_gfx";
                graphicalCulture2d = "commonwealth_2d";
            }

            // 首都を含む州ID
            int stateIDWithCapital = (int)numericUpDown4.Value;
            // 研究スロット数
            int studySlot = (int)numericUpDown5.Value;
            // 初期安定度（100分率）
            double stability = (int)numericUpDown6.Value * 0.01;
            // 初期戦争協力度
            double warCoop = (int)numericUpDown7.Value * 0.01;
            // 初期政治力
            int politicalPower = (int)numericUpDown8.Value;
            // 初期輸送船数
            int transportShip = (int)numericUpDown13.Value;
            // この国が従属国かどうか
            bool dependentCountry = checkBox2.Checked;
            // 宗主国の国家タグ（存在しない場合はnull）
            string sovereignCountryTag = null;

            if (dependentCountry == true)
            {
                sovereignCountryTag = textBox36.Text;
            }

            // この国が宗主国かどうか
            bool sovereignCountry = checkBox3.Checked;
            // 従属国の国家タグ（存在しない場合はnull）
            string dependentCountryTag1 = null;
            string dependentCountryTag2 = null;

            if (dependentCountry == true)
            {
                dependentCountryTag1 = textBox37.Text;

                if (string.IsNullOrWhiteSpace(textBox38.Text) != true)
                {
                    dependentCountryTag2 = textBox38.Text;
                }
            }

            // 初期政党支持率
            // 中道主義
            double n_Popularity = (int)numericUpDown12.Value * 0.01;
            // 民主主義
            double d_Popularity = (int)numericUpDown11.Value * 0.01;
            // ファシズム
            double f_Popularity = (int)numericUpDown10.Value * 0.01;
            // 共産主義
            double c_Popularity = (int)numericUpDown9.Value * 0.01;

            // 初期与党
            // イデオロギー
            string startIdeology;
            if (comboBox2.SelectedIndex == 0)
            {
                // 中道主義
                startIdeology = "neutrality";

            }
            else if (comboBox2.SelectedIndex == 1)
            {
                // 民主主義
                startIdeology = "democratic";

            }
            else if (comboBox2.SelectedIndex == 2)
            {
                // ファシズム
                startIdeology = "fascism";

            }
            else if (comboBox2.SelectedIndex == 3)
            {
                // 共産主義
                startIdeology = "communism";

            }

            // 前回の選挙
            // YYYY
            int lastElectionYYYY = (int)numericUpDown16.Value;
            // MM
            int lastElectionMM = (int)numericUpDown15.Value;
            // DD
            int lastElectionDD = (int)numericUpDown14.Value;
            // YYYY.MM.DD
            string lastElection = lastElectionYYYY.ToString() + "." + lastElectionMM.ToString() + "." + lastElectionDD.ToString();

            // 選挙がないかどうか（true -> なし）
            bool noElection = checkBox1.Checked;
        }

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void errorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            colorChange();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            colorChange();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            colorChange();
        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                textBox36.Enabled = false;
            }
            else if (checkBox2.Checked == true)
            {
                textBox36.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                textBox37.Enabled = false;
                textBox38.Enabled = false;
            }
            else if (checkBox3.Checked == true)
            {
                textBox37.Enabled = true;
                textBox38.Enabled = true;
            }
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            partiesSupportTotal();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            partiesSupportTotal();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            partiesSupportTotal();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            partiesSupportTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openTGAFile("n", "big");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openTGAFile("n", "medium");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openTGAFile("n", "small");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openTGAFile("d", "big");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openTGAFile("d", "medium");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openTGAFile("d", "small");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openTGAFile("f", "big");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openTGAFile("f", "medium");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openTGAFile("f", "small");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openTGAFile("c", "big");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openTGAFile("c", "medium");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openTGAFile("c", "small");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            allClear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //check();
            MessageBox.Show("国家の生成を行います。");
            generateCountry();
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
