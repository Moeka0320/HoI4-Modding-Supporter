using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace HoI4_Modding_Supporter
{
    public partial class CustomIdeologiesSettings : Form
    {
        List<TextBox> totalPopularityTextBoxList = new List<TextBox>();
        List<NumericUpDown> popularityNumericList = new List<NumericUpDown>();
        List<TextBox> viewNameTextBoxList = new List<TextBox>();
        List<TextBox> eventViewNameTextBoxList = new List<TextBox>();
        List<TextBox> aliasNameTextBoxList = new List<TextBox>();
        List<TextBox> bigFlagPathTextBoxList = new List<TextBox>();
        List<TextBox> mediumFlagPathTextBoxList = new List<TextBox>();
        List<TextBox> smallFlagPathTextBoxList = new List<TextBox>();
        List<TextBox> partyAliasNameTextBoxList = new List<TextBox>();
        List<TextBox> partyFullNameTextBoxList = new List<TextBox>();

        public CustomIdeologiesSettings()
        {
            InitializeComponent();
            CreateNewTab();
            PartyPopularityView();
            ValueRecovery();
        }

        /// <summary>
        /// 作成したイデオロギーの数だけタブページを作成
        /// </summary>
        public void CreateNewTab()
        {
            if (Properties.Settings.Default.customIdeologiesInternalName.Contains("temp") == false && Properties.Settings.Default.customIdeologiesName.Contains("temp") == false)
            {
                for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
                {
                    // タブページ
                    TabPage tabPage = new TabPage()
                    {
                        // タブテキストをIdeologiesNameに
                        // タブ名をIdeologiesInternalNameに
                        Text = Properties.Settings.Default.customIdeologiesName[cnt],
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt],
                        BackColor = Color.White
                    };

                    // グループボックス「国名」
                    GroupBox nationNameGroup = new GroupBox()
                    {
                        Text = "国名",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - NationNameGroup",
                        Size = new Size(252, 90),
                        Location = new Point(3, 3)
                    };

                    // ラベル「表示名：」
                    Label viewNameLabel = new Label()
                    {
                        Text = "表示名：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - ViewNameLabel",
                        Location = new Point(6, 15),
                        Size = new Size(47, 12)
                    };

                    // ラベル「イベント表示名：」
                    Label eventViewNameLabel = new Label()
                    { 
                        Text = "イベント表示名：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - EventViewNameLabel",
                        Location = new Point(6, 40),
                        Size = new Size(83, 12)
                    };

                    // ラベル「通称名：」
                    Label aliasNameLabel = new Label()
                    {
                        Text = "通称名：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - AliasNameLabel",
                        Location = new Point(6, 65),
                        Size = new Size(47, 12)
                    };

                    // テキストボックス（表示名）
                    TextBox viewNameTextBox = new TextBox()
                    { 
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - ViewNameTextBox",
                        Size = new Size(151, 19),
                        Location = new Point(93, 12)
                    };

                    // テキストボックス（イベント表示名）
                    TextBox eventViewNameTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - EventViewNameTextBox",
                        Size = new Size(151, 19),
                        Location = new Point(93, 37)
                    };

                    // テキストボックス（通称名）
                    TextBox aliasNameTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - AliasNameTextBox",
                        Size = new Size(151, 19),
                        Location = new Point(93, 62)
                    };

                    // グループボックス「国旗」
                    GroupBox nationFlagGroup = new GroupBox()
                    {
                        Text = "国旗",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - NationFlagGroup",
                        Size = new Size(252, 90),
                        Location = new Point(3, 99)
                    };

                    // ラベル「大：」
                    Label bigLabel = new Label()
                    {
                        Text = "大：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - BigLabel",
                        Size = new Size(23, 12),
                        Location = new Point(6, 15)
                    };

                    // ラベル「中：」
                    Label mediumLabel = new Label()
                    {
                        Text = "中：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - MediumLabel",
                        Size = new Size(23, 12),
                        Location = new Point(6, 40)
                    };

                    // ラベル「小：」
                    Label smallLabel = new Label()
                    {
                        Text = "小：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - SmallLabel",
                        Size = new Size(23, 12),
                        Location = new Point(6, 65)
                    };

                    // テキストボックス（国旗大パス）
                    TextBox bigFlagPathTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - BigFlagPathTextBox",
                        Size = new Size(128, 19),
                        Location = new Point(35, 12),
                        ReadOnly = true
                    };

                    // テキストボックス（国旗中パス）
                    TextBox mediumFlagPathTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - MediumFlagPathTextBox",
                        Size = new Size(128, 19),
                        Location = new Point(35, 37),
                        ReadOnly = true
                    };

                    // テキストボックス（国旗小パス）
                    TextBox smallFlagPathTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - SmallFlagPathTextBox",
                        Size = new Size(128, 19),
                        Location = new Point(35, 62),
                        ReadOnly = true
                    };

                    // 参照ボタン（国旗大）
                    Button bigFlagPathButton = new Button()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - BigFlagPathButton",
                        Text = "参照",
                        Size = new Size(75, 23),
                        Location = new Point(169, 10),
                        UseVisualStyleBackColor = true
                    };

                    // 参照ボタン（国旗中）
                    Button mediumFlagPathButton = new Button()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - MediumFlagPathButton",
                        Text = "参照",
                        Size = new Size(75, 23),
                        Location = new Point(169, 35),
                        UseVisualStyleBackColor = true
                    };

                    // 参照ボタン（国旗小）
                    Button smallFlagPathButton = new Button()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - SmallFlagPathButton",
                        Text = "参照",
                        Size = new Size(75, 23),
                        Location = new Point(169, 60),
                        UseVisualStyleBackColor = true
                    };

                    // グループボックス「○○政党名」
                    GroupBox partyNameGroup = new GroupBox()
                    { 
                        Text = Properties.Settings.Default.customIdeologiesName[cnt] + "政党名",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PartyNameGroup",
                        Size = new Size(252, 66),
                        Location = new Point(3, 195)
                    };

                    // ラベル「通称名：」
                    Label partyAliasNameLabel = new Label()
                    {
                        Text = "通称名：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PartyAliasNameLabel",
                        Size = new Size(47, 12),
                        Location = new Point(6, 15)
                    };

                    // ラベル「正式名：」
                    Label partyFullNameLabel = new Label()
                    {
                        Text = "正式名：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PartyFullName",
                        Size = new Size(47, 12),
                        Location = new Point(6, 40)
                    };

                    // テキストボックス（通称名）
                    TextBox partyAliasNameTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PartyAliasNameTextBox",
                        Size = new Size(185, 19),
                        Location = new Point(59, 12)
                    };

                    // テキストボックス（正式名）
                    TextBox partyFullNameTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PartyFullNameTextBox",
                        Size = new Size(185, 19),
                        Location = new Point(59, 37)
                    };

                    // グループボックス「初期政党支持率」
                    GroupBox popularitiesGroup = new GroupBox()
                    {
                        Text = "初期政党支持率",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PopularitiesGroup",
                        Size = new Size(252, 67),
                        Location = new Point(3, 267)
                    };

                    // ラベル「○○主義：」
                    Label popularityLabel = new Label()
                    {
                        Text = Properties.Settings.Default.customIdeologiesName[cnt] + "：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PopularityLabel",
                        Location = new Point(6, 15)

                    };

                    // ラベル「合計：」
                    Label totalPopularityLabel = new Label()
                    {
                        Text = "合計：",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - TotalPopularityLabel",
                        Size = new Size(35, 12),
                        Location = new Point(6, 41),
                        TextAlign = ContentAlignment.TopRight
                    };

                    // NumericUpDown「政党支持率」
                    NumericUpDown popularityNumeric = new NumericUpDown()
                    {
                        Value = 0,
                        Maximum = 100,
                        Minimum = 0,
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PopularityNumeric",
                        Size = new Size(39, 19),
                        Location = new Point(180, 13),
                        TextAlign = HorizontalAlignment.Right
                    };

                    

                    // テキストボックス「政党支持率の合計」
                    TextBox totalPopularityTextBox = new TextBox()
                    {
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - TotalPopularityTextBox",
                        Size = new Size(39, 19),
                        Location = new Point(180, 38),
                        Enabled = false,
                        TextAlign = HorizontalAlignment.Right
                    };

                    // ラベル「%」
                    Label percentLabel1 = new Label()
                    {
                        Text = "%",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PercentLabel1",
                        Size = new Size(11, 12),
                        Location = new Point(225, 15)
                    };

                    Label percentLabel2 = new Label()
                    {
                        Text = "%",
                        Name = Properties.Settings.Default.customIdeologiesInternalName[cnt] + " - PercentLabel2",
                        Size = new Size(11, 12),
                        Location = new Point(225, 41)
                    };

                    nationNameGroup.Controls.Add(viewNameLabel);
                    nationNameGroup.Controls.Add(eventViewNameLabel);
                    nationNameGroup.Controls.Add(aliasNameLabel);
                    nationNameGroup.Controls.Add(viewNameTextBox);
                    nationNameGroup.Controls.Add(eventViewNameTextBox);
                    nationNameGroup.Controls.Add(aliasNameTextBox);

                    nationFlagGroup.Controls.Add(bigLabel);
                    nationFlagGroup.Controls.Add(mediumLabel);
                    nationFlagGroup.Controls.Add(smallLabel);
                    nationFlagGroup.Controls.Add(bigFlagPathTextBox);
                    nationFlagGroup.Controls.Add(mediumFlagPathTextBox);
                    nationFlagGroup.Controls.Add(smallFlagPathTextBox);
                    nationFlagGroup.Controls.Add(bigFlagPathButton);
                    nationFlagGroup.Controls.Add(mediumFlagPathButton);
                    nationFlagGroup.Controls.Add(smallFlagPathButton);

                    partyNameGroup.Controls.Add(partyAliasNameLabel);
                    partyNameGroup.Controls.Add(partyFullNameLabel);
                    partyNameGroup.Controls.Add(partyAliasNameTextBox);
                    partyNameGroup.Controls.Add(partyFullNameTextBox);

                    popularitiesGroup.Controls.Add(popularityLabel);
                    popularitiesGroup.Controls.Add(totalPopularityLabel);
                    popularitiesGroup.Controls.Add(popularityNumeric);
                    popularitiesGroup.Controls.Add(totalPopularityTextBox);
                    popularitiesGroup.Controls.Add(percentLabel1);
                    popularitiesGroup.Controls.Add(percentLabel2);

                    tabPage.Controls.Add(nationNameGroup);
                    tabPage.Controls.Add(nationFlagGroup);
                    tabPage.Controls.Add(partyNameGroup);
                    tabPage.Controls.Add(popularitiesGroup);
                    tabControl1.TabPages.Add(tabPage);

                    totalPopularityTextBoxList.Add(totalPopularityTextBox);
                    popularityNumericList.Add(popularityNumeric);
                    viewNameTextBoxList.Add(viewNameTextBox);
                    eventViewNameTextBoxList.Add(eventViewNameTextBox);
                    aliasNameTextBoxList.Add(aliasNameTextBox);
                    bigFlagPathTextBoxList.Add(bigFlagPathTextBox);
                    mediumFlagPathTextBoxList.Add(mediumFlagPathTextBox);
                    smallFlagPathTextBoxList.Add(smallFlagPathTextBox);
                    partyAliasNameTextBoxList.Add(partyAliasNameTextBox);
                    partyFullNameTextBoxList.Add(partyFullNameTextBox);

                    popularityNumeric.ValueChanged += PopularityNumeric_ValueChanged;
                    bigFlagPathButton.Click += BigFlagPathButton_Click;
                    mediumFlagPathButton.Click += MediumFlagPathButton_Click;
                    smallFlagPathButton.Click += SmallFlagPathButton_Click;
                }
            }
        }

        private void SmallFlagPathButton_Click(object sender, EventArgs e)
        {
            OpenTGAFile(2);
        }

        private void MediumFlagPathButton_Click(object sender, EventArgs e)
        {
            OpenTGAFile(1);
        }

        private void BigFlagPathButton_Click(object sender, EventArgs e)
        {
            OpenTGAFile(0);
        }

        private void PopularityNumeric_ValueChanged(object sender, EventArgs e)
        {
            PartyPopularityView();
        }

        /// <summary>
        /// 政党支持率の合計を出力
        /// </summary>
        public void PartyPopularityView()
        {
            Variable variable = new Variable();
            int totalPopularityValue = 0;

            if (Properties.Settings.Default.neutralityDisabled == false)
                totalPopularityValue += variable.N_Popularity;

            if (Properties.Settings.Default.democraticDisabled == false)
                totalPopularityValue += variable.D_Popularity;

            if (Properties.Settings.Default.fascismDisabled == false)
                totalPopularityValue += variable.F_Popularity;

            if (Properties.Settings.Default.communismDisabled == false)
                totalPopularityValue += variable.C_Popularity;

            for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
                totalPopularityValue += (int)popularityNumericList[cnt].Value;

            for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
                totalPopularityTextBoxList[cnt].Text = totalPopularityValue.ToString();
        }

        /// <summary>
        /// ウィンドウ起動時の値の復元
        /// </summary>
        public void ValueRecovery()
        {
            Variable variable = new Variable();

            // 政党支持率
            if (variable.CustomIdeologiesPopularity != null)
            {
                for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
                    popularityNumericList[cnt].Value = variable.CustomIdeologiesPopularity[cnt];
            }

            if (variable.CustomIdeologiesSettings != null)
            {
                for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
                {
                    // 国名
                    // 表示名
                    viewNameTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 0];

                    // イベント表示名
                    eventViewNameTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 1];

                    // 通称名
                    aliasNameTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 2];

                    // 国旗
                    // 大
                    bigFlagPathTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 3];

                    // 中
                    mediumFlagPathTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 4];

                    // 小
                    smallFlagPathTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 5];

                    // 政党名
                    // 通称名
                    partyAliasNameTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 6];

                    // 正式名
                    partyFullNameTextBoxList[cnt].Text = variable.CustomIdeologiesSettings[cnt, 7];

                }
            }
        }

        /// <summary>
        /// 値の保存
        /// </summary>
        public void ValueSave()
        {
            Variable variable = new Variable();

            int[] popularities = new int[Properties.Settings.Default.customIdeologiesName.Count];
            string[,] textBoxValues = new string[Properties.Settings.Default.customIdeologiesName.Count, 8];

            for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
            {
                popularities[cnt] = (int)popularityNumericList[cnt].Value;

                textBoxValues[cnt, 0] = viewNameTextBoxList[cnt].Text;
                textBoxValues[cnt, 1] = eventViewNameTextBoxList[cnt].Text;
                textBoxValues[cnt, 2] = aliasNameTextBoxList[cnt].Text;
                textBoxValues[cnt, 3] = bigFlagPathTextBoxList[cnt].Text;
                textBoxValues[cnt, 4] = mediumFlagPathTextBoxList[cnt].Text;
                textBoxValues[cnt, 5] = smallFlagPathTextBoxList[cnt].Text;
                textBoxValues[cnt, 6] = partyAliasNameTextBoxList[cnt].Text;
                textBoxValues[cnt, 7] = partyFullNameTextBoxList[cnt].Text;
            }

            variable.CustomIdeologiesPopularity = popularities;
            variable.CustomIdeologiesSettings = textBoxValues;
        }

        /// <summary>
        /// tgaファイルの参照
        /// </summary>
        /// <param name="size">サイズ（大：0, 中：1, 小：2）</param>
        public void OpenTGAFile(int size)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { FileName = "Flag.tga", Filter = "TGAファイル|*.tga", RestoreDirectory = true, CheckFileExists = true, CheckPathExists = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    switch (size)
                    {
                        case 0:
                            bigFlagPathTextBoxList[tabControl1.SelectedIndex].Text = ofd.FileName;
                            break;

                        case 1:
                            mediumFlagPathTextBoxList[tabControl1.SelectedIndex].Text = ofd.FileName;
                            break;

                        case 2:
                            smallFlagPathTextBoxList[tabControl1.SelectedIndex].Text = ofd.FileName;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 入力ミスなどを検知
        /// </summary>
        /// <returns></returns>
        public int Check()
        {
            for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
            {
                // 国名
                // 表示名
                if (string.IsNullOrWhiteSpace(viewNameTextBoxList[cnt].Text))
                {
                    ErrorMessage("[" + Properties.Settings.Default.customIdeologiesName[cnt] +"] - [国名] - [表示名]が無効です。");
                    return 1;
                }

                // イベント表示名
                if (string.IsNullOrWhiteSpace(eventViewNameTextBoxList[cnt].Text))
                {
                    ErrorMessage("[" + Properties.Settings.Default.customIdeologiesName[cnt] + "] - [国名] - [イベント表示名]が無効です。");
                    return 1;
                }

                // 通称名
                if (string.IsNullOrWhiteSpace(aliasNameTextBoxList[cnt].Text))
                {
                    ErrorMessage("[" + Properties.Settings.Default.customIdeologiesName[cnt] + "] - [国名] - [通称名]が無効です。");
                    return 1;
                }

                // 国旗はファイルパスが指定されてなくてもOK

                // 政党名
                // 通称名
                if (string.IsNullOrWhiteSpace(partyAliasNameTextBoxList[cnt].Text))
                {
                    ErrorMessage("[" + Properties.Settings.Default.customIdeologiesName[cnt] + "] - [政党名] - [通称名]が無効です。");
                    return 1;
                }

                // 正式名
                if (string.IsNullOrWhiteSpace(partyFullNameTextBoxList[cnt].Text))
                {
                    ErrorMessage("[" + Properties.Settings.Default.customIdeologiesName[cnt] + "] - [政党名] - [正式名]が無効です。");
                    return 1;
                }
            }

            MessageBox.Show("入力ミスのチェックが完了しました。");
            return 0;
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
            int cResult = Check();
            if (cResult == 1)
                return;

            ValueSave();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
