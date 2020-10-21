using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            var assembly = Assembly.GetExecutingAssembly();
            var fileversioninfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            label4.Text = assembly.GetName().Version.ToString();
            label5.Text = fileversioninfo.LegalCopyright;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Zakki0925224/HoI4-Modding-Supporter");
        }
    }
}
