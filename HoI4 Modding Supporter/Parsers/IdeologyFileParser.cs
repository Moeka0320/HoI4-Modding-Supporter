using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoI4_Modding_Supporter.Parsers
{
    /// <summary>
    /// [MODFOLDER]/common/ideologies_00.txtの構文解析
    /// </summary>
    class IdeologyFileParser
    {
        private List<string> keywords = new List<string>
        {

        };

        /// <summary>
        /// 解析し、配列に整形して返す
        /// </summary>
        /// <param name="ideologyFilePath">[HOI4DIR OR MODDIR]/common/ideologies/ideologies_00.txt</param>
        public string[] Parse(string ideologyFilePath)
        {
            string rawText;

            try
            {
                StreamReader sr = new StreamReader(ideologyFilePath);

                rawText = sr.ReadToEnd();
                // 不要文字を削除しすべて一行に整形
                rawText = rawText.Replace("\n", string.Empty);
                rawText = rawText.Replace("\t", string.Empty);
                rawText = rawText.Replace(" ", string.Empty);
            }
            catch (Exception e)
            {
                if (e is ArgumentException ||
                    e is ArgumentNullException ||
                    e is FileNotFoundException ||
                    e is DirectoryNotFoundException ||
                    e is IOException)
                    return null;
            }
        }
    }
}
