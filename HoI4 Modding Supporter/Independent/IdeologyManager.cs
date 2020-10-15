using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            IdeologyCheck();
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

        /// <summary>
        /// イデオロギーの適用状況を調査して出力
        /// </summary>
        public void IdeologyCheck()
        {
            Resource resource = new Resource();

            string ideologyFilePath = Properties.Settings.Default.moddir + @"\common\ideologies\00_ideologies.txt";

            if (File.Exists(ideologyFilePath) == false)
            {
                listBox1.Items.Add(resource.properNoun["neutrality"]);
                listBox1.Items.Add(resource.properNoun["democratic"]);
                listBox1.Items.Add(resource.properNoun["fascism"]);
                listBox1.Items.Add(resource.properNoun["communism"]);
            }
        }

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// ファイルをコピー
        /// </summary>
        /// <returns></returns>
        public int FileCopy(string source, string dest)
        {
            try
            {
                File.Copy(source, dest, true);
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException ||
                    e is ArgumentException ||
                    e is ArgumentNullException ||
                    e is PathTooLongException ||
                    e is DirectoryNotFoundException ||
                    e is FileNotFoundException ||
                    e is IOException ||
                    e is NotSupportedException)
                {
                    ErrorMessage(e.Message);
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// 新しいフォルダーを作成
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public int FolderCreate(string folderPath)
        {
            try
            {
                Directory.CreateDirectory(folderPath);
            }
            catch (Exception e)
            {
                if (e is IOException ||
                    e is UnauthorizedAccessException ||
                    e is ArgumentException ||
                    e is ArgumentNullException ||
                    e is PathTooLongException ||
                    e is DirectoryNotFoundException ||
                    e is NotSupportedException)
                {
                    ErrorMessage(e.Message);
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// 新しいファイルを作成
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int FileCreate(string filePath)
        {
            try
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException ||
                    e is ArgumentException ||
                    e is ArgumentNullException ||
                    e is PathTooLongException ||
                    e is DirectoryNotFoundException ||
                    e is IOException ||
                    e is NotSupportedException)
                {
                    ErrorMessage(e.Message);
                    return 1;
                }
            }

            return 0;
        }
    }
}
