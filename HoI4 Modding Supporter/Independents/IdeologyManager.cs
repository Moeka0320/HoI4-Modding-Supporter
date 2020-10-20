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
using HoI4_Modding_Supporter.Parsers;

namespace HoI4_Modding_Supporter.Independent
{
    public partial class IdeologyManager : Form
    {
        public IdeologyManager()
        {
            InitializeComponent();
            ControlView();
            IdeologyCheck();
        }

        /// <summary>
        /// フォーム上のコントロールを一元管理
        /// </summary>
        public void ControlView()
        {
            Resource rs = new Resource();

        }

        /// <summary>
        /// イデオロギーの適用状況を調査して出力
        /// </summary>
        public void IdeologyCheck()
        {
            Resource rs = new Resource();
            IdeologyFileParser ifp = new IdeologyFileParser();

            string ideologyFilePath = Properties.Settings.Default.moddir + @"\common\ideologies\00_ideologies.txt";

            if (File.Exists(ideologyFilePath) == false)
            {
                listBox1.Items.Add(rs.properNoun["neutrality"]);
                listBox1.Items.Add(rs.properNoun["democratic"]);
                listBox1.Items.Add(rs.properNoun["fascism"]);
                listBox1.Items.Add(rs.properNoun["communism"]);
            }
            else
            {
                // テキストファイルを精査
                ifp.Parse(ideologyFilePath);
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
