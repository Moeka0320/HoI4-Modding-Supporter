using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter.Workers
{
    /// <summary>
    /// 入力をチェック
    /// </summary>
    static class InputChecker
    {
        /// <summary>
        /// hoi4ディレクトリ・modディレクトリチェック
        /// </summary>
        /// <returns></returns>
        public static int DirChecker()
        {
            if (Properties.Settings.Default.hoi4dir == "")
            {
                MessageBoxShower.ErrorMessage("HoI4本体のディレクトリが設定されていません。\n[ツール] - [設定]からディレクトリパスを設定してください。");
                return 1;
            }

            if (Properties.Settings.Default.moddir == "")
            {
                MessageBoxShower.ErrorMessage("Modディレクトリが設定されていません。\n[ツール] - [設定]からディレクトリパスを設定してください。");
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
        public static int MainGenrateChecker(List<TextBox> textBoxes, List<ComboBox> comboBoxes, List<CheckBox> checkBoxes)
        {
            string inputPlace;

            if (DirChecker() == 1)
                return 1;

            // 国家タグ
            inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[0].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[0].Text, inputPlace) == 1)
                return 1;

            if (textBoxes[0].Text.Length != 3)
            {
                // テキスト文字数が3文字ではない
                MessageBoxShower.ErrorMessage($"{inputPlace}は3文字で構成されている必要があります。");
                return 1;
            }

            if (!char.IsUpper(textBoxes[0].Text[0]) || !char.IsUpper(textBoxes[0].Text[1] ) || !char.IsUpper(textBoxes[0].Text[2]))
            {
                // すべての文字が大文字ではない
                MessageBoxShower.ErrorMessage($"{inputPlace}はすべての文字が大文字で構成されている必要があります。");
                return 1;
            }

            if (HaveInvaliedChars(textBoxes[0].Text) == true)
            {
                // ファイル名に使用できない文字が使用されている
                MessageBoxShower.ErrorMessage($"{inputPlace}に使用できない文字が使用されています。");
                return 1;
            }

            // Modの接頭語
            inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[1].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[1].Text, inputPlace) == 1)
                return 1;

            if (textBoxes[1].Text.IndexOf(" ") != -1)
            {
                // テキストにスペースが含まれている
                MessageBoxShower.ErrorMessage($"{inputPlace}にスペースを含めることはできません。");
                return 1;
            }

            if (HaveInvaliedChars(textBoxes[1].Text) == true)
            {
                MessageBoxShower.ErrorMessage($"{inputPlace}に使用できない文字が使用されています。");
                return 1;
            }

            // 国名（内部処理用）
            inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[2].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[2].Text, inputPlace) == 1)
                return 1;

            if (HaveInvaliedChars(textBoxes[2].Text) == true)
            {
                MessageBoxShower.ErrorMessage($"{inputPlace}に使用できない文字が使用されています。");
                return 1;
            }

            // 国名
            for (int cnt = 3; cnt <= 14; cnt++)
            {
                inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString());

                if (textBoxes[cnt].Enabled == true && IsNullOrWhiteSpace(textBoxes[cnt].Text, inputPlace) == 1)
                {
                    return 1;
                }
            }

            // 国旗
            for (int cnt = 15; cnt <= 26; cnt++)
            {
                inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString());

                if (textBoxes[cnt].Enabled == true && textBoxes[cnt].Text != "")
                {
                    // ファイルチェック
                    if (File.Exists(textBoxes[cnt].Text) == false)
                    {
                        MessageBoxShower.ErrorMessage($"{inputPlace}で指定されたファイルが存在しません。");
                        return 1;
                    }

                    // 拡張子チェック
                    if (Path.GetExtension(textBoxes[cnt].Text) != ".tga")
                    {
                        MessageBoxShower.ErrorMessage($"{inputPlace}で指定されたファイルの種類には対応していません。");
                        return 1;
                    }
                }
            }

            // 政党名
            for (int cnt = 27; cnt <= 34; cnt++)
            {
                inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString());

                // 政党名を指定しない場合は通称名・正式名の両方を空欄にする必要がある

                // 27, 29, 31, 33のテキストボックス
                if (cnt % 2 == 1)
                {
                    if (textBoxes[cnt].Text == "" || textBoxes[cnt + 1].Text == "")
                    {
                        if ((textBoxes[cnt].Text == "" && textBoxes[cnt].Text == "") == false)
                        {
                            MessageBoxShower.ErrorMessage($"{InputPlaceResponder.ReturnMainInputPlace(textBoxes[cnt].Tag.ToString())}または{InputPlaceResponder.ReturnMainInputPlace(textBoxes[cnt + 1].Tag.ToString())}の片方のみを空欄にすることはできません。\n{inputPlace}を設定しない場合、[表示名]と[正式名]の両方を空欄にする必要があります。");
                            return 1;
                        }
                    }
                }

                if (textBoxes[cnt].Enabled == true && IsNullOrWhiteSpace(textBoxes[cnt].Text, inputPlace) == 1)
                {
                    return 1;
                }
            }

            // 各種設定
            // 宗主国の国家タグ
            if (checkBoxes[0].Checked == true)
            {
                inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[35].Tag.ToString());

                if (IsNullOrWhiteSpace(textBoxes[35].Text, inputPlace) == 1)
                    return 1;

                if (textBoxes[35].Text.Length != 3)
                {
                    // テキスト文字数が3文字ではない
                    MessageBoxShower.ErrorMessage($"{inputPlace}は3文字で構成されている必要があります。");
                    return 1;
                }

                if (!char.IsUpper(textBoxes[35].Text[0]) || !char.IsUpper(textBoxes[35].Text[1]) || !char.IsUpper(textBoxes[35].Text[2]))
                {
                    // すべての文字が大文字ではない
                    MessageBoxShower.ErrorMessage($"{inputPlace}はすべての文字が大文字で構成されている必要があります。");
                    return 1;
                }

                if (HaveInvaliedChars(textBoxes[35].Text) == true)
                {
                    // ファイル名に使用できない文字が使用されている
                    MessageBoxShower.ErrorMessage($"{inputPlace}に使用できない文字が使用されています。");
                    return 1;
                }
            }

            // 汎用顔グラフィック
            inputPlace = InputPlaceResponder.ReturnMainInputPlace(comboBoxes[0].Tag.ToString());

            if (comboBoxes[0].SelectedItem == null)
            {
                MessageBoxShower.ErrorMessage($"{inputPlace}が設定されていません。");
                return 1;
            }

            // 政党支持率の合計が100%ではない場合
            inputPlace = InputPlaceResponder.ReturnMainInputPlace(textBoxes[36].Tag.ToString());

            if (int.Parse(textBoxes[36].Text) != 100)
            {
                MessageBoxShower.ErrorMessage($"{inputPlace}が100%ではありません。各政党支持率の合計が100%になるように調整してください。");
                return 1;
            }

            // イデオロギー
            inputPlace = InputPlaceResponder.ReturnMainInputPlace(comboBoxes[1].Tag.ToString());

            if (comboBoxes[1].SelectedItem == null)
            {
                MessageBoxShower.ErrorMessage($"{inputPlace}が設定されていません。");
                return 1;
            }

            MessageBoxShower.InfoMessage("入力チェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// FactionSettings.csの入力チェック処理
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns></returns>
        public static int FactionSettingsChecker(List<TextBox> textBoxes)
        {
            string inputPlace;

            if (DirChecker() == 1)
                return 1;

            inputPlace = InputPlaceResponder.ReturnFactionSettingsInputPlace(textBoxes[0].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[0].Text, inputPlace) == 1)
                return 1;

            inputPlace = InputPlaceResponder.ReturnFactionSettingsInputPlace(textBoxes[1].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[1].Text, inputPlace) == 1)
                return 1;

            MessageBoxShower.InfoMessage("入力チェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// NationalLeaderSettings.csの入力チェック処理
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <param name="richTextBoxes"></param>
        /// <param name="comboBoxes"></param>
        /// <returns></returns>
        public static int NationalLeaderSettingsChecker(List<TextBox> textBoxes, List<RichTextBox> richTextBoxes, List<ComboBox> comboBoxes)
        {
            // TODO: 画像ファイルパスの入力チェック

            string inputPlace;

            if (DirChecker() == 1)
                return 1;

            inputPlace = InputPlaceResponder.ReturnNationalLeaderSettingsInputPlace(textBoxes[0].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[0].Text, inputPlace) == 1)
                return 1;

            inputPlace = InputPlaceResponder.ReturnNationalLeaderSettingsInputPlace(richTextBoxes[0].Tag.ToString());

            if (IsNullOrWhiteSpace(richTextBoxes[0].Text, inputPlace) == 1)
                return 1;

            inputPlace = InputPlaceResponder.ReturnNationalLeaderSettingsInputPlace(textBoxes[1].Tag.ToString());

            if (IsNullOrWhiteSpace(textBoxes[1].Text, inputPlace) == 1)
                return 1;

            if (textBoxes[1].Text != "")
            {
                // ファイルチェック
                if (!File.Exists(textBoxes[1].Text))
                {
                    MessageBoxShower.ErrorMessage($"{inputPlace}で指定されたファイルが存在しません。");
                    return 1;
                }

                // 拡張子チェック
                if (Path.GetExtension(textBoxes[1].Text) != ".dds")
                {
                    MessageBoxShower.ErrorMessage($"{inputPlace}で指定されたファイルの種類には対応していません。");
                    return 1;
                }
            }

            inputPlace = InputPlaceResponder.ReturnNationalLeaderSettingsInputPlace(comboBoxes[0].Tag.ToString());

            if (comboBoxes[0].SelectedItem == null || comboBoxes[1].SelectedItem == null)
            {
                MessageBoxShower.ErrorMessage($"{inputPlace}が設定されていません。");
                return 1;
            }

            MessageBoxShower.InfoMessage("入力チェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// CustomIdeologiesSettings.csの入力チェック処理
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns></returns>
        public static int CustomIdeologiesSettingsChecker(List<TextBox> viewNameTextBoxList, 
                                                   List<TextBox> eventViewNameTextBoxList, 
                                                   List<TextBox> aliasNameTextBoxList, 
                                                   List<TextBox> partyFullNameTextBoxList, 
                                                   List<TextBox> partyAliasNameTextBoxList,
                                                   List<TextBox> bigFlagPathTextBoxList,
                                                   List<TextBox> mediumFlagPathTextBoxList,
                                                   List<TextBox> smallFlagPathTextBoxList)
        {
            // TODO: 国旗ファイルパスの入力チェック

            for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
            {
                // 国名
                if (IsNullOrWhiteSpace(viewNameTextBoxList[cnt].Text, $"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国名] - [表示名]") == 1)
                    return 1;

                if (IsNullOrWhiteSpace(eventViewNameTextBoxList[cnt].Text, $"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国名] - [正式名]") == 1)
                    return 1;

                if (IsNullOrWhiteSpace(aliasNameTextBoxList[cnt].Text, $"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国名] - [通称名]") == 1)
                    return 1;

                // 政党名
                if (partyFullNameTextBoxList[cnt].Text == "" || partyAliasNameTextBoxList[cnt].Text == "")
                {
                    if ((partyFullNameTextBoxList[cnt].Text == "" && partyAliasNameTextBoxList[cnt].Text == "") == false)
                    {
                        MessageBoxShower.ErrorMessage($"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [{Properties.Settings.Default.customIdeologiesName[cnt]}政党名]を設定しない場合、通称名と正式名の両方を空欄にする必要があります。");
                        return 1;
                    }
                }

                // 国旗
                if (bigFlagPathTextBoxList[cnt].Text != "")
                {
                    // ファイルチェック
                    if (!File.Exists(bigFlagPathTextBoxList[cnt].Text))
                    {
                        MessageBoxShower.ErrorMessage($"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国旗] - [大]で指定されたファイルが存在しません。");
                        return 1;
                    }

                    // 拡張子チェック
                    if (Path.GetExtension(bigFlagPathTextBoxList[cnt].Text) != ".dds")
                    {
                        MessageBoxShower.ErrorMessage($"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国旗] - [大]で指定されたファイルの種類には対応していません。");
                        return 1;
                    }
                }

                if (mediumFlagPathTextBoxList[cnt].Text != "")
                {
                    // ファイルチェック
                    if (!File.Exists(mediumFlagPathTextBoxList[cnt].Text))
                    {
                        MessageBoxShower.ErrorMessage($"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国旗] - [中]で指定されたファイルが存在しません。");
                        return 1;
                    }

                    // 拡張子チェック
                    if (Path.GetExtension(mediumFlagPathTextBoxList[cnt].Text) != ".dds")
                    {
                        MessageBoxShower.ErrorMessage($"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国旗] - [中]で指定されたファイルの種類には対応していません。");
                        return 1;
                    }
                }

                if (smallFlagPathTextBoxList[cnt].Text != "")
                {
                    // ファイルチェック
                    if (!File.Exists(smallFlagPathTextBoxList[cnt].Text))
                    {
                        MessageBoxShower.ErrorMessage($"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国旗] - [小]で指定されたファイルが存在しません。");
                        return 1;
                    }

                    // 拡張子チェック
                    if (Path.GetExtension(smallFlagPathTextBoxList[cnt].Text) != ".dds")
                    {
                        MessageBoxShower.ErrorMessage($"[{Properties.Settings.Default.customIdeologiesName[cnt]}] - [国旗] - [小]で指定されたファイルの種類には対応していません。");
                        return 1;
                    }
                }
            }

            MessageBoxShower.InfoMessage("入力チェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// ファイル名に使用できない文字が存在するかどうかを判定
        /// </summary>
        /// <returns>使用できない文字が存在しない：false<br/>存在する：true</returns>
        private static bool HaveInvaliedChars(string text)
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
        private static int IsNullOrWhiteSpace(string text, string inputPlace)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBoxShower.ErrorMessage($"{inputPlace}が入力されていないか、スペースのみで構成されています。");
                return 1;
            }
            else
                return 0;
        }
    }
}
