using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
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
        /// <param name="source">コピー元ファイルパス</param>
        /// <param name="dest">コピー先ファイルパス</param>
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
        /// <param name="folderPath">フォルダーパス</param>
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
        /// <param name="filePath">ファイルパス</param>
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

        /// <summary>
        /// 末尾にテキストを一行書き込む
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="text">書き込みしたいテキスト</param>
        /// <param name="parm">true -> 既存テキストを残したまま末尾に追加<br/>false -> 既存テキストを抹消した後に追加</param>
        /// <param name="enc">エンコード指定（未指定でも可）<br/>UTF-8が指定された場合はBOM付きになる</param>
        /// <returns></returns>
        public int FileWriteLine(string path, string text, bool parm, Encoding enc = null)
        {
            
            try
            {
                StreamWriter sw;

                if (enc == null)
                    sw = new StreamWriter(path, parm);
                else
                    sw = new StreamWriter(path, parm, enc);

                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is PathTooLongException ||
                                      e is SecurityException ||
                                      e is ObjectDisposedException)
            {
                mbs.ErrorMessage(e.Message);
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// 末尾にテキストを書き込む
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="text">書き込みしたいテキスト</param>
        /// <param name="parm">true -> 既存テキストを残したまま末尾に追加<br/>false -> 既存テキストを抹消した後に追加</param>
        /// <param name="enc">エンコード指定（未指定でも可）<br/>UTF-8が指定された場合はBOM付きになる</param>
        /// <returns></returns>
        public int FileWrite(string path, string text, bool parm, Encoding enc = null)
        {

            try
            {
                StreamWriter sw;

                if (enc == null)
                    sw = new StreamWriter(path, parm);
                else
                    sw = new StreamWriter(path, parm, enc);

                sw.Write(text);
                sw.Close();
            }
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is PathTooLongException ||
                                      e is SecurityException ||
                                      e is ObjectDisposedException ||
                                      e is NotSupportedException)
            {
                mbs.ErrorMessage(e.Message);
                return 1;
            }

            return 0;
        }
    }
}
