using HoI4_Modding_Supporter.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;

namespace HoI4_Modding_Supporter.Workers
{
    class Generate
    {
        /// <summary>
        /// 国家の生成（ファイル書き込み処理）
        /// </summary>
        public int GenerateCountry()
        {
            Variable variable = new Variable();

            // [MODDIR]/commonディレクトリパス
            string commonDir = variable.Moddir + @"\common";
            // [MODDIR]/common/countriesディレクトリパス
            string commonCountriesDir = commonDir + @"\countries";
            // [MODDIR]/common/countries/[COUNTRY].txtファイルパス
            string commonCountryFilePath = commonCountriesDir + @"\" + variable.CountryName + ".txt";
            // [MODDIR]/common/countries/colors.txtファイルパス
            string commonColorsFilePath = commonCountriesDir + @"\colors.txt";
            // [HOI4DIR]/common/countries/colors.txtファイルパス
            string colorsHoi4FilePath = variable.Hoi4dir + @"\common\countries\colors.txt";
            // [MODDIR]/common/country_tagsディレクトリパス
            string commonCountry_tagsDir = commonDir + @"\country_tags";
            // [MODDIR]/common/country_tags/01_countries.txtファイルパス
            string commonCountriesFilePath = commonCountry_tagsDir + @"\01_countries.txt";
            // [MODDIR]/historyディレクトリパス
            string historyDir = variable.Moddir + @"\history";
            // [MODDIR]/history/countriesディレクトリパス
            string historyCountriesDir = historyDir + @"\countries";
            // [MODDIR]/history/countries/[TAG] - [COUNTRY].txtファイルパス
            string historyCountrisFilePath = historyCountriesDir + @"\" + variable.CountryTag + " - " + variable.CountryName + ".txt";
            // [MODDIR]/localisationディレクトリパス
            string localisationDir = variable.Moddir + @"\localisation";
            // [MODDIR]/localisation/replaceディレクトリパス
            string localisationReplaceDir = localisationDir + @"\replace";
            // [MODDIR]/localisation/replace/[MODNAME]_countries_l_english.ymlファイルパス
            string localisationReplaceCountriesFilePath = localisationReplaceDir + @"\" + variable.ModName + "_countries_l_english.yml";
            // [MODDIR]/localisation/replace/[MODNAME]_parties_l_english.ymlファイルパス
            string localisationReplacePartiesFilePath = localisationReplaceDir + @"\" + variable.ModName + "_parties_l_english.yml";
            // [MODDIR]/gfxディレクトリパス
            string gfxDir = variable.Moddir + @"\gfx";
            // [MODDIR]/gfx/flagsディレクトリパス
            string gfxFlagsDir = gfxDir + @"\flags";
            // [MODDIR]/gfx/flags/mediumディレクトリパス
            string gfxFlagsMediumDir = gfxFlagsDir + @"\medium";
            // [MODDIR]/gfx/flags/smallディレクトリパス
            string gfxFlagsSmallDir = gfxFlagsDir + @"\small";
            // [MODDIR]/gfx/leadersディレクトリパス
            string gfxLeadersDir = gfxDir + @"\leaders";
            // [MODDIR]/gfx/leaders/[TAG]ディレクトリパス
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
                    MessageBoxShower.ErrorMessage("国家タグ\"" + variable.CountryTag + "\"は既に使用されています。別の国家タグを使用してください。");
                    return 1;
                }
            }
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is PathTooLongException ||
                                      e is IOException ||
                                      e is DirectoryNotFoundException)
            {
                MessageBoxShower.ErrorMessage(e.Message);
                return 1;
            }

            // MODDIR/history/countries内で国家タグが一致するファイルがあるかを検索
            if (Directory.Exists(historyDir) == true)
            {
                try
                {
                    string[] modFiles = Directory.GetFileSystemEntries(historyCountriesDir, variable.CountryTag + "- *.txt");
                    if (modFiles.Length != 0)
                    {
                        MessageBoxShower.ErrorMessage("国家タグ\"" + variable.CountryTag + "\"は既に使用されています。別の国家タグを使用してください。");
                        return 1;
                    }
                }
                catch (Exception e) when (e is UnauthorizedAccessException ||
                                          e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is PathTooLongException ||
                                          e is IOException ||
                                          e is DirectoryNotFoundException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    return 1;
                }
            }

            // 1.国別ファイルの作成

            // MODDIR/common ディレクトリが存在しない場合
            if (Directory.Exists(commonDir) == false)
            {
                if (FileSystemInterface.FolderCreate(commonDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }
            
            // MODDIR/common/countries ディレクトリが存在しない場合
            if (Directory.Exists(commonCountriesDir) == false)
            {
                if (FileSystemInterface.FolderCreate(commonCountriesDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../countries の中に国別ファイルを作成
            if (File.Exists(commonCountryFilePath) == true)
            {
                MessageBoxShower.ErrorMessage("ファイル\"" + commonCountryFilePath + "\"は既に存在しています。\n別のファイル名を使用してください。");
                MessageBoxShower.GenerateStoppedMessage();
                return 1;
            }
            else
            {
                if (FileSystemInterface.FileCreate(commonCountryFilePath) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
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
            catch (Exception e) when (e is ObjectDisposedException ||
                                      e is IOException)
            {
                MessageBoxShower.ErrorMessage(e.Message);
                MessageBoxShower.GenerateStoppedMessage();
                return 1;
            }

            // 2.色定義ファイルの作成

            // ../countries/colors.txtをhoi4本体ディレクトリからコピー
            // 既に存在する場合はそのファイルに書き込み
            if (File.Exists(commonColorsFilePath) == false)
            {
                if (FileSystemInterface.FileCopy(colorsHoi4FilePath, commonColorsFilePath) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }


            // colors.txtに追記
            try
            {
                string color = variable.ColorR + " " + variable.ColorG + " " + variable.ColorB;
                File.AppendAllText(commonColorsFilePath, "\n" + variable.CountryTag + " = {\n\tcolor = rgb { " + color + " }\n\tcolor_ui = rgb { " + color + " }\n}");
            }
            catch (Exception e) when (e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is PathTooLongException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is UnauthorizedAccessException ||
                                      e is NotSupportedException ||
                                      e is SecurityException)
            {
                MessageBoxShower.ErrorMessage(e.Message);
                MessageBoxShower.GenerateStoppedMessage();
                return 1;
            }

            // 3.国家タグ定義ファイルの作成

            // ../common/country_tagsディレクトリが存在しない場合
            if (Directory.Exists(commonCountry_tagsDir) == false)
            {
                if (FileSystemInterface.FolderCreate(commonCountry_tagsDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // 存在しない場合、../country_tags/01_countries.txtを作成
            if (File.Exists(commonCountriesFilePath) == false)
            {
                if (FileSystemInterface.FileCreate(commonCountriesFilePath) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }


                // 01_countries.txtを編集
                try
                {
                    StreamWriter sw = new StreamWriter(commonCountriesFilePath, false);
                    sw.WriteLine(variable.CountryTag + " = \"countries/" + variable.CountryName + ".txt\"");
                    sw.Close();
                }
                catch (Exception e) when (e is ObjectDisposedException ||
                                          e is IOException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }
            else
            {
                try
                {
                    File.AppendAllText(commonCountriesFilePath, "\n" + variable.CountryTag + " = \"countries/" + variable.CountryName + ".txt\"");
                }
                catch (Exception e) when (e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is PathTooLongException ||
                                          e is DirectoryNotFoundException ||
                                          e is IOException ||
                                          e is UnauthorizedAccessException ||
                                          e is NotSupportedException ||
                                          e is SecurityException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // 4.国家ファイルの作成

            // MODDIR/historyディレクトリが存在しない場合
            if (Directory.Exists(historyDir) == false)
            {
                if (FileSystemInterface.FolderCreate(historyDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // MODDIR/hitsory/countriesディレクトリが存在しない場合
            if (Directory.Exists(historyCountriesDir) == false)
            {
                if (FileSystemInterface.FolderCreate(historyCountriesDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // 国家ファイルを作成
            if (FileSystemInterface.FileCreate(historyCountrisFilePath) == 1)
            {
                MessageBoxShower.GenerateStoppedMessage();
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
                    sw.WriteLine("\telections_allowed = no");
                else
                    sw.WriteLine("\telections_allowed = yes");

                sw.WriteLine("}");
                // 政党支持率
                sw.WriteLine("set_popularities = {");

                if (Properties.Settings.Default.democraticDisabled == false)
                    sw.WriteLine("\tdemocratic = " + variable.D_Popularity);

                if (Properties.Settings.Default.fascismDisabled == false)
                    sw.WriteLine("\tfascism = " + variable.F_Popularity);

                if (Properties.Settings.Default.communismDisabled == false)
                    sw.WriteLine("\tcommunism = " + variable.C_Popularity);
                
                if (Properties.Settings.Default.neutralityDisabled == false)
                    sw.WriteLine("\tneutrality = " + variable.N_Popularity);

                sw.WriteLine("}");
                sw.Close();
            }
            catch (Exception e) when (e is ObjectDisposedException ||
                                      e is IOException)
            {
                MessageBoxShower.ErrorMessage(e.Message);
                MessageBoxShower.GenerateStoppedMessage();
                return 1;
            }

            // 5.国名・政党名の設定

            // localisationディレクトリが存在しない場合
            if (Directory.Exists(localisationDir) == false)
            {
                if (FileSystemInterface.FolderCreate(localisationDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../localisation/replaceディレクトリが存在しない場合
            if (Directory.Exists(localisationReplaceDir) == false)
            {
                if (FileSystemInterface.FolderCreate(localisationReplaceDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../localisation/replace/mod_countries_l_english.yml
            if (File.Exists(localisationReplaceCountriesFilePath) == false)
            {
                if (FileSystemInterface.FileCreate(localisationReplaceCountriesFilePath) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
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
                catch (Exception e) when (e is UnauthorizedAccessException ||
                                          e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is DirectoryNotFoundException ||
                                          e is IOException ||
                                          e is PathTooLongException ||
                                          e is SecurityException ||
                                          e is ObjectDisposedException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
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
                catch (Exception e) when (e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is PathTooLongException ||
                                          e is DirectoryNotFoundException ||
                                          e is IOException ||
                                          e is UnauthorizedAccessException ||
                                          e is NotSupportedException ||
                                          e is SecurityException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../localisation/mod_parties_l_english.yml
            if (File.Exists(localisationReplacePartiesFilePath) == false)
            {
                if (FileSystemInterface.FileCreate(localisationReplacePartiesFilePath) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }

                try
                {
                    StreamWriter sw = new StreamWriter(localisationReplacePartiesFilePath, false, enc);
                    sw.WriteLine("l_english:");
                    sw.WriteLine("");
                    if (Properties.Settings.Default.neutralityDisabled == false &&
                        variable.N_PartyFullName != "" &&
                        variable.N_PartyAliasName != "")
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_neutrality_party:0 \"" + variable.N_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_neutrality_party_long:0 \"" + variable.N_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.democraticDisabled == false &&
                        variable.D_PartyFullName != "" &&
                        variable.D_PartyAliasName != "")
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_democratic_party:0 \"" + variable.D_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_democratic_party_long:0 \"" + variable.D_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.fascismDisabled == false &&
                        variable.F_PartyFullName != "" &&
                        variable.F_PartyAliasName != "")
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_fascism_party:0 \"" + variable.F_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_fascism_party_long:0 \"" + variable.F_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.communismDisabled == false &&
                        variable.C_PartyFullName != "" &&
                        variable.C_PartyAliasName != "")
                    {
                        sw.WriteLine(" " + variable.CountryTag + "_communism_party:0 \"" + variable.C_PartyAliasName + "\"");
                        sw.WriteLine(" " + variable.CountryTag + "_communism_party_long:0 \"" + variable.C_PartyFullName + "\"");
                    }
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
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }
            else
            {
                try
                {
                    if (Properties.Settings.Default.neutralityDisabled == false &&
                        variable.N_PartyFullName != "" &&
                        variable.N_PartyAliasName != "")
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_neutrality_party:0 \"" + variable.N_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_neutrality_party_long:0 \"" + variable.N_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.democraticDisabled == false &&
                        variable.D_PartyFullName != "" &&
                        variable.D_PartyAliasName != "")
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_democratic_party:0 \"" + variable.D_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_democratic_party_long:0 \"" + variable.D_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.fascismDisabled == false &&
                        variable.F_PartyFullName != "" &&
                        variable.F_PartyAliasName != "")
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_fascism_party:0 \"" + variable.F_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_fascism_party_long:0 \"" + variable.F_PartyFullName + "\"");
                    }

                    if (Properties.Settings.Default.communismDisabled == false &&
                        variable.C_PartyFullName != "" &&
                        variable.C_PartyAliasName != "")
                    {
                        File.AppendAllText(localisationReplacePartiesFilePath, "\n " + variable.CountryTag + "_communism_party:0 \"" + variable.C_PartyAliasName + "\"\n" + " " + variable.CountryTag + "_communism_party_long:0 \"" + variable.C_PartyFullName + "\"\n");
                    }
                }
                catch (Exception e) when (e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is PathTooLongException ||
                                          e is DirectoryNotFoundException ||
                                          e is IOException ||
                                          e is UnauthorizedAccessException ||
                                          e is NotSupportedException ||
                                          e is SecurityException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // 6.国旗の生成

            // ../gfxディレクトリが存在しない場合
            if (Directory.Exists(gfxDir) == false)
            {
                if (FileSystemInterface.FolderCreate(gfxDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../gfx/flagsディレクトリが存在しない場合
            if (Directory.Exists(gfxFlagsDir) == false)
            {
                if (FileSystemInterface.FolderCreate(gfxFlagsDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../gfx/flags/mediumディレクトリが存在しない場合
            if (Directory.Exists(gfxFlagsMediumDir) == false)
            {
                if (FileSystemInterface.FolderCreate(gfxFlagsMediumDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../gfx/flags/smallディレクトリが存在しない場合
            if (Directory.Exists(gfxFlagsSmallDir) == false)
            {
                if (FileSystemInterface.FolderCreate(gfxFlagsSmallDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
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
                        if (FileSystemInterface.FileCopy(variable.N_FlagBig, n_Flags) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(n_FlagsMedium) == false)
                {
                    if (variable.N_FlagMed != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.N_FlagMed, n_FlagsMedium) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(n_FlagsSmall) == false)
                {
                    if (variable.N_FlagSma != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.N_FlagSma, n_FlagsSmall) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
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
                        if (FileSystemInterface.FileCopy(variable.D_FlagBig, d_Flags) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(d_FlagsMedium) == false)
                {
                    if (variable.D_FlagMed != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.D_FlagMed, d_FlagsMedium) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(d_FlagsSmall) == false)
                {
                    if (variable.D_FlagSma != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.D_FlagSma, d_FlagsSmall) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
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
                        if (FileSystemInterface.FileCopy(variable.F_FlagBig, f_Flags) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(f_FlagsMedium) == false)
                {
                    if (variable.F_FlagMed != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.F_FlagMed, f_FlagsMedium) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(f_FlagsSmall) == false)
                {
                    if (variable.F_FlagSma != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.F_FlagSma, f_FlagsSmall) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
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
                        if (FileSystemInterface.FileCopy(variable.C_FlagBig, c_Flags) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(c_FlagsMedium) == false)
                {
                    if (variable.C_FlagMed != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.C_FlagMed, c_FlagsMedium) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }

                if (File.Exists(c_FlagsSmall) == false)
                {
                    if (variable.C_FlagSma != "")
                    {
                        if (FileSystemInterface.FileCopy(variable.C_FlagSma, c_FlagsSmall) == 1)
                        {
                            MessageBoxShower.GenerateStoppedMessage();
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
                                
                                if (FileSystemInterface.FileCopy(rawCountryFile[0], historyCountriesDir + countryFileName) == 1)
                                {
                                    MessageBoxShower.GenerateStoppedMessage();
                                    return 1;
                                }
                            }
                            else
                            {
                                MessageBoxShower.ErrorMessage("宗主国の国家ファイルが見つかりませんでした。");
                                MessageBoxShower.GenerateStoppedMessage();
                                return 1;
                            }
                        }
                        catch (Exception e) when (e is UnauthorizedAccessException ||
                                                  e is ArgumentException ||
                                                  e is ArgumentNullException ||
                                                  e is PathTooLongException ||
                                                  e is IOException ||
                                                  e is DirectoryNotFoundException)
                        {
                            MessageBoxShower.ErrorMessage(e.Message);
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }

                        try
                        {
                            string[] sovereignCountryFile = Directory.GetFileSystemEntries(historyCountriesDir, variable.SovereignCountryTag + " - *.txt");
                            try
                            {
                                File.AppendAllText(sovereignCountryFile[0], "\nset_autonomy = {\n\ttarget = " + variable.CountryTag + "\n\tautonomous_state = autonomy_puppet\n}");
                            }
                            catch (Exception e) when (e is ArgumentException ||
                                                      e is ArgumentNullException ||
                                                      e is PathTooLongException ||
                                                      e is DirectoryNotFoundException ||
                                                      e is IOException ||
                                                      e is UnauthorizedAccessException ||
                                                      e is NotSupportedException ||
                                                      e is SecurityException)
                            {
                                MessageBoxShower.ErrorMessage(e.Message);
                                MessageBoxShower.GenerateStoppedMessage();
                                return 1;
                            }
                        }
                        catch (Exception e) when (e is UnauthorizedAccessException ||
                                                  e is ArgumentException ||
                                                  e is ArgumentNullException ||
                                                  e is PathTooLongException ||
                                                  e is IOException ||
                                                  e is DirectoryNotFoundException)
                        {
                            MessageBoxShower.ErrorMessage(e.Message);
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                    else
                    {
                        try
                        {
                            File.AppendAllText(modFiles[0], "\nset_autonomy = {\n\ttarget = " + variable.CountryTag + "\n\tautonomous_state = autonomy_puppet\n}");
                        }
                        catch (Exception e) when (e is ArgumentException ||
                                                  e is ArgumentNullException ||
                                                  e is PathTooLongException ||
                                                  e is DirectoryNotFoundException ||
                                                  e is IOException ||
                                                  e is UnauthorizedAccessException ||
                                                  e is NotSupportedException ||
                                                  e is SecurityException)
                        {
                            MessageBoxShower.ErrorMessage(e.Message);
                            MessageBoxShower.GenerateStoppedMessage();
                            return 1;
                        }
                    }
                }
                catch (Exception e) when (e is UnauthorizedAccessException ||
                                          e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is PathTooLongException ||
                                          e is IOException ||
                                          e is DirectoryNotFoundException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // カスタム国家指導者が有効化されている場合
            if (variable.CustomLeaderEnabled == true)
            {
                int nlgResult = NationalLeaderGenerate(historyCountrisFilePath, gfxLeadersDir, gfxLeadersTagDir);
                if (nlgResult == 1)
                    return 1;
            }

            // 陣営の作成が有効化されている場合
            if (variable.FactionCreateEnabled == true)
            {
                int fsResult = FactionSetting(historyCountrisFilePath, localisationReplaceDir);
                if (fsResult == 1)
                    return 1;
            }

            // カスタムイデオロギーが有効化されている場合
            if (Properties.Settings.Default.customIdeologiesEnabled == true)
            {
                int cisResult = CustomIdeologiesSetting(historyCountrisFilePath, localisationReplaceDir, gfxFlagsDir);
                if (cisResult == 1)
                    return 1;
            }

            MessageBoxShower.InfoMessage("生成が完了しました。");

            if (Properties.Settings.Default.afterOpenFolder == true)
                Process.Start(variable.Moddir);

            return 0;
        }

        /// <summary>
        /// 国家指導者を生成
        /// </summary>
        /// <returns></returns>
        public int NationalLeaderGenerate(string HistoryCountriesFilePath, string GfxLeadersDir, string GfxLeadersTagDir)
        {
            Variable variable = new Variable();

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
            catch (Exception e) when (e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is PathTooLongException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is UnauthorizedAccessException ||
                                      e is NotSupportedException ||
                                      e is SecurityException)
            {
                MessageBoxShower.ErrorMessage(e.Message);
                MessageBoxShower.GenerateStoppedMessage();
                return 1;
            }


            // ../gfx/leadersディレクトリが存在しない場合にフォルダを作成
            if (Directory.Exists(GfxLeadersDir) == false)
            {
                if (FileSystemInterface.FolderCreate(GfxLeadersDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // ../gfx/leaders/[国家タグ]ディレクトリが存在しない場合にファルダを作成
            if (Directory.Exists(GfxLeadersTagDir) == false)
            {
                if (FileSystemInterface.FolderCreate(GfxLeadersTagDir) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            // 画像ファイルを ../gfx/leaders/[国家タグ]/[国家指導者名].ddsにコピー
            string leaderPicturePath = GfxLeadersTagDir + @"\" + variable.LeaderPictureName;

            if (FileSystemInterface.FileCopy(variable.LeaderPicturePath, leaderPicturePath) == 1)
            {
                MessageBoxShower.GenerateStoppedMessage();
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
                    for ( int cnt = 0; cnt < variable.FactionParticipatingCountries.Length; cnt++ )
                        File.AppendAllText(HistoryCountriesFilePath, "\nadd_to_faction = " + variable.FactionParticipatingCountries[cnt]);
                }
            }
            catch (Exception e) when (e is ArgumentException ||
                                      e is ArgumentNullException ||
                                      e is PathTooLongException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is UnauthorizedAccessException ||
                                      e is NotSupportedException ||
                                      e is SecurityException)
            {
                MessageBoxShower.ErrorMessage(e.Message);
                MessageBoxShower.GenerateStoppedMessage();
                return 1;
            }

            // localisationファイル
            string localisationReplaceFactionsFilePath = LocalisationReplaceDir + @"\"+ variable.ModName +"_factions_l_english.yml";

            if (File.Exists(localisationReplaceFactionsFilePath) == false)
            {
                if (FileSystemInterface.FileCreate(localisationReplaceFactionsFilePath) == 1)
                {
                    MessageBoxShower.GenerateStoppedMessage();
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
                catch (Exception e) when (e is UnauthorizedAccessException ||
                                          e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is DirectoryNotFoundException ||
                                          e is IOException ||
                                          e is PathTooLongException ||
                                          e is SecurityException ||
                                          e is ObjectDisposedException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }
            else
            {
                try
                {
                    File.AppendAllText(localisationReplaceFactionsFilePath, "\n " + variable.FactionInternalName + ":0 \"" + variable.FactionName + "\"");
                }
                catch (Exception e) when (e is ArgumentException ||
                                          e is ArgumentNullException ||
                                          e is PathTooLongException ||
                                          e is DirectoryNotFoundException ||
                                          e is IOException ||
                                          e is UnauthorizedAccessException ||
                                          e is NotSupportedException ||
                                          e is SecurityException)
                {
                    MessageBoxShower.ErrorMessage(e.Message);
                    MessageBoxShower.GenerateStoppedMessage();
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// カスタムイデオロギーの設定
        /// </summary>
        public int CustomIdeologiesSetting(string HistoryCountriesFilePath, string LocalisationReplaceDir, string GfxFlagsDir)
        {
            Variable variable = new Variable();

            // [MODDIR]/localisation/replace/[MODNAME]_countries_l_english.ymlファイルパス
            string localisationReplaceCountriesFilePath = LocalisationReplaceDir + @"\" + variable.ModName + "_countries_l_english.yml";
            // [MODDIR]/localisation/replace/[MODNAME]_parties_l_english.ymlファイルパス
            string localisationReplacePartiesFilePath = LocalisationReplaceDir + @"\" + variable.ModName + "_parties_l_english.yml";
            // [MODDIR]/gfx/flags/mediumディレクトリパス
            string gfxFlagsMediumDir = GfxFlagsDir + @"\menium";
            // [MODDIR]/gfx/flags/smallディレクトリパス
            string gfxFlagsSmallDir = GfxFlagsDir + @"\small";

            for (int cnt = 0; cnt < Properties.Settings.Default.customIdeologiesName.Count - 1; cnt++)
            {
                List<string> historyCountryFile = new List<string>();

                // 国家ファイルの読み込み
                using (StreamReader sr = new StreamReader(HistoryCountriesFilePath))
                {
                    string textLine = "";

                    // 一行ずつListに代入
                    while ((textLine = sr.ReadLine()) != null)
                        historyCountryFile.Add(textLine);

                    string searchString = "set_popularities = {";
                    string insertString = "\t" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + " = " + variable.CustomIdeologiesPopularity[cnt];

                    historyCountryFile.Insert(historyCountryFile.IndexOf(searchString) + 1, insertString); 
                }

                // 国家ファイルの初期化
                using (FileStream fs = new FileStream(HistoryCountriesFilePath, FileMode.Open))
                    fs.SetLength(0);

                // 国家ファイルの書き込み
                using (StreamWriter sw = new StreamWriter(HistoryCountriesFilePath, false))
                {
                    for (int lineNum = 0; lineNum < historyCountryFile.Count; lineNum++)
                        sw.WriteLine(historyCountryFile[lineNum]);
                }

                // ローカリゼーション書き込み
                File.AppendAllText(localisationReplaceCountriesFilePath,
                    "\n " + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + ":0 \"" + variable.CustomIdeologiesSettings[cnt, 0] + "\"\n" +
                    " " + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + "_DEF:0 \"" + variable.CustomIdeologiesSettings[cnt, 1] + "\"\n" +
                    " " + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + "_ADJ:0 \"" + variable.CustomIdeologiesSettings[cnt, 2] + "\"");

                File.AppendAllText(localisationReplacePartiesFilePath,
                    "\n " + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + "_party:0 \"" + variable.CustomIdeologiesSettings[cnt, 6] + "\"\n" +
                    " " + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + "_party_long:0 \"" + variable.CustomIdeologiesSettings[cnt, 7] + "\"");

                // 国旗ファイルをコピー
                string bigFlagPath = GfxFlagsDir + @"\" + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + ".tga";
                string mediumFlagPath = gfxFlagsMediumDir + @"\" + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + ".tga";
                string smallFlagPath = gfxFlagsSmallDir + @"\" + variable.CountryTag + "_" + Properties.Settings.Default.customIdeologiesInternalName[cnt] + ".tga";

                if (File.Exists(bigFlagPath) == false && variable.CustomIdeologiesSettings[cnt, 3] != "")
                {
                    if (FileSystemInterface.FileCopy(variable.CustomIdeologiesSettings[cnt, 3], bigFlagPath) == 1)
                    {
                        MessageBoxShower.GenerateStoppedMessage();
                        return 1;
                    }
                }

                if (File.Exists(mediumFlagPath) == false && variable.CustomIdeologiesSettings[cnt, 4] != "")
                {
                    if (FileSystemInterface.FileCopy(variable.CustomIdeologiesSettings[cnt, 4], mediumFlagPath) == 1)
                    {
                        MessageBoxShower.GenerateStoppedMessage();
                        return 1;
                    }
                }

                if (File.Exists(smallFlagPath) == false && variable.CustomIdeologiesSettings[cnt, 5] != "")
                {
                    if (FileSystemInterface.FileCopy(variable.CustomIdeologiesSettings[cnt, 5], smallFlagPath) == 1)
                    {
                        MessageBoxShower.GenerateStoppedMessage();
                        return 1;
                    }
                }
            }

            return 0;
        }
    }
}