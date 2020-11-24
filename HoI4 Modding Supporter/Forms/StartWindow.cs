using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter.Forms
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                button5.Enabled = true;
            else
                button5.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                button5.Enabled = true;
            else
                button5.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProjectEditorMainWindow pemw = new ProjectEditorMainWindow();
            pemw.Show();
        }
    }
}
