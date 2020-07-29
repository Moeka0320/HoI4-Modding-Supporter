using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter
{
    class Generate
    {
        /// <summary>
        /// 国家の生成（ファイル書き込み処理）
        /// </summary>
        public int generateCountry()
        {
            Variable variable = new Variable();

            // MODFOLDER/commonディレクトリパス
            string commonDir = variable.moddir + @"\common";
            // MODFOLDER/common/countriesディレクトリパス
            string commonCountriesDir = commonDir + @"\countries";
            // MODFOLDER/common/countries/COUNTRY.txtファイルパス
            string commonCountryFilePath = commonCountriesDir + @"\" + variable.countryName + ".txt";
            // MODFOLDER/common/countries/colors.txtファイルパス
            string commonColorsFilePath = commonCountriesDir + @"\colors.txt";
            // HOI4FOLDER/common/countries/colors.txtファイルパス
            string colorsHoi4FilePath = variable.hoi4dir + @"\common\countries\colors.txt";
            // MODFOLDER/common/country_tagsディレクトリパス
            string commonCountry_tagsDir = commonDir + @"\country_tags";
            // MODFOLDER/common/country_tags/01_countries.txtファイルパス
            string commonCountriesFilePath = commonCountry_tagsDir + @"\01_countries.txt";
            // MODFOLDER/historyディレクトリパス
            string historyDir = variable.moddir + @"\history";
            // MODFOLDER/history/countriesディレクトリパス
            string historyCountriesDir = historyDir + @"\countries";
            // MODFOLDER/history/countries/TAG - COUNTRY.txtファイルパス
            string historyCountrisFilePath = historyCountriesDir + @"\" + variable.countryTag + " - " + variable.countryName + ".txt";
            // MODFOLDER/localisationディレクトリパス
            string localisationDir = variable.moddir + @"\localisation";
            // MODFOLDER/localisation/replaceディレクトリパス
            string localisationReplaceDir = localisationDir + @"\replace";
            // MODFOLDER/localisation/mod_countries_l_english.ymlファイルパス
            string localisationCountriesFilePath = localisationDir + @"\" + variable.modName + "_countries_l_english.yml";
            // MODFOLDER/localisation/mod_parties_l_english.ymlファイルパス
            string localisationPartiesFilePath = localisationDir + @"\" + variable.modName + "_parties_l_english.yml";
            // MODFOLDER/localisation/replace/MODNAME_countries_l_english.ymlファイルパス
            string localisationReplaceCountriesFilePath = localisationReplaceDir + @"\" + variable.modName + "_countries_l_english.yml";
            // MODFOLDER/localisation/replace/MODNAME_parties_l_english.ymlファイルパス
            string localisationReplacePartiesFilePath = localisationReplaceDir + @"\" + variable.modName + "_parties_l_english.yml";
            // MODFOLDER/gfxディレクトリパス
            string gfxDir = variable.moddir + @"\gfx";
            // MODFOLDER/gfx/flagsディレクトリパス
            string gfxFlagsDir = gfxDir + @"\flags";
            // MODFOLDER/gfx/flags/mediumディレクトリパス
            string gfxFlagsMediumDir = gfxFlagsDir + @"\medium";
            // MODFOLDER/gfx/flags/smallディレクトリパス
            string gfxFlagsSmallDir = gfxFlagsDir + @"\small";
            // 中道主義国旗（大・中・小）
            string n_Flags = gfxFlagsDir + @"\" + variable.countryTag + "_neutrality.tga";
            string n_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.countryTag + "_neutrality.tga";
            string n_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.countryTag + "_neutrality.tga";
            // 民主主義国旗（大・中・小）
            string d_Flags = gfxFlagsDir + @"\" + variable.countryTag + "_democratic.tga";
            string d_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.countryTag + "_democratic.tga";
            string d_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.countryTag + "_democratic.tga";
            // ファシズム国旗（大・中・小）
            string f_Flags = gfxFlagsDir + @"\" + variable.countryTag + "_fascism.tga";
            string f_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.countryTag + "_fascism.tga";
            string f_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.countryTag + "_fascism.tga";
            // 共産主義国旗（大・中・小）
            string c_Flags = gfxFlagsDir + @"\" + variable.countryTag + "_communism.tga";
            string c_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.countryTag + "_communism.tga";
            string c_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.countryTag + "_communism.tga";
            // 書き込み用エンコード指定（UTF-8 BOM付き）
            Encoding enc = Encoding.UTF8;


            // 0.国家タグがダブってないか確認する

            // HOI4DIR/history/countries/内で国家タグが一致するファイルがあるかを検索
            try
            {
                string[] hoi4Files = Directory.GetFileSystemEntries(variable.hoi4dir + @"\history\countries", variable.countryTag + " - *.txt");
                if (hoi4Files.Length != 0)
                {
                    errorMessage("国家タグ\"" + variable.countryTag + "\"は既に使用されています。別の国家タグを使用してください。");
                    return 1;
                }
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException ||
                    e is ArgumentException ||
                    e is ArgumentNullException ||
                    e is PathTooLongException ||
                    e is IOException ||
                    e is DirectoryNotFoundException)
                {
                    errorMessage(e.Message);
                    return 1;
                }
            }

            // MODDIR/history/countries内で国家タグが一致するファイルがあるかを検索
            if (Directory.Exists(historyDir) == true)
            {
                try
                {
                    string[] modFiles = Directory.GetFileSystemEntries(historyCountriesDir, variable.countryTag + "- *.txt");
                    if (modFiles.Length != 0)
                    {
                        errorMessage("国家タグ\"" + variable.countryTag + "\"は既に使用されています。別の国家タグを使用してください。");
                        return 1;
                    }
                }
                catch (Exception e)
                {
                    if (e is UnauthorizedAccessException ||
                        e is ArgumentException ||
                        e is ArgumentNullException ||
                        e is PathTooLongException ||
                        e is IOException ||
                        e is DirectoryNotFoundException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }

            // 1.国別ファイルの作成

            // MODFOLDER/common ディレクトリが存在しない場合
            if (Directory.Exists(commonDir) == false)
            {
                int fcResult = FolderCreate(commonDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // MODFOLDER/common/countries ディレクトリが存在しない場合
            if (Directory.Exists(commonCountriesDir) == false)
            {
                int fcResult = FolderCreate(commonCountriesDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../countries の中に国別ファイルを作成
            if (File.Exists(commonCountryFilePath) == true)
            {
                errorMessage("ファイル\"" + commonCountryFilePath + "\"は既に存在しています。\n別のファイル名を使用してください。");
                return 1;
            }
            else
            {
                int fcResult = FileCreate(commonCountryFilePath);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // COUNTRY.txtに書き込む
            try
            {
                StreamWriter sr = new StreamWriter(commonCountryFilePath, false);
                sr.WriteLine("graphical_culture = " + variable.graphicalCulture);
                sr.WriteLine("graphical_culture_2d = " + variable.graphicalCulture2d);
                sr.Close();
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException ||
                    e is IOException)
                {
                    errorMessage(e.Message);
                    return 1;
                }
            }

            // 2.色定義ファイルの作成

            // ../countries/colors.txtをhoi4本体ディレクトリからコピー
            // 既に存在する場合はそのファイルに書き込み
            if (File.Exists(commonColorsFilePath) == false)
            {
                int fcOutResult = FileCopy(colorsHoi4FilePath, commonColorsFilePath);
                if (fcOutResult == 1)
                {
                    return 1;
                }
            }


            // colors.txtに追記
            try
            {
                string color = variable.colorR + " " + variable.colorG + " " + variable.colorB;
                File.AppendAllText(commonColorsFilePath, "\n" + variable.countryTag + " = {\n\tcolor = rgb { " + color + " }\n\tcolor_ui = rgb { " + color + " }\n}");
            }
            catch (Exception e)
            {
                if (e is ArgumentException ||
                    e is ArgumentNullException ||
                    e is PathTooLongException ||
                    e is DirectoryNotFoundException ||
                    e is IOException ||
                    e is UnauthorizedAccessException ||
                    e is NotSupportedException ||
                    e is SecurityException)
                {
                    errorMessage(e.Message);
                    return 1;
                }
            }

            // 3.国家タグ定義ファイルの作成

            // ../common/country_tagsディレクトリが存在しない場合
            if (Directory.Exists(commonCountry_tagsDir) == false)
            {
                int fcResult = FolderCreate(commonCountry_tagsDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // 存在しない場合、../country_tags/01_countries.txtを作成
            if (File.Exists(commonCountriesFilePath) == false)
            {
                int fcResult = FileCreate(commonCountriesFilePath);
                if (fcResult == 1)
                {
                    return 1;
                }


                // 01_countries.txtを編集
                try
                {
                    StreamWriter sw = new StreamWriter(commonCountriesFilePath, false);
                    sw.WriteLine(variable.countryTag + " = \"countries/" + variable.countryName + ".txt\"");
                    sw.Close();
                }
                catch (Exception e)
                {
                    if (e is ObjectDisposedException ||
                        e is IOException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }
            else
            {
                try
                {
                    File.AppendAllText(commonCountriesFilePath, "\n" + variable.countryTag + " = \"countries/" + variable.countryName + ".txt\"");
                }
                catch (Exception e)
                {
                    if (e is ArgumentException ||
                        e is ArgumentNullException ||
                        e is PathTooLongException ||
                        e is DirectoryNotFoundException ||
                        e is IOException ||
                        e is UnauthorizedAccessException ||
                        e is NotSupportedException ||
                        e is SecurityException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }

            // 4.国家ファイルの作成

            // MODDIR/historyディレクトリが存在しない場合
            if (Directory.Exists(historyDir) == false)
            {
                int fcResult = FolderCreate(historyDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // MODDIR/hitsory/countriesディレクトリが存在しない場合
            if (Directory.Exists(historyCountriesDir) == false)
            {
                int fcResult = FolderCreate(historyCountriesDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // 国家ファイルを作成
            int fcOutResult2 = FileCreate(historyCountrisFilePath);
            if (fcOutResult2 == 1)
            {
                return 1;
            }


            // 作成された国家ファイルを編集
            try
            {
                StreamWriter sw = new StreamWriter(historyCountrisFilePath, false);
                // 首都州ID
                sw.WriteLine("capital = " + variable.stateIDWithCapital);
                // ユニットファイル（コメントアウト）
                sw.WriteLine("#obb = \"\"");
                // 研究スロット数
                sw.WriteLine("set_research_slots = " + variable.studySlot);
                // 安定度
                sw.WriteLine("set_stability = " + variable.stability);
                // 戦争協力度
                sw.WriteLine("set_war_support = " + variable.warCoop);
                // 輸送船
                sw.WriteLine("set_convoys = " + variable.transportShip);
                // 研究完了済み技術（コメントアウト）
                sw.WriteLine("#set_technology = {}");
                // 政党関連
                sw.WriteLine("set_politics = {");
                sw.WriteLine("\truling_party = " + variable.startIdeology);
                sw.WriteLine("\tlast_election = " + variable.lastElection);
                sw.WriteLine("\telection_frequency = " + variable.electionFrequency);
                if (variable.noElection == true)
                {
                    sw.WriteLine("\telections_allowed = no");
                }
                else
                {
                    sw.WriteLine("\telections_allowed = yes");
                }
                sw.WriteLine("}");
                // 政党支持率
                sw.WriteLine("set_popularities = {");
                sw.WriteLine("\tdemocratic = " + variable.d_Popularity);
                sw.WriteLine("\tfascism = " + variable.f_Popularity);
                sw.WriteLine("\tcommunism = " + variable.c_Popularity);
                sw.WriteLine("\tneutrality = " + variable.n_Popularity);
                sw.WriteLine("}");
                // 国家指導者の書き込みは現時点では未実装
                sw.Close();
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException ||
                    e is IOException)
                {
                    errorMessage(e.Message);
                    return 1;
                }
            }

            // 5.国名・政党名の設定

            // localisationディレクトリが存在しない場合
            if (Directory.Exists(localisationDir) == false)
            {
                int fcResult = FolderCreate(localisationDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../localisation/mod_countries_l_english.yml
            if (File.Exists(localisationCountriesFilePath) == false)
            {
                int fcResult = FileCreate(localisationCountriesFilePath);
                if (fcResult == 1)
                {
                    return 1;
                }

                try
                {
                    StreamWriter sw = new StreamWriter(localisationCountriesFilePath, false, enc);
                    sw.WriteLine("l_english:");
                    sw.WriteLine("");
                    sw.WriteLine(" " + variable.countryTag + "_neutrality:0 \"" + variable.n_ViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_neutrality_DEF:0 \"" + variable.n_EventViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_neutrality_ADJ:0 \"" + variable.n_AliasName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_democratic:0 \"" + variable.d_ViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_democratic_DEF:0 \"" + variable.d_EventViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_democratic_ADJ:0 \"" + variable.d_AliasName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_fascism:0 \"" + variable.f_ViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_fascism_DEF:0 \"" + variable.f_EventViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_fascism_ADJ:0 \"" + variable.f_AliasName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_communism:0 \"" + variable.c_ViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_communism_DEF:0 \"" + variable.c_EventViewName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_communism_ADJ:0 \"" + variable.c_AliasName + "\"");
                    sw.Close();
                }
                catch (Exception e)
                {
                    if (e is UnauthorizedAccessException ||
                        e is ArgumentException ||
                        e is ArgumentNullException ||
                        e is DirectoryNotFoundException ||
                        e is IOException ||
                        e is PathTooLongException ||
                        e is SecurityException ||
                        e is ObjectDisposedException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }
            else
            {
                try
                {
                    File.AppendAllText(localisationCountriesFilePath, "\n " + variable.countryTag + "_neutrality:0 \"" + variable.n_ViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_neutrality_DEF:0 \"" + variable.n_EventViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_neutrality_ADJ:0 \"" + variable.n_AliasName + "\"\n" +
                                                                      " " + variable.countryTag + "_democratic:0 \"" + variable.d_ViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_democratic_DEF:0 \"" + variable.d_EventViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_democratic_ADJ:0 \"" + variable.d_AliasName + "\"\n" +
                                                                      " " + variable.countryTag + "_fascism:0 \"" + variable.f_ViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_fascism_DEF:0 \"" + variable.f_EventViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_fascism_ADJ:0 \"" + variable.f_AliasName + "\"\n" +
                                                                      " " + variable.countryTag + "_communism:0 \"" + variable.c_ViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_communism_DEF:0 \"" + variable.c_EventViewName + "\"\n" +
                                                                      " " + variable.countryTag + "_communism_ADJ:0 \"" + variable.c_AliasName + "\"");
                }
                catch (Exception e)
                {
                    if (e is ArgumentException ||
                        e is ArgumentNullException ||
                        e is PathTooLongException ||
                        e is DirectoryNotFoundException ||
                        e is IOException ||
                        e is UnauthorizedAccessException ||
                        e is NotSupportedException ||
                        e is SecurityException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }

            // ../localisation/mod_parties_l_english.yml
            if (File.Exists(localisationPartiesFilePath) == false)
            {
                int fcResult = FileCreate(localisationPartiesFilePath);
                if (fcResult == 1)
                {
                    return 1;
                }

                try
                {
                    StreamWriter sw = new StreamWriter(localisationPartiesFilePath, false, enc);
                    sw.WriteLine("l_english:");
                    sw.WriteLine("");
                    sw.WriteLine(" " + variable.countryTag + "_neutrality_party:0 \"" + variable.n_PartyAliasName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_neutrality_party_long:0 \"" + variable.n_PartyFullName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_democratic_party:0 \"" + variable.d_PartyAliasName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_democratic_party_long:0 \"" + variable.d_PartyFullName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_fascism_party:0 \"" + variable.f_PartyAliasName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_fascism_party_long:0 \"" + variable.f_PartyFullName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_communism_party:0 \"" + variable.c_PartyAliasName + "\"");
                    sw.WriteLine(" " + variable.countryTag + "_communism_party_long:0 \"" + variable.c_PartyFullName + "\"");
                    sw.Close();
                }
                catch (Exception e)
                {
                    if (e is UnauthorizedAccessException ||
                        e is ArgumentException ||
                        e is ArgumentNullException ||
                        e is DirectoryNotFoundException ||
                        e is IOException ||
                        e is PathTooLongException ||
                        e is SecurityException ||
                        e is ObjectDisposedException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }
            else
            {
                try
                {
                    File.AppendAllText(localisationPartiesFilePath, "\n " + variable.countryTag + "_neutrality_party:0 \"" + variable.n_PartyAliasName + "\"\n" +
                                                                      " " + variable.countryTag + "_neutrality_party_long:0 \"" + variable.n_PartyFullName + "\"\n" +
                                                                      " " + variable.countryTag + "_democratic_party:0 \"" + variable.d_PartyAliasName + "\"\n" +
                                                                      " " + variable.countryTag + "_democratic_party_long:0 \"" + variable.d_PartyFullName + "\"\n" +
                                                                      " " + variable.countryTag + "_fascism_party:0 \"" + variable.f_PartyAliasName + "\"\n" +
                                                                      " " + variable.countryTag + "_fascism_party_long:0 \"" + variable.f_PartyFullName + "\"\n" +
                                                                      " " + variable.countryTag + "_communism_party:0 \"" + variable.c_PartyAliasName + "\"\n" +
                                                                      " " + variable.countryTag + "_communism_party_long:0 \"" + variable.c_PartyFullName + "\"");
                }
                catch (Exception e)
                {
                    if (e is ArgumentException ||
                        e is ArgumentNullException ||
                        e is PathTooLongException ||
                        e is DirectoryNotFoundException ||
                        e is IOException ||
                        e is UnauthorizedAccessException ||
                        e is NotSupportedException ||
                        e is SecurityException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }

            // ../localisation/replaceディレクトリが存在しない場合
            if (Directory.Exists(localisationReplaceDir) == false)
            {
                int fcResult = FolderCreate(localisationReplaceDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // mod_countries_l_english.ymlとmod_parties_l_english.ymlをreplaceディレクトリ内にコピー
            int fcOutResult3 = FileCopy(localisationCountriesFilePath, localisationReplaceCountriesFilePath);
            if (fcOutResult3 == 1)
            {
                return 1;
            }
            int fcOutResult4 = FileCopy(localisationPartiesFilePath, localisationReplacePartiesFilePath);
            if (fcOutResult4 == 1)
            {
                return 1;
            }

            // 6.国旗の生成

            // ../gfxディレクトリが存在しない場合
            if (Directory.Exists(gfxDir) == false)
            {
                int fcResult = FolderCreate(gfxDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../gfx/flagsディレクトリが存在しない場合
            if (Directory.Exists(gfxFlagsDir) == false)
            {
                int fcResult = FolderCreate(gfxFlagsDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../gfx/flags/mediumディレクトリが存在しない場合
            if (Directory.Exists(gfxFlagsMediumDir) == false)
            {
                int fcResult = FolderCreate(gfxFlagsMediumDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../gfx/flags/smallディレクトリが存在しない場合
            if (Directory.Exists(gfxFlagsSmallDir) == false)
            {
                int fcResult = FolderCreate(gfxFlagsSmallDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../gfx/flagsディレクトリ内に国旗ファイルをコピー
            if (File.Exists(n_Flags) == false)
            {
                if (variable.n_FlagBig != "")
                {
                    int fcResult = FileCopy(variable.n_FlagBig, n_Flags);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(d_Flags) == false)
            {
                if (variable.d_FlagBig != "")
                {
                    int fcResult = FileCopy(variable.d_FlagBig, d_Flags);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(f_Flags) == false)
            {
                if (variable.f_FlagBig != "")
                {
                    int fcResult = FileCopy(variable.f_FlagBig, f_Flags);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(c_Flags) == false)
            {
                if (variable.c_FlagBig != "")
                {
                    int fcResult = FileCopy(variable.c_FlagBig, c_Flags);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }

            // ../gfx/flags/mediumディレクトリ内に国旗ファイルをコピー
            if (File.Exists(n_FlagsMedium) == false)
            {
                if (variable.n_FlagMed != "")
                {
                    int fcResult = FileCopy(variable.n_FlagMed, n_FlagsMedium);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(d_FlagsMedium) == false)
            {
                if (variable.d_FlagMed != "")
                {
                    int fcResult = FileCopy(variable.d_FlagMed, d_FlagsMedium);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(f_FlagsMedium) == false)
            {
                if (variable.f_FlagMed != "")
                {
                    int fcResult = FileCopy(variable.f_FlagMed, f_FlagsMedium);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(c_FlagsMedium) == false)
            {
                if (variable.c_FlagMed != "")
                {
                    int fcResult = FileCopy(variable.c_FlagMed, c_FlagsMedium);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }

            // ../gfx/flags/smallディレクトリ内に国旗ファイルをコピー
            if (File.Exists(n_FlagsSmall) == false)
            {
                if (variable.n_FlagSma != "")
                {
                    int fcResult = FileCopy(variable.n_FlagSma, n_FlagsSmall);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(d_FlagsSmall) == false)
            {
                if (variable.d_FlagSma != "")
                {
                    int fcResult = FileCopy(variable.d_FlagSma, d_FlagsSmall);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(f_FlagsSmall) == false)
            {
                if (variable.f_FlagSma != "")
                {
                    int fcResult = FileCopy(variable.f_FlagSma, f_FlagsSmall);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }
            if (File.Exists(c_FlagsSmall) == false)
            {
                if (variable.c_FlagSma != "")
                {
                    int fcResult = FileCopy(variable.c_FlagSma, c_FlagsSmall);
                    if (fcResult == 1)
                    {
                        return 1;
                    }
                }
            }

            // この国が従属国
            if (variable.dependentCountry == true)
            {
                try
                {
                    // modフォルダー内の宗主国にしたい国家ファイルを検索し、存在しなければHOI4ディレクトリからコピーする
                    string[] modFiles = Directory.GetFileSystemEntries(historyCountriesDir, variable.sovereignCountryTag + " - *.txt");
                    if (modFiles.Length == 0)
                    {
                        try
                        {
                            string[] rawCountryFile = Directory.GetFileSystemEntries(variable.hoi4dir + @"\history\countries", variable.sovereignCountryTag + " - *.txt");
                            if (rawCountryFile.Length != 0)
                            {
                                string countryFileName = rawCountryFile[0].Replace(variable.hoi4dir + @"\history\countries", "");
                                FileCopy(rawCountryFile[0], historyCountriesDir + countryFileName);
                            }
                            else
                            {
                                errorMessage("宗主国の国家ファイルが見つかりませんでした。");
                                return 1;
                            }
                        }
                        catch (Exception e)
                        {
                            if (e is UnauthorizedAccessException ||
                                e is ArgumentException ||
                                e is ArgumentNullException ||
                                e is PathTooLongException ||
                                e is IOException ||
                                e is DirectoryNotFoundException)
                            {
                                errorMessage(e.Message);
                                return 1;
                            }
                        }

                        try
                        {
                            string[] sovereignCountryFile = Directory.GetFileSystemEntries(historyCountriesDir, variable.sovereignCountryTag + " - *.txt");
                            try
                            {
                                File.AppendAllText(sovereignCountryFile[0], "\nset_autonomy = {\n\ttarget = " + variable.countryTag + "\n\tautonomous_state = autonomy_puppet\n}");
                            }
                            catch (Exception e)
                            {
                                if (e is ArgumentException ||
                                    e is ArgumentNullException ||
                                    e is PathTooLongException ||
                                    e is DirectoryNotFoundException ||
                                    e is IOException ||
                                    e is UnauthorizedAccessException ||
                                    e is NotSupportedException ||
                                    e is SecurityException)
                                {
                                    errorMessage(e.Message);
                                    return 1;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            if (e is UnauthorizedAccessException ||
                                e is ArgumentException ||
                                e is ArgumentNullException ||
                                e is PathTooLongException ||
                                e is IOException ||
                                e is DirectoryNotFoundException)
                            {
                                errorMessage(e.Message);
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            File.AppendAllText(modFiles[0], "\nset_autonomy = {\n\ttarget = " + variable.countryTag + "\n\tautonomous_state = autonomy_puppet\n}");
                        }
                        catch (Exception e)
                        {
                            if (e is ArgumentException ||
                                e is ArgumentNullException ||
                                e is PathTooLongException ||
                                e is DirectoryNotFoundException ||
                                e is IOException ||
                                e is UnauthorizedAccessException ||
                                e is NotSupportedException ||
                                e is SecurityException)
                            {
                                errorMessage(e.Message);
                                return 1;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e is UnauthorizedAccessException ||
                        e is ArgumentException ||
                        e is ArgumentNullException ||
                        e is PathTooLongException ||
                        e is IOException ||
                        e is DirectoryNotFoundException)
                    {
                        errorMessage(e.Message);
                        return 1;
                    }
                }
            }

            // カスタム国家指導者が有効化されている場合
            if (variable.customLeaderEnabled == true)
            {
                int nlgResult = NationalLeaderGenerate(historyCountrisFilePath);
                if(nlgResult == 1)
                {
                    return 1;
                }
            }

            MessageBox.Show("生成が完了しました。");
            Process.Start(variable.moddir);
            return 0;
        }

        /// <summary>
        /// 国家指導者を生成
        /// </summary>
        /// <returns></returns>
        public int NationalLeaderGenerate(string historyCountriesFilePath)
        {
            Variable variable = new Variable();

            // 国家ファイルに書き込み
            try
            {
                File.AppendAllText(historyCountriesFilePath, "\ncreate_country_leader = {\n" +
                                                             "\tname = \"" + variable.leaderName + "\"\n" +
                                                             "\tdesc = \"" + variable.leaderDesc + "\"\n" +
                                                             "\tpicture = \"" + variable.leaderPictureName + "\"\n" +
                                                             "\texpire = \"" + variable.willNotAppear + "\"\n" +
                                                             "\tideology = " + variable.leaderIdeology + "\n" +
                                                             "\ttraits = {}\n" +
                                                             "}");
            }
            catch (Exception e)
            {
                if (e is ArgumentException ||
                    e is ArgumentNullException ||
                    e is PathTooLongException ||
                    e is DirectoryNotFoundException ||
                    e is IOException ||
                    e is UnauthorizedAccessException ||
                    e is NotSupportedException ||
                    e is SecurityException)
                {
                    errorMessage(e.Message);
                    return 1;
                }
            }


            // ../gfx/leadersディレクトリが存在しない場合にフォルダを作成
            // ../gfx/leaders/[国家タグ]ディレクトリが存在しない場合にファルダを作成
            // 画像ファイルを ../gfx/leaders/[国家タグ]/[国家指導者名].ddsにコピー

            return 0;
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
                    errorMessage(e.Message);
                    return 1;
                }
            }

            return 0;
        }

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
                    errorMessage(e.Message);
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
                    errorMessage(e.Message);
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void errorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
