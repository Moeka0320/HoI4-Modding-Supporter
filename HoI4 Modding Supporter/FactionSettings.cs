using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter
{
    public partial class FactionSettings : Form
    {
        public FactionSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 入力ミスなどをチェック
        /// </summary>
        public int Check()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ErrorMessage("[陣営名（内部処理用）]が無効です。");
                return 1;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                ErrorMessage("[陣営名]が無効です。");
                return 1;
            }

            MessageBox.Show("入力ミスのチェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// データの変数化処理
        /// </summary>
        public void DataAssignment()
        {
            Variable variable = new Variable();

            variable.FactionInternalName = textBox1.Text.Replace(" ", "_");
            variable.FactionName = textBox2.Text;

            if (listBox1.Items.Count != 0)
            {
                variable.FactionParticipatingCountries = listBox1.Items.Cast<string>().ToArray();
            }
            else
            {
                variable.FactionParticipatingCountries = null;
            }
        }

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cResult = Check();
            if (cResult == 1)
            {
                return;
            }

            DataAssignment();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox3.Text) && listBox1.Items.IndexOf(textBox3.Text) == -1)
            {
                listBox1.Items.Add(textBox3.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
