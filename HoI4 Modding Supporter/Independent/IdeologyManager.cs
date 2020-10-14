using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter.Independent
{
    public partial class IdeologyManager : Form
    {
        public IdeologyManager()
        {
            InitializeComponent();
            IdeologyStatusReflect();
        }

        /// <summary>
        /// イデオロギーが無効化されているかどうかを出力
        /// </summary>
        public void IdeologyStatusReflect()
        {
            string trueLabel = "TRUE";
            string falseLabel = "FALSE";
            string nullLabel = "NULL";
            Color trueColor = Color.Green;
            Color falseColor = Color.Red;
            Color nullColor = Color.Black;

            if (Properties.Settings.Default.neutralityDisabled == true)
            {
                label7.Text = trueLabel;
                label7.ForeColor = trueColor;
            }
            else
            {
                label7.Text = falseLabel;
                label7.ForeColor = falseColor;
            }

            if (Properties.Settings.Default.democraticDisabled == true)
            {
                label8.Text = trueLabel;
                label8.ForeColor = trueColor;
            }
            else
            {
                label8.Text = falseLabel;
                label8.ForeColor = falseColor;
            }

            if (Properties.Settings.Default.fascismDisabled == true)
            {
                label9.Text = trueLabel;
                label9.ForeColor = trueColor;
            }
            else
            {
                label9.Text = falseLabel;
                label9.ForeColor = falseColor;
            }

            if (Properties.Settings.Default.communismDisabled == true)
            {
                label10.Text = trueLabel;
                label10.ForeColor = trueColor;
            }
            else
            {
                label10.Text = falseLabel;
                label10.ForeColor = falseColor;
            }
        }
    }
}
