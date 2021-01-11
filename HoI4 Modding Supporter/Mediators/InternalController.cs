using HoI4_Modding_Supporter.Workers;
using System.Text;

namespace HoI4_Modding_Supporter.Mediators
{
    /// <summary>
    /// アプリケーションによって呼び出される処理
    /// </summary>
    static class InternalController
    {

        // MessageBoxShower.cs

        /// <summary>
        /// エラーメッセージを表示
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public static void ErrorMessageShow(string message)
        {
            MessageBoxShower.ErrorMessage(message);
        }

        /// <summary>
        /// インフォメーションメッセージを表示
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public static void InfoMessageShow(string message)
        {
            MessageBoxShower.InfoMessage(message);
        }

        /// <summary>
        /// その他のメッセージ（定型文）を表示
        /// </summary>
        /// <param name="type">どのメッセージを表示するか</param>
        public static void MessageShow(string type)
        {
            switch (type)
            {
                case "GenerateStopped":
                    MessageBoxShower.GenerateStoppedMessage();
                    break;
            }
        }

        // FileSystemInterface.cs

        /// <summary>
        /// ファイルをコピー
        /// </summary>
        /// <param name="source">コピー元ファイルパス</param>
        /// <param name="dest">コピー先ファイルパス</param>
        public static int FileCopy(string source, string dest)
        {
            return FileSystemInterface.FileCopy(source, dest);
        }

        /// <summary>
        /// 新しいフォルダーを作成
        /// </summary>
        /// <param name="folderPath">フォルダーパス</param>
        /// <returns></returns>
        public static int FolderCreate(string folderPath)
        {
            return FileSystemInterface.FolderCreate(folderPath);
        }

        /// <summary>
        /// 新しいファイルを作成
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns></returns>
        public static int FileCreate(string filePath)
        {
            return FileSystemInterface.FileCreate(filePath);
        }

        /// <summary>
        /// 末尾にテキストを一行書き込む
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="text">書き込みしたいテキスト</param>
        /// <param name="parm">true -> 既存テキストを残したまま末尾に追加<br/>false -> 既存テキストを抹消した後に追加</param>
        /// <param name="enc">エンコード指定（未指定でも可）<br/>UTF-8が指定された場合はBOM付きになる</param>
        /// <returns></returns>
        public static int FileWriteLine(string path, string text, bool parm, Encoding enc = null)
        {
            return FileSystemInterface.FileWriteLine(path, text, parm, enc);
        }

        /// <summary>
        /// 末尾にテキストを書き込む
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="text">書き込みしたいテキスト</param>
        /// <param name="parm">true -> 既存テキストを残したまま末尾に追加<br/>false -> 既存テキストを抹消した後に追加</param>
        /// <param name="enc">エンコード指定（未指定でも可）<br/>UTF-8が指定された場合はBOM付きになる</param>
        /// <returns></returns>
        public static int FileWrite(string path, string text, bool parm, Encoding enc = null)
        {
            return FileSystemInterface.FileWrite(path, text, parm, enc);
        }
    }
}
