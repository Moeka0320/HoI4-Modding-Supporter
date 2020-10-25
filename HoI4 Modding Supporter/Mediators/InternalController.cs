using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HoI4_Modding_Supporter.Workers;

namespace HoI4_Modding_Supporter.Mediators
{
    /// <summary>
    /// アプリケーションによって呼び出される処理
    /// </summary>
    class InternalController
    {
        MessageBoxShower msb = new MessageBoxShower();
        FileSystemInterface fsi = new FileSystemInterface();

        // MessageBoxShower.cs

        /// <summary>
        /// エラーメッセージを表示
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public void ErrorMessageShow(string message)
        {
            msb.ErrorMessage(message);
        }

        /// <summary>
        /// インフォメーションメッセージを表示
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public void InfoMessageShow(string message)
        {
            msb.InfoMessage(message);
        }

        /// <summary>
        /// その他のメッセージ（定型文）を表示
        /// </summary>
        /// <param name="type">どのメッセージを表示するか</param>
        public void MessageShow(string type)
        {
            switch (type)
            {
                case "GenerateStopped":
                    msb.GenerateStoppedMessage();
                    break;
            }
        }

        // FileSystemInterface.cs

        /// <summary>
        /// ファイルをコピー
        /// </summary>
        /// <param name="source">コピー元ファイルパス</param>
        /// <param name="dest">コピー先ファイルパス</param>
        public int FileCopy(string source, string dest)
        {
            if (fsi.FileCopy(source, dest) == 0)
                return 0;
            else
                return 1;
        }

        /// <summary>
        /// 新しいフォルダーを作成
        /// </summary>
        /// <param name="folderPath">フォルダーパス</param>
        /// <returns></returns>
        public int FolderCreate(string folderPath)
        {
            if (fsi.FolderCreate(folderPath) == 0)
                return 0;
            else
                return 1;
        }

        /// <summary>
        /// 新しいファイルを作成
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns></returns>
        public int FileCreate(string filePath)
        {
            if (fsi.FileCreate(filePath) == 0)
                return 0;
            else
                return 1;
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
            if (fsi.FileWriteLine(path, text, parm, enc) == 0)
                return 0;
            else
                return 1;
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
            if (fsi.FileWrite(path, text, parm, enc) == 0)
                return 0;
            else
                return 1;
        }
    }
}
