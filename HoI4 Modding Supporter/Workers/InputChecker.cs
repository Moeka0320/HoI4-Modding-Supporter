using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HoI4_Modding_Supporter.Workers
{
    /// <summary>
    /// 入力をチェック
    /// </summary>
    class InputChecker
    {
        MessageBoxShower mbs = new MessageBoxShower();

        /// <summary>
        /// hoi4ディレクトリ・modディレクトリチェック
        /// </summary>
        /// <returns></returns>
        public int DirChecker()
        {
            if (Properties.Settings.Default.hoi4dir == "")
            {
                mbs.ErrorMessage("HoI4本体のディレクトリが設定されていません。\n[ツール] - [設定]からディレクトリパスを設定してください。");
                return 1;
            }

            if (Properties.Settings.Default.moddir == "")
            {
                mbs.ErrorMessage("Modディレクトリが設定されていません。\n[ツール] - [設定]からディレクトリパスを設定してください。");
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Main.csの入力チェック処理
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <param name="comboBoxes"></param>
        /// <param name="checkBoxes"></param>
        /// <returns></returns>
        public int MainGenrateChecker(List<TextBox> textBoxes, List<ComboBox> comboBoxes, List<CheckBox> checkBoxes)
        {
            if (DirChecker() == 1)
                return 1;

            // 国家タグ
            if (string.IsNullOrWhiteSpace(textBoxes[0].Text))
            {
                // テキストボックスが空、またはスペースのみ
                mbs.ErrorMessage("国家タグが入力されていないか、スペースのみで構成されています。");
                return 1;
            }

            if (textBoxes[0].Text.Length > 3 || textBoxes[0].Text.Length < 3)
            {
                // テキスト文字数が3文字よりも多い、または3文字よりも少ない
                mbs.ErrorMessage("国家タグは3文字で構成されている必要があります。");
                return 1;
            }

            if (!char.IsUpper(textBoxes[0].Text[0]) || !char.IsUpper(textBoxes[0].Text[1] ) || !char.IsUpper(textBoxes[0].Text[2]))
            {
                // すべての文字が大文字ではない
                mbs.ErrorMessage("国家タグはすべての文字が大文字で構成されている必要があります。");
                return 1;
            }

            // Modの接頭語


            // 国名


            // 国旗


            // 政党名


            // 各種設定



            mbs.InfoMessage("入力チェックが完了しました。");
            return 0;
        }
    }
}
