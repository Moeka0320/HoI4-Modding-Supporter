using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace HoI4_Modding_Supporter.Workers
{
    /// <summary>
    /// 入力をチェック
    /// </summary>
    class InputChecker
    {
        MessageBoxShower mbs = new MessageBoxShower();
        InputPlaceResponder ipr = new InputPlaceResponder();

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
            string inputPlace;

            if (DirChecker() == 1)
                return 1;

            // 国家タグ
            inputPlace = ipr.ReturnMainInputPlace(textBoxes[0].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[0].Text, inputPlace) == 1)
                return 1;

            if (textBoxes[0].Text.Length != 3)
            {
                // テキスト文字数が3文字ではない
                mbs.ErrorMessage(inputPlace + "は3文字で構成されている必要があります。");
                return 1;
            }

            if (!char.IsUpper(textBoxes[0].Text[0]) || !char.IsUpper(textBoxes[0].Text[1] ) || !char.IsUpper(textBoxes[0].Text[2]))
            {
                // すべての文字が大文字ではない
                mbs.ErrorMessage(inputPlace + "はすべての文字が大文字で構成されている必要があります。");
                return 1;
            }

            if (HaveInvaliedChars(textBoxes[0].Text) == true)
            {
                // ファイル名に使用できない文字が使用されている
                mbs.ErrorMessage(inputPlace + "に使用できない文字が使用されています。");
                return 1;
            }

            // Modの接頭語
            inputPlace = ipr.ReturnMainInputPlace(textBoxes[1].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[1].Text, inputPlace) == 1)
                return 1;

            if (textBoxes[1].Text.IndexOf(" ") != -1)
            {
                // テキストにスペースが含まれている
                mbs.ErrorMessage(inputPlace + "にスペースを含めることはできません。");
                return 1;
            }

            if (HaveInvaliedChars(textBoxes[1].Text) == true)
            {
                mbs.ErrorMessage(inputPlace + "に使用できない文字が使用されています。");
                return 1;
            }

            // 国名（内部処理用）
            inputPlace = ipr.ReturnMainInputPlace(textBoxes[2].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[2].Text, inputPlace) == 1)
                return 1;

            if (HaveInvaliedChars(textBoxes[2].Text) == true)
            {
                mbs.ErrorMessage(inputPlace + "に使用できない文字が使用されています。");
                return 1;
            }

            // 停止フラグ
            int result = 0;

            // 国名
            for (int cnt = 3; cnt <= 14; cnt++)
            {
                inputPlace = ipr.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString());

                if (textBoxes[cnt].Enabled == true && IsNullOrWhiteSpace(textBoxes[cnt].Text, inputPlace) == 1)
                {
                    result = 1;
                    break;
                }
            }

            if (result == 1)
                return 1;

            // 国旗
            for (int cnt = 15; cnt <= 26; cnt++)
            {
                inputPlace = ipr.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString());

                // ファイルチェック
                if (textBoxes[cnt].Enabled == true && textBoxes[cnt].Text != "")
                    if (File.Exists(textBoxes[cnt].Text) == false)
                    {
                        mbs.ErrorMessage(inputPlace + "で指定されたファイルが存在しません。");
                        result = 1;
                        break;
                    }

                // 拡張子チェック
                if (Path.GetExtension(textBoxes[cnt].Text) != ".tga")
                {
                    mbs.ErrorMessage(inputPlace + "で指定されたファイルの種類には対応していません。");
                    result = 1;
                    break;
                }
            }

            if (result == 1)
                return 1;


            // 政党名
            for (int cnt = 27; cnt <= 34; cnt++)
            {
                inputPlace = ipr.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString());

                // 政党名を指定しない場合は通称名・正式名の両方を空欄にする必要がある

                // 27, 29, 31, 33のテキストボックス
                if (cnt % 2 == 1)
                {
                    if (textBoxes[cnt].Text == "" || textBoxes[cnt + 1].Text == "")
                    {
                        if ((textBoxes[cnt].Text == "" && textBoxes[cnt].Text == "") == false)
                        {
                            mbs.ErrorMessage(ipr.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString()) + "または" + ipr.ReturnMainInputPlace(textBoxes[cnt + 1].Tag.ToString()) + "の片方のみを空欄にすることはできません。\n" + inputPlace + "を設定しない場合、[表示名]と[正式名]の両方を空欄にする必要があります。");
                            result = 1;
                            break;
                        }
                    }
                }

                if (textBoxes[cnt].Enabled == true && IsNullOrWhiteSpace(textBoxes[cnt].Text, inputPlace) == 1)
                {
                    result = 1;
                    break;
                }
            }

            if (result == 1)
                return 1;


            // 各種設定
            // 宗主国の国家タグ
            if (checkBoxes[0].Checked == true)
            {
                inputPlace = ipr.ReturnMainInputPlace(textBoxes[35].Tag.ToString());

                if (IsNullOrWhiteSpace(textBoxes[35].Text, inputPlace) == 1)
                    return 1;

                if (textBoxes[35].Text.Length != 3)
                {
                    // テキスト文字数が3文字ではない
                    mbs.ErrorMessage(inputPlace + "は3文字で構成されている必要があります。");
                    return 1;
                }

                if (!char.IsUpper(textBoxes[35].Text[0]) || !char.IsUpper(textBoxes[35].Text[1]) || !char.IsUpper(textBoxes[35].Text[2]))
                {
                    // すべての文字が大文字ではない
                    mbs.ErrorMessage(inputPlace + "はすべての文字が大文字で構成されている必要があります。");
                    return 1;
                }

                if (HaveInvaliedChars(textBoxes[35].Text) == true)
                {
                    // ファイル名に使用できない文字が使用されている
                    mbs.ErrorMessage(inputPlace + "に使用できない文字が使用されています。");
                    return 1;
                }
            }

            // 汎用顔グラフィック
            inputPlace = ipr.ReturnMainInputPlace(comboBoxes[0].Tag.ToString());

            if (comboBoxes[0].SelectedItem == null)
            {
                mbs.ErrorMessage(inputPlace + "が設定されていません。");
                return 1;
            }

            // 政党支持率の合計が100%ではない場合
            inputPlace = ipr.ReturnMainInputPlace(textBoxes[36].Tag.ToString());

            if (int.Parse(textBoxes[36].Text) != 100)
            {
                mbs.ErrorMessage(inputPlace + "が100%ではありません。各政党支持率の合計が100%になるように調整してください。");
                return 1;
            }

            // イデオロギー
            inputPlace = ipr.ReturnMainInputPlace(comboBoxes[1].Tag.ToString());

            if (comboBoxes[1].SelectedItem == null)
            {
                mbs.ErrorMessage(inputPlace + "が設定されていません。");
                return 1;
            }

            mbs.InfoMessage("入力チェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// FactionSettings.csの入力チェック処理
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns></returns>
        public int FactionSettingsChecker(List<TextBox> textBoxes)
        {
            string inputPlace;

            if (DirChecker() == 1)
                return 1;

            inputPlace = ipr.ReturnFactionSettingsInputPlace(textBoxes[0].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[0].Text, inputPlace) == 1)
                return 1;

            inputPlace = ipr.ReturnFactionSettingsInputPlace(textBoxes[1].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[1].Text, inputPlace) == 1)
                return 1;

            mbs.InfoMessage("入力チェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// ファイル名に使用できない文字が存在するかどうかを判定
        /// </summary>
        /// <returns>使用できない文字が存在しない：false<br/>存在する：true</returns>
        private bool HaveInvaliedChars(string text)
        {
            // ファイル名に使用できない文字を取得
            char[] invaliedChars = Path.GetInvalidFileNameChars();

            if (text.IndexOfAny(invaliedChars) < 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 指定された文字列がnullまたは空であるか、空白文字だけで構成されているかどうかを判定
        /// </summary>
        /// <param name="text"></param>
        /// <param name="inputPlace"></param>
        /// <returns></returns>
        private int IsNullOrWhiteSpace(string text, string inputPlace)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                mbs.ErrorMessage(inputPlace + "が入力されていないか、スペースのみで構成されています。");
                return 1;
            }
            else
                return 0;
        }
    }
}
