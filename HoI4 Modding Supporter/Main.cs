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
    }
}
