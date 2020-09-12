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
                ChangeCheckBox(true, 0);
            else
                ChangeCheckBox(false, 0);

            if (checkBox2.Checked == true)
                ChangeCheckBox(true, 1);
            else
                ChangeCheckBox(false, 1);

            if (checkBox3.Checked == true)
                ChangeCheckBox(true, 2);
            else
                ChangeCheckBox(false, 2);
        }

        /// <summary>
        /// チェックボックスの変更時の処理
        /// </summary>
        /// <param name="check">チェックボックスの状態</param>
        /// <param name="tab">タブインデックス</param>
        public void ChangeCheckBox(bool check, int tab)
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

        /// <summary>
        /// 支援中隊リストの自動変更（実装未定）
        /// </summary>
        /// <param name="column">列の指定（1-5）</param>
        //public void SupportChange(int column)
        //{
        //    int selectedItemIndex;

        //    if (column == 1)
        //    {
        //        // 設定中のアイテムインデックスを取得
        //        selectedItemIndex = comboBox1.SelectedIndex;
        //        // 設定されたアイテムが被らないようにボックスから削除
        //        if (selectedItemIndex != 0)
        //        {
        //            comboBox2.Items.RemoveAt(selectedItemIndex);
        //        }
        //    }
        //}

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 入力ミスなどを検知
        /// </summary>
        /// <returns></returns>
        public int Check()
        {
            // 陸軍タブ
            if (checkBox1.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    ErrorMessage("[陸軍] - [師団テンプレートの新規作成] - [ユニット名]が無効です。");
                    return 1;
                }

                if (comboBox1.SelectedItem == null ||
                    comboBox2.SelectedItem == null ||
                    comboBox3.SelectedItem == null ||
                    comboBox4.SelectedItem == null ||
                    comboBox5.SelectedItem == null)
                {
                    ErrorMessage("[陸軍] - [師団テンプレートの新規作成] - [支援中隊]の設定が無効です。支援中隊を設定しない場合、\"None\"を指定してください。");
                    return 1;
                }

                if (comboBox6.SelectedItem == null ||
                    comboBox7.SelectedItem == null ||
                    comboBox8.SelectedItem == null ||
                    comboBox9.SelectedItem == null ||
                    comboBox10.SelectedItem == null ||
                    comboBox11.SelectedItem == null ||
                    comboBox12.SelectedItem == null ||
                    comboBox13.SelectedItem == null ||
                    comboBox14.SelectedItem == null ||
                    comboBox15.SelectedItem == null ||
                    comboBox16.SelectedItem == null ||
                    comboBox17.SelectedItem == null ||
                    comboBox18.SelectedItem == null ||
                    comboBox19.SelectedItem == null ||
                    comboBox20.SelectedItem == null ||
                    comboBox21.SelectedItem == null ||
                    comboBox22.SelectedItem == null ||
                    comboBox23.SelectedItem == null ||
                    comboBox24.SelectedItem == null ||
                    comboBox25.SelectedItem == null ||
                    comboBox26.SelectedItem == null ||
                    comboBox27.SelectedItem == null ||
                    comboBox28.SelectedItem == null ||
                    comboBox29.SelectedItem == null ||
                    comboBox30.SelectedItem == null)
                {
                    ErrorMessage("[陸軍] - [師団テンプレートの新規作成] - [戦闘大隊]の設定が無効です。戦闘大隊を設定しない場合、\"None\"を指定してください。");
                    return 1;
                }
            }

            // 海軍タブ
            if (checkBox2.Checked == true)
            {

            }

            // 空軍タブ
            if (checkBox3.Checked == true)
            {
                if (comboBox31.SelectedItem == null)
                {
                    ErrorMessage("[空軍] - [配置するユニット]が指定されていません。");
                    return 1;
                }
            }

            MessageBox.Show("入力ミスのチェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// データの変数化処理
        /// </summary>
        public void DataAssignment()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBox(checkBox1.Checked, 0);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBox(checkBox2.Checked, 1);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBox(checkBox3.Checked, 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cResult = Check();
            if (cResult == 1)
                return;

            else
                this.Close();
        }
    }
}
