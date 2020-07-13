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
        }

        // 配色変更関数
        public void colorChange()
        {
            int r = (int)numericUpDown1.Value;
            int g = (int)numericUpDown2.Value;
            int b = (int)numericUpDown3.Value;
            Color color = Color.FromArgb(r, g, b);
            panel2.BackColor = color;
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
    }
}
