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
        public int GenerateCountry()
        {
            Variable variable = new Variable();

            // [MODFOLDER]/commonディレクトリパス
            string commonDir = variable.Moddir + @"\common";
            // [MODFOLDER]/common/countriesディレクトリパス
            string commonCountriesDir = commonDir + @"\countries";
            // [MODFOLDER]/common/countries/[COUNTRY].txtファイルパス
            string commonCountryFilePath = commonCountriesDir + @"\" + variable.CountryName + ".txt";
            // [MODFOLDER]/common/countries/colors.txtファイルパス
            string commonColorsFilePath = commonCountriesDir + @"\colors.txt";
            // [HOI4FOLDER]/common/countries/colors.txtファイルパス
            string colorsHoi4FilePath = variable.Hoi4dir + @"\common\countries\colors.txt";
            // [MODFOLDER]/common/country_tagsディレクトリパス
            string commonCountry_tagsDir = commonDir + @"\country_tags";
            // [MODFOLDER]/common/country_tags/01_countries.txtファイルパス
            string commonCountriesFilePath = commonCountry_tagsDir + @"\01_countries.txt";
            // [MODFOLDER]/historyディレクトリパス
            string historyDir = variable.Moddir + @"\history";
            // [MODFOLDER]/history/countriesディレクトリパス
            string historyCountriesDir = historyDir + @"\countries";
            // [MODFOLDER]/history/countries/[TAG] - [COUNTRY].txtファイルパス
            string historyCountrisFilePath = historyCountriesDir + @"\" + variable.CountryTag + " - " + variable.CountryName + ".txt";
            // [MODFOLDER]/localisationディレクトリパス
            string localisationDir = variable.Moddir + @"\localisation";
            // [MODFOLDER]/localisation/replaceディレクトリパス
            string localisationReplaceDir = localisationDir + @"\replace";
            // [MODFOLDER]/localisation/replace/[MODNAME]_countries_l_english.ymlファイルパス
            string localisationReplaceCountriesFilePath = localisationReplaceDir + @"\" + variable.ModName + "_countries_l_english.yml";
            // [MODFOLDER]/localisation/replace/[MODNAME]_parties_l_english.ymlファイルパス
            string localisationReplacePartiesFilePath = localisationReplaceDir + @"\" + variable.ModName + "_parties_l_english.yml";
            // [MODFOLDER]/gfxディレクトリパス
            string gfxDir = variable.Moddir + @"\gfx";
            // [MODFOLDER]/gfx/flagsディレクトリパス
            string gfxFlagsDir = gfxDir + @"\flags";
            // [MODFOLDER]/gfx/flags/mediumディレクトリパス
            string gfxFlagsMediumDir = gfxFlagsDir + @"\medium";
            // [MODFOLDER]/gfx/flags/smallディレクトリパス
            string gfxFlagsSmallDir = gfxFlagsDir + @"\small";
            // [MODFOLDER]/gfx/leadersディレクトリパス
            string gfxLeadersDir = gfxDir + @"\leaders";
            // [MODFOLDER]/gfx/leaders/[TAG]ディレクトリパス
            string gfxLeadersTagDir = gfxLeadersDir + @"\" + variable.CountryTag;
            // 中道主義国旗（大・中・小）
            string n_Flags = gfxFlagsDir + @"\" + variable.CountryTag + "_neutrality.tga";
            string n_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.CountryTag + "_neutrality.tga";
            string n_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.CountryTag + "_neutrality.tga";
            // 民主主義国旗（大・中・小）
            string d_Flags = gfxFlagsDir + @"\" + variable.CountryTag + "_democratic.tga";
            string d_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.CountryTag + "_democratic.tga";
            string d_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.CountryTag + "_democratic.tga";
            // ファシズム国旗（大・中・小）
            string f_Flags = gfxFlagsDir + @"\" + variable.CountryTag + "_fascism.tga";
            string f_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.CountryTag + "_fascism.tga";
            string f_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.CountryTag + "_fascism.tga";
            // 共産主義国旗（大・中・小）
            string c_Flags = gfxFlagsDir + @"\" + variable.CountryTag + "_communism.tga";
            string c_FlagsMedium = gfxFlagsMediumDir + @"\" + variable.CountryTag + "_communism.tga";
            string c_FlagsSmall = gfxFlagsSmallDir + @"\" + variable.CountryTag + "_communism.tga";
            // 書き込み用エンコード指定（UTF-8 BOM付き）
            Encoding enc = Encoding.UTF8;


            // 0.国家タグがダブってないか確認する

            // HOI4DIR/history/countries/内で国家タグが一致するファイルがあるかを検索
            try
            {
                string[] hoi4Files = Directory.GetFileSystemEntries(variable.Hoi4dir + @"\history\countries", variable.CountryTag + " - *.txt");
                if (hoi4Files.Length != 0)
                {
                    ErrorMessage("国家タグ\"" + variable.CountryTag + "\"は既に使用されています。別の国家タグを使用してください。");
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
                    ErrorMessage(e.Message);
                    return 1;
                }
            }

            // MODDIR/history/countries内で国家タグが一致するファイルがあるかを検索
            if (Directory.Exists(historyDir) == true)
            {
                try
                {
                    string[] modFiles = Directory.GetFileSystemEntries(historyCountriesDir, variable.CountryTag + "- *.txt");
                    if (modFiles.Length != 0)
                    {
                        ErrorMessage("国家タグ\"" + variable.CountryTag + "\"は既に使用されています。別の国家タグを使用してください。");
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
                        ErrorMessage(e.Message);
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
                ErrorMessage("ファイル\"" + commonCountryFilePath + "\"は既に存在しています。\n別のファイル名を使用してください。");
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
                sr.WriteLine("graphical_culture = " + variable.GraphicalCulture);
                sr.WriteLine("graphical_culture_2d = " + variable.GraphicalCulture2d);
                sr.Close();
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException ||
                    e is IOException)
                {
                    ErrorMessage(e.Message);
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
                string color = variable.ColorR + " " + variable.ColorG + " " + variable.ColorB;
                File.AppendAllText(commonColorsFilePath, "\n" + variable.CountryTag + " = {\n\tcolor = rgb { " + color + " }\n\tcolor_ui = rgb { " + color + " }\n}");
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
                    ErrorMessage(e.Message);
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
                    sw.WriteLine(variable.CountryTag + " = \"countries/" + variable.CountryName + ".txt\"");
                    sw.Close();
                }
                catch (Exception e)
                {
                    if (e is ObjectDisposedException ||
                        e is IOException)
                    {
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
            }
            else
            {
                try
                {
                    File.AppendAllText(commonCountriesFilePath, "\n" + variable.CountryTag + " = \"countries/" + variable.CountryName + ".txt\"");
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
                        ErrorMessage(e.Message);
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
                sw.WriteLine("capital = " + variable.StateIDWithCapital);
                // ユニットファイル（コメントアウト）
                sw.WriteLine("#oob = \"\"");
                // 研究スロット数
                sw.WriteLine("set_research_slots = " + variable.StudySlot);
                // 安定度
                sw.WriteLine("set_stability = " + variable.Stability);
                // 戦争協力度
                sw.WriteLine("set_war_support = " + variable.WarCoop);
                // 輸送船
                sw.WriteLine("set_convoys = " + variable.TransportShip);
                // 研究完了済み技術（コメントアウト）
                sw.WriteLine("#set_technology = {}");
                // 政党関連
                sw.WriteLine("set_politics = {");
                sw.WriteLine("\truling_party = " + variable.StartIdeology);
                sw.WriteLine("\tlast_election = " + variable.LastElection);
                sw.WriteLine("\telection_frequency = " + variable.ElectionFrequency);

                if (variable.NoElection == true)
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

                if (Properties.Settings.Default.democraticDisabled == false)
                {
                    sw.WriteLine("\tdemocratic = " + variable.D_Popularity);
                }

                if (Properties.Settings.Default.fascismDisabled == false)
                {
                    sw.WriteLine("\tfascism = " + variable.F_Popularity);
                }

                if (Properties.Settings.Default.communismDisabled == false)
                {
                    sw.WriteLine("\tcommunism = " + variable.C_Popularity);
                }
                
                if (Properties.Settings.Default.neutralityDisabled == false)
                {
                    sw.WriteLine("\tneutrality = " + variable.N_Popularity);
                }
                sw.WriteLine("}");
                sw.Close();
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException ||
                    e is IOException)
                {
                    ErrorMessage(e.Message);
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

            // ../localisation/replaceディレクトリが存在しない場合
            if (Directory.Exists(localisationReplaceDir) == false)
            {
                int fcResult = FolderCreate(localisationReplaceDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../localisation/replace/mod_countries_l_english.yml
            if (File.Exists(localisationReplaceCountriesFilePath) == false)
            {
                int fcResult = FileCreate(localisationReplaceCountriesFilePath);
                if (fcResult == 1)
                {
                    return 1;
                }

                try
                {
                    StreamWriter sw = new StreamWriter(localisationReplaceCountriesFilePath, false, enc);
                    sw.WriteLine("l_english:");
                    sw.WriteLine("");

                    if (Properties.Settings.Default.neutralityDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_neutrality:0 \"" + variable.N_ViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_neutrality_DEF:0 \"" + variable.N_EventViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_neutrality_ADJ:0 \"" + variable.N_AliasName + "\"");
                    }

                    if (Properties.Settings.Default.democraticDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_democratic:0 \"" + variable.D_ViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_democratic_DEF:0 \"" + variable.D_EventViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_democratic_ADJ:0 \"" + variable.D_AliasName + "\"");
                    }

                    if (Properties.Settings.Default.fascismDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_fascism:0 \"" + variable.F_ViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_fascism_DEF:0 \"" + variable.F_EventViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_fascism_ADJ:0 \"" + variable.F_AliasName + "\"");
                    }
                    
                    if (Properties.Settings.Default.communismDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_communism:0 \"" + variable.C_ViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_communism_DEF:0 \"" + variable.C_EventViewName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_communism_ADJ:0 \"" + variable.C_AliasName + "\"");
                    }
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
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
            }
            else
            {
                try
                {
                    if (Properties.Settings.Default.neutralityDisabled == false)
                    {
                        File.AppendAllText(localisationReplaceCountriesFilePath, "\n " + variable.CountryTag + "_neutrality:0 \"" + variable.N_ViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_neutrality_DEF:0 \"" + variable.N_EventViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_neutrality_ADJ:0 \"" + variable.N_AliasName + "\"");
                    }

                    if (Properties.Settings.Default.democraticDisabled == false)
                    {
                        File.AppendAllText(localisationReplaceCountriesFilePath, "\n " + variable.CountryTag + "_democratic:0 \"" + variable.D_ViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_democratic_DEF:0 \"" + variable.D_EventViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_democratic_ADJ:0 \"" + variable.D_AliasName + "\"");
                    }

                    if (Properties.Settings.Default.fascismDisabled == false)
                    {
                        File.AppendAllText(localisationReplaceCountriesFilePath, "\n " + variable.CountryTag + "_fascism:0 \"" + variable.F_ViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_fascism_DEF:0 \"" + variable.F_EventViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_fascism_ADJ:0 \"" + variable.F_AliasName + "\"");
                    }

                    if (Properties.Settings.Default.communismDisabled == false)
                    {
                        File.AppendAllText(localisationReplaceCountriesFilePath, "\n " + variable.CountryTag + "_communism:0 \"" + variable.C_ViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_communism_DEF:0 \"" + variable.C_EventViewName + "\"\n" +
                                                                      " " + variable.CountryTag + "_communism_ADJ:0 \"" + variable.C_AliasName + "\"\n");
                    }
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
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
            }

            // ../localisation/mod_parties_l_english.yml
            if (File.Exists(localisationReplacePartiesFilePath) == false)
            {
                int fcResult = FileCreate(localisationReplacePartiesFilePath);
                if (fcResult == 1)
                {
                    return 1;
                }

                try
                {
                    StreamWriter sw = new StreamWriter(localisationReplacePartiesFilePath, false, enc);
                    sw.WriteLine("l_english:");
                    sw.WriteLine("");
                    if (Properties.Settings.Default.neutralityDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_neutrality_party:0 \"" + variable.N_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_neutrality_party_long:0 \"" + variable.N_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.democraticDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_democratic_party:0 \"" + variable.D_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_democratic_party_long:0 \"" + variable.D_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.fascismDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_fascism_party:0 \"" + variable.F_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_fascism_party_long:0 \"" + variable.F_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.communismDisabled == false)
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_communism_party:0 \"" + variable.C_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_communism_party_long:0 \"" + variable.C_PartyFullName + "\"");
                    }
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
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
            }
            else
            {
                try
                {
                    if (Properties.Settings.Default.neutralityDisabled == false)
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_neutrality_party:0 \"" + variable.N_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_neutrality_party_long:0 \"" + variable.N_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.democraticDisabled == false)
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_democratic_party:0 \"" + variable.D_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_democratic_party_long:0 \"" + variable.D_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.fascismDisabled == false)
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_fascism_party:0 \"" + variable.F_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_fascism_party_long:0 \"" + variable.F_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.communismDisabled == false)
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_communism_party:0 \"" + variable.C_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_communism_party_long:0 \"" + variable.C_PartyFullName + "\"\n");
                    }
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
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
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

            // 国旗ファイルをコピー
            if (Properties.Settings.Default.neutralityDisabled == false)
            {
                if (File.Exists(n_Flags) == false)
                {
                    if (variable.N_FlagBig != "")
                    {
                        int fcResult = FileCopy(variable.N_FlagBig, n_Flags);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(n_FlagsMedium) == false)
                {
                    if (variable.N_FlagMed != "")
                    {
                        int fcResult = FileCopy(variable.N_FlagMed, n_FlagsMedium);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(n_FlagsSmall) == false)
                {
                    if (variable.N_FlagSma != "")
                    {
                        int fcResult = FileCopy(variable.N_FlagSma, n_FlagsSmall);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }
            }

            if (Properties.Settings.Default.democraticDisabled == false)
            {
                if (File.Exists(d_Flags) == false)
                {
                    if (variable.D_FlagBig != "")
                    {
                        int fcResult = FileCopy(variable.D_FlagBig, d_Flags);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(d_FlagsMedium) == false)
                {
                    if (variable.D_FlagMed != "")
                    {
                        int fcResult = FileCopy(variable.D_FlagMed, d_FlagsMedium);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(d_FlagsSmall) == false)
                {
                    if (variable.D_FlagSma != "")
                    {
                        int fcResult = FileCopy(variable.D_FlagSma, d_FlagsSmall);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }
            }

            if (Properties.Settings.Default.fascismDisabled == false)
            {
                if (File.Exists(f_Flags) == false)
                {
                    if (variable.F_FlagBig != "")
                    {
                        int fcResult = FileCopy(variable.F_FlagBig, f_Flags);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(f_FlagsMedium) == false)
                {
                    if (variable.F_FlagMed != "")
                    {
                        int fcResult = FileCopy(variable.F_FlagMed, f_FlagsMedium);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(f_FlagsSmall) == false)
                {
                    if (variable.F_FlagSma != "")
                    {
                        int fcResult = FileCopy(variable.F_FlagSma, f_FlagsSmall);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }
            }

            if (Properties.Settings.Default.communismDisabled == false)
            {
                if (File.Exists(c_Flags) == false)
                {
                    if (variable.C_FlagBig != "")
                    {
                        int fcResult = FileCopy(variable.C_FlagBig, c_Flags);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(c_FlagsMedium) == false)
                {
                    if (variable.C_FlagMed != "")
                    {
                        int fcResult = FileCopy(variable.C_FlagMed, c_FlagsMedium);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }

                if (File.Exists(c_FlagsSmall) == false)
                {
                    if (variable.C_FlagSma != "")
                    {
                        int fcResult = FileCopy(variable.C_FlagSma, c_FlagsSmall);
                        if (fcResult == 1)
                        {
                            return 1;
                        }
                    }
                }
            }

            // この国が従属国
            if (variable.DependentCountry == true)
            {
                try
                {
                    // modフォルダー内の宗主国にしたい国家ファイルを検索し、存在しなければHOI4ディレクトリからコピーする
                    string[] modFiles = Directory.GetFileSystemEntries(historyCountriesDir, variable.SovereignCountryTag + " - *.txt");
                    if (modFiles.Length == 0)
                    {
                        try
                        {
                            string[] rawCountryFile = Directory.GetFileSystemEntries(variable.Hoi4dir + @"\history\countries", variable.SovereignCountryTag + " - *.txt");
                            if (rawCountryFile.Length != 0)
                            {
                                string countryFileName = rawCountryFile[0].Replace(variable.Hoi4dir + @"\history\countries", "");
                                FileCopy(rawCountryFile[0], historyCountriesDir + countryFileName);
                            }
                            else
                            {
                                ErrorMessage("宗主国の国家ファイルが見つかりませんでした。");
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
                                ErrorMessage(e.Message);
                                return 1;
                            }
                        }

                        try
                        {
                            string[] sovereignCountryFile = Directory.GetFileSystemEntries(historyCountriesDir, variable.SovereignCountryTag + " - *.txt");
                            try
                            {
                                File.AppendAllText(sovereignCountryFile[0], "\nset_autonomy = {\n\ttarget = " + variable.CountryTag + "\n\tautonomous_state = autonomy_puppet\n}");
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
                                    ErrorMessage(e.Message);
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
                                ErrorMessage(e.Message);
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            File.AppendAllText(modFiles[0], "\nset_autonomy = {\n\ttarget = " + variable.CountryTag + "\n\tautonomous_state = autonomy_puppet\n}");
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
                                ErrorMessage(e.Message);
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
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
            }

            // カスタム国家指導者が有効化されている場合
            if (variable.CustomLeaderEnabled == true)
            {
                int nlgResult = NationalLeaderGenerate(historyCountrisFilePath, gfxLeadersDir, gfxLeadersTagDir);
                if (nlgResult == 1)
                {
                    return 1;
                }
            }

            // 陣営の作成が有効化されている場合
            if (variable.FactionCreateEnabled == true)
            {
                int fsResult = FactionSetting(historyCountrisFilePath, localisationReplaceDir);
                if (fsResult == 1)
                {
                    return 1;
                }
            }

            MessageBox.Show("生成が完了しました。");

            if (Properties.Settings.Default.afterOpenFolder == true)
            {
                Process.Start(variable.Moddir);
            }
            return 0;
        }

        /// <summary>
        /// 国家指導者を生成
        /// </summary>
        /// <returns></returns>
        public int NationalLeaderGenerate(string HistoryCountriesFilePath, string GfxLeadersDir, string GfxLeadersTagDir)
        {
            Variable variable = new Variable();

            int fcResult;

            // 国家ファイルに書き込み
            try
            {
                File.AppendAllText(HistoryCountriesFilePath, "\ncreate_country_leader = {\n" +
                                                             "\tname = \"" + variable.LeaderName + "\"\n" +
                                                             "\tdesc = \"" + variable.LeaderDesc + "\"\n" +
                                                             "\tpicture = \"" + variable.LeaderPictureName + "\"\n" +
                                                             "\texpire = \"" + variable.WillNotAppear + "\"\n" +
                                                             "\tideology = " + variable.LeaderIdeology + "\n" +
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
                    ErrorMessage(e.Message);
                    return 1;
                }
            }


            // ../gfx/leadersディレクトリが存在しない場合にフォルダを作成
            if (Directory.Exists(GfxLeadersDir) == false)
            {
                fcResult = FolderCreate(GfxLeadersDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // ../gfx/leaders/[国家タグ]ディレクトリが存在しない場合にファルダを作成
            if (Directory.Exists(GfxLeadersTagDir) == false)
            {
                fcResult = FolderCreate(GfxLeadersTagDir);
                if (fcResult == 1)
                {
                    return 1;
                }
            }

            // 画像ファイルを ../gfx/leaders/[国家タグ]/[国家指導者名].ddsにコピー
            string leaderPicturePath = GfxLeadersTagDir + @"\" + variable.LeaderPictureName;

            fcResult = FileCopy(variable.LeaderPicturePath, leaderPicturePath);
            if (fcResult == 1)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// 陣営作成の設定
        /// </summary>
        /// <returns></returns>
        public int FactionSetting(string HistoryCountriesFilePath, string LocalisationReplaceDir)
        {
            Variable variable = new Variable();

            // 国家ファイル
            try
            {
                File.AppendAllText(HistoryCountriesFilePath, "\ncreate_faction = " + variable.FactionInternalName + "\nadd_to_faction = " + variable.CountryTag);

                if (variable.FactionParticipatingCountries != null)
                {
                    for ( int cnt = 0; cnt <= variable.FactionParticipatingCountries.Length; cnt++ )
                    {
                        File.AppendAllText(HistoryCountriesFilePath, "\nadd_to_faction = " + variable.FactionParticipatingCountries[cnt]);
                    }
                }
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
                    ErrorMessage(e.Message);
                    return 1;
                }
            }

            // localisationファイル
            string localisationReplaceFactionsFilePath = LocalisationReplaceDir + @"\"+ variable.ModName +"_factions_l_english.yml";

            if (File.Exists(localisationReplaceFactionsFilePath) == false)
            {
                int fcResult = FileCreate(localisationReplaceFactionsFilePath);
                if (fcResult == 1)
                {
                    return 1;
                }

                try
                {
                    StreamWriter sw = new StreamWriter(localisationReplaceFactionsFilePath, false, Encoding.UTF8);
                    sw.WriteLine("l_english:");
                    sw.WriteLine("");

                    sw.WriteLine(" " + variable.FactionInternalName + ":0 \"" + variable.FactionName + "\"");
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
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
            }
            else
            {
                try
                {
                    File.AppendAllText(localisationReplaceFactionsFilePath, "\n " + variable.FactionInternalName + ":0 \"" + variable.FactionName + "\"");
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
                        ErrorMessage(e.Message);
                        return 1;
                    }
                }
            }


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
                    ErrorMessage(e.Message);
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

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
