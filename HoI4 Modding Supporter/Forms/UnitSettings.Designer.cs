namespace HoI4_Modding_Supporter.Forms
{
    partial class UnitSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitSettings));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox26 = new System.Windows.Forms.ComboBox();
            this.comboBox27 = new System.Windows.Forms.ComboBox();
            this.comboBox28 = new System.Windows.Forms.ComboBox();
            this.comboBox29 = new System.Windows.Forms.ComboBox();
            this.comboBox30 = new System.Windows.Forms.ComboBox();
            this.comboBox24 = new System.Windows.Forms.ComboBox();
            this.comboBox25 = new System.Windows.Forms.ComboBox();
            this.comboBox19 = new System.Windows.Forms.ComboBox();
            this.comboBox20 = new System.Windows.Forms.ComboBox();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox21 = new System.Windows.Forms.ComboBox();
            this.comboBox22 = new System.Windows.Forms.ComboBox();
            this.comboBox23 = new System.Windows.Forms.ComboBox();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.comboBox17 = new System.Windows.Forms.ComboBox();
            this.comboBox18 = new System.Windows.Forms.ComboBox();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox31 = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(164, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "カスタム陸軍ユニットの有効化";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(164, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "カスタム海軍ユニットの有効化";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 6);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(164, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "カスタム空軍ユニットの有効化";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "陸軍";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 366);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "師団テンプレートの新規作成";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBox26);
            this.panel1.Controls.Add(this.comboBox27);
            this.panel1.Controls.Add(this.comboBox28);
            this.panel1.Controls.Add(this.comboBox29);
            this.panel1.Controls.Add(this.comboBox30);
            this.panel1.Controls.Add(this.comboBox24);
            this.panel1.Controls.Add(this.comboBox25);
            this.panel1.Controls.Add(this.comboBox19);
            this.panel1.Controls.Add(this.comboBox20);
            this.panel1.Controls.Add(this.comboBox14);
            this.panel1.Controls.Add(this.comboBox11);
            this.panel1.Controls.Add(this.comboBox9);
            this.panel1.Controls.Add(this.comboBox6);
            this.panel1.Controls.Add(this.comboBox21);
            this.panel1.Controls.Add(this.comboBox22);
            this.panel1.Controls.Add(this.comboBox23);
            this.panel1.Controls.Add(this.comboBox16);
            this.panel1.Controls.Add(this.comboBox17);
            this.panel1.Controls.Add(this.comboBox18);
            this.panel1.Controls.Add(this.comboBox12);
            this.panel1.Controls.Add(this.comboBox13);
            this.panel1.Controls.Add(this.comboBox15);
            this.panel1.Controls.Add(this.comboBox7);
            this.panel1.Controls.Add(this.comboBox8);
            this.panel1.Controls.Add(this.comboBox10);
            this.panel1.Controls.Add(this.comboBox5);
            this.panel1.Controls.Add(this.comboBox4);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(8, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 156);
            this.panel1.TabIndex = 3;
            // 
            // comboBox26
            // 
            this.comboBox26.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox26.FormattingEnabled = true;
            this.comboBox26.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox26.Location = new System.Drawing.Point(440, 24);
            this.comboBox26.Name = "comboBox26";
            this.comboBox26.Size = new System.Drawing.Size(81, 20);
            this.comboBox26.TabIndex = 31;
            // 
            // comboBox27
            // 
            this.comboBox27.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox27.FormattingEnabled = true;
            this.comboBox27.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox27.Location = new System.Drawing.Point(440, 50);
            this.comboBox27.Name = "comboBox27";
            this.comboBox27.Size = new System.Drawing.Size(81, 20);
            this.comboBox27.TabIndex = 30;
            // 
            // comboBox28
            // 
            this.comboBox28.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox28.FormattingEnabled = true;
            this.comboBox28.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox28.Location = new System.Drawing.Point(440, 76);
            this.comboBox28.Name = "comboBox28";
            this.comboBox28.Size = new System.Drawing.Size(81, 20);
            this.comboBox28.TabIndex = 29;
            // 
            // comboBox29
            // 
            this.comboBox29.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox29.FormattingEnabled = true;
            this.comboBox29.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox29.Location = new System.Drawing.Point(440, 102);
            this.comboBox29.Name = "comboBox29";
            this.comboBox29.Size = new System.Drawing.Size(81, 20);
            this.comboBox29.TabIndex = 28;
            // 
            // comboBox30
            // 
            this.comboBox30.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox30.FormattingEnabled = true;
            this.comboBox30.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox30.Location = new System.Drawing.Point(440, 128);
            this.comboBox30.Name = "comboBox30";
            this.comboBox30.Size = new System.Drawing.Size(81, 20);
            this.comboBox30.TabIndex = 27;
            // 
            // comboBox24
            // 
            this.comboBox24.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox24.FormattingEnabled = true;
            this.comboBox24.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox24.Location = new System.Drawing.Point(353, 102);
            this.comboBox24.Name = "comboBox24";
            this.comboBox24.Size = new System.Drawing.Size(81, 20);
            this.comboBox24.TabIndex = 23;
            // 
            // comboBox25
            // 
            this.comboBox25.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox25.FormattingEnabled = true;
            this.comboBox25.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox25.Location = new System.Drawing.Point(353, 128);
            this.comboBox25.Name = "comboBox25";
            this.comboBox25.Size = new System.Drawing.Size(81, 20);
            this.comboBox25.TabIndex = 22;
            // 
            // comboBox19
            // 
            this.comboBox19.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox19.FormattingEnabled = true;
            this.comboBox19.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox19.Location = new System.Drawing.Point(266, 102);
            this.comboBox19.Name = "comboBox19";
            this.comboBox19.Size = new System.Drawing.Size(81, 20);
            this.comboBox19.TabIndex = 18;
            // 
            // comboBox20
            // 
            this.comboBox20.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox20.FormattingEnabled = true;
            this.comboBox20.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox20.Location = new System.Drawing.Point(266, 128);
            this.comboBox20.Name = "comboBox20";
            this.comboBox20.Size = new System.Drawing.Size(81, 20);
            this.comboBox20.TabIndex = 17;
            // 
            // comboBox14
            // 
            this.comboBox14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox14.Location = new System.Drawing.Point(179, 102);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(81, 20);
            this.comboBox14.TabIndex = 13;
            // 
            // comboBox11
            // 
            this.comboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox11.Location = new System.Drawing.Point(179, 24);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(81, 20);
            this.comboBox11.TabIndex = 16;
            // 
            // comboBox9
            // 
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox9.Location = new System.Drawing.Point(92, 102);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(81, 20);
            this.comboBox9.TabIndex = 8;
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox6.Location = new System.Drawing.Point(92, 24);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(81, 20);
            this.comboBox6.TabIndex = 11;
            // 
            // comboBox21
            // 
            this.comboBox21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox21.FormattingEnabled = true;
            this.comboBox21.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox21.Location = new System.Drawing.Point(353, 24);
            this.comboBox21.Name = "comboBox21";
            this.comboBox21.Size = new System.Drawing.Size(81, 20);
            this.comboBox21.TabIndex = 26;
            // 
            // comboBox22
            // 
            this.comboBox22.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox22.FormattingEnabled = true;
            this.comboBox22.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox22.Location = new System.Drawing.Point(353, 50);
            this.comboBox22.Name = "comboBox22";
            this.comboBox22.Size = new System.Drawing.Size(81, 20);
            this.comboBox22.TabIndex = 25;
            // 
            // comboBox23
            // 
            this.comboBox23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox23.FormattingEnabled = true;
            this.comboBox23.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox23.Location = new System.Drawing.Point(353, 76);
            this.comboBox23.Name = "comboBox23";
            this.comboBox23.Size = new System.Drawing.Size(81, 20);
            this.comboBox23.TabIndex = 24;
            // 
            // comboBox16
            // 
            this.comboBox16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox16.FormattingEnabled = true;
            this.comboBox16.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox16.Location = new System.Drawing.Point(266, 24);
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(81, 20);
            this.comboBox16.TabIndex = 21;
            // 
            // comboBox17
            // 
            this.comboBox17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox17.FormattingEnabled = true;
            this.comboBox17.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox17.Location = new System.Drawing.Point(266, 50);
            this.comboBox17.Name = "comboBox17";
            this.comboBox17.Size = new System.Drawing.Size(81, 20);
            this.comboBox17.TabIndex = 20;
            // 
            // comboBox18
            // 
            this.comboBox18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox18.FormattingEnabled = true;
            this.comboBox18.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox18.Location = new System.Drawing.Point(266, 76);
            this.comboBox18.Name = "comboBox18";
            this.comboBox18.Size = new System.Drawing.Size(81, 20);
            this.comboBox18.TabIndex = 19;
            // 
            // comboBox12
            // 
            this.comboBox12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox12.Location = new System.Drawing.Point(179, 50);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(81, 20);
            this.comboBox12.TabIndex = 15;
            // 
            // comboBox13
            // 
            this.comboBox13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox13.Location = new System.Drawing.Point(179, 76);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(81, 20);
            this.comboBox13.TabIndex = 14;
            // 
            // comboBox15
            // 
            this.comboBox15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox15.Location = new System.Drawing.Point(179, 128);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(81, 20);
            this.comboBox15.TabIndex = 12;
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox7.Location = new System.Drawing.Point(92, 50);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(81, 20);
            this.comboBox7.TabIndex = 10;
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox8.Location = new System.Drawing.Point(92, 76);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(81, 20);
            this.comboBox8.TabIndex = 9;
            // 
            // comboBox10
            // 
            this.comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Items.AddRange(new object[] {
            "None",
            "歩兵",
            "騎兵",
            "砲兵",
            "自動車化砲兵",
            "機械化砲兵",
            "軽戦車",
            "中戦車",
            "重戦車",
            "現代戦車",
            "山岳兵",
            "海兵隊",
            "空挺兵"});
            this.comboBox10.Location = new System.Drawing.Point(92, 128);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(81, 20);
            this.comboBox10.TabIndex = 7;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "None",
            "偵察中隊",
            "工兵中隊",
            "野戦病院",
            "補給中隊",
            "憲兵隊",
            "通信中隊",
            "整備中隊"});
            this.comboBox5.Location = new System.Drawing.Point(5, 128);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(81, 20);
            this.comboBox5.TabIndex = 6;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "None",
            "偵察中隊",
            "工兵中隊",
            "野戦病院",
            "補給中隊",
            "憲兵隊",
            "通信中隊",
            "整備中隊"});
            this.comboBox4.Location = new System.Drawing.Point(5, 102);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(81, 20);
            this.comboBox4.TabIndex = 5;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "None",
            "偵察中隊",
            "工兵中隊",
            "野戦病院",
            "補給中隊",
            "憲兵隊",
            "通信中隊",
            "整備中隊"});
            this.comboBox3.Location = new System.Drawing.Point(5, 76);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(81, 20);
            this.comboBox3.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "None",
            "偵察中隊",
            "工兵中隊",
            "野戦病院",
            "補給中隊",
            "憲兵隊",
            "通信中隊",
            "整備中隊"});
            this.comboBox2.Location = new System.Drawing.Point(5, 50);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(81, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "偵察中隊",
            "工兵中隊",
            "野戦病院",
            "補給中隊",
            "憲兵隊",
            "通信中隊",
            "整備中隊"});
            this.comboBox1.Location = new System.Drawing.Point(5, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(81, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "戦闘大隊";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "支援中隊";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 19);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ユニット名：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "海軍";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.numericUpDown3);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.comboBox31);
            this.tabPage3.Controls.Add(this.numericUpDown2);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.checkBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "空軍";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(132, 94);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(62, 19);
            this.numericUpDown3.TabIndex = 8;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "配置する数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "配置するユニット：";
            // 
            // comboBox31
            // 
            this.comboBox31.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox31.FormattingEnabled = true;
            this.comboBox31.Items.AddRange(new object[] {
            "戦間期型戦闘機",
            "戦闘機Ⅰ",
            "戦闘機Ⅱ",
            "戦闘機Ⅲ",
            "重戦闘機Ⅰ",
            "重戦闘機Ⅱ",
            "重戦闘機Ⅲ",
            "近接航空支援機Ⅰ",
            "近接航空支援機Ⅱ",
            "近接航空支援機Ⅲ",
            "対艦攻撃機Ⅰ",
            "対艦攻撃機Ⅱ",
            "対艦攻撃機Ⅲ",
            "戦間期型爆撃機",
            "戦術爆撃機Ⅰ",
            "戦術爆撃機Ⅱ",
            "戦術爆撃機Ⅲ",
            "戦略爆撃機Ⅰ",
            "戦略爆撃機Ⅱ",
            "戦略爆撃機Ⅲ",
            "戦間期型艦上戦闘機",
            "艦上戦闘機Ⅰ",
            "艦上戦闘機Ⅱ",
            "艦上戦闘機Ⅲ",
            "艦上爆撃機Ⅰ",
            "艦上爆撃機Ⅱ",
            "艦上爆撃機Ⅲ",
            "艦上爆撃機Ⅰ(CAS)",
            "艦上爆撃機Ⅱ(CAS)",
            "艦上爆撃機Ⅲ(CAS)",
            "ジェット戦闘機Ⅰ",
            "ジェット戦闘機Ⅱ",
            "ジェット戦術爆撃機Ⅰ",
            "ジェット戦術爆撃機Ⅱ",
            "ジェット戦略爆撃機Ⅰ"});
            this.comboBox31.Location = new System.Drawing.Point(132, 68);
            this.comboBox31.Name = "comboBox31";
            this.comboBox31.Size = new System.Drawing.Size(141, 20);
            this.comboBox31.TabIndex = 5;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(132, 43);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(62, 19);
            this.numericUpDown2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "ユニットを配置する州ID：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(238, 7);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 19);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1936,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "シナリオ年：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "キャンセル";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(709, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UnitSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitSettings";
            this.Text = "ユニットの設定 - HoI4 Modding Supporter";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox26;
        private System.Windows.Forms.ComboBox comboBox27;
        private System.Windows.Forms.ComboBox comboBox28;
        private System.Windows.Forms.ComboBox comboBox29;
        private System.Windows.Forms.ComboBox comboBox30;
        private System.Windows.Forms.ComboBox comboBox21;
        private System.Windows.Forms.ComboBox comboBox22;
        private System.Windows.Forms.ComboBox comboBox23;
        private System.Windows.Forms.ComboBox comboBox24;
        private System.Windows.Forms.ComboBox comboBox25;
        private System.Windows.Forms.ComboBox comboBox16;
        private System.Windows.Forms.ComboBox comboBox17;
        private System.Windows.Forms.ComboBox comboBox18;
        private System.Windows.Forms.ComboBox comboBox19;
        private System.Windows.Forms.ComboBox comboBox20;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.ComboBox comboBox13;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.ComboBox comboBox15;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox31;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label7;
    }
}