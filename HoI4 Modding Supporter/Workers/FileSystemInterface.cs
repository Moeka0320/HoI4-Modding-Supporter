using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoI4_Modding_Supporter.Workers
{
    /// <summary>
    /// ファイル・フォルダを操作する処理
    /// </summary>
    class FileSystemInterface
    {
        MessageBoxShower mbs = new MessageBoxShower();

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
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is PathTooLongException ||
                                      e is DirectoryNotFoundException ||
                                      e is FileNotFoundException ||
                                      e is IOException ||
                                      e is NotSupportedException)
            {
                mbs.ErrorMessage(e.Message);
                return 1;
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
            catch (Exception e) when (e is IOException ||
                                      e is UnauthorizedAccessException ||
                                      e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is PathTooLongException ||
                                      e is DirectoryNotFoundException ||
                                      e is NotSupportedException)
            {
                mbs.ErrorMessage(e.Message);
                return 1;
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
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is PathTooLongException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is NotSupportedException)
            {
                mbs.ErrorMessage(e.Message);
                return 1;
            }

            return 0;
        }
    }
}
