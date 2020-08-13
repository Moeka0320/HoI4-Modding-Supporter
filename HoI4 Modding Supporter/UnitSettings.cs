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
    public partial class UnitSettings : Form
    {
        public UnitSettings()
        {
            InitializeComponent();

            if (checkBox1.Checked == true)
            {
                changeCheckBox(true, 0);
            }
            else
            {
                changeCheckBox(false, 0);
            }

            if (checkBox2.Checked == true)
            {
                changeCheckBox(true, 1);
            }
            else
            {
                changeCheckBox(false, 1);
            }

            if (checkBox3.Checked == true)
            {
                changeCheckBox(true, 2);
            }
            else
            {
                changeCheckBox(false, 2);
            }
        }

        /// <summary>
        /// チェックボックスの変更時の処理
        /// </summary>
        /// <param name="check">チェックボックスの状態</param>
        /// <param name="tab">タブインデックス</param>
        public void changeCheckBox(bool check, int tab)
        {
            // 陸軍ユニットの設定
            if (tab == 0)
            {
                textBox1.Enabled = check;
                comboBox1.Enabled = check;
                comboBox2.Enabled = check;
                comboBox3.Enabled = check;
                comboBox4.Enabled = check;
                comboBox5.Enabled = check;
                comboBox6.Enabled = check;
                comboBox7.Enabled = check;
                comboBox8.Enabled = check;
                comboBox9.Enabled = check;
                comboBox10.Enabled = check;
                comboBox11.Enabled = check;
                comboBox12.Enabled = check;
                comboBox13.Enabled = check;
                comboBox14.Enabled = check;
                comboBox15.Enabled = check;
                comboBox16.Enabled = check;
                comboBox17.Enabled = check;
                comboBox18.Enabled = check;
                comboBox19.Enabled = check;
                comboBox20.Enabled = check;
                comboBox21.Enabled = check;
                comboBox22.Enabled = check;
                comboBox23.Enabled = check;
                comboBox24.Enabled = check;
                comboBox25.Enabled = check;
                comboBox26.Enabled = check;
                comboBox27.Enabled = check;
                comboBox28.Enabled = check;
                comboBox29.Enabled = check;
                comboBox30.Enabled = check;
            }
            // 海軍ユニットの設定
            else if (tab == 1)
            {

            }
            // 空軍ユニットの設定
            else
            {
                numericUpDown2.Enabled = check;
                numericUpDown3.Enabled = check;
                comboBox31.Enabled = check;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            changeCheckBox(checkBox1.Checked, 0);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            changeCheckBox(checkBox2.Checked, 1);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            changeCheckBox(checkBox3.Checked, 2);
        }
    }
}
