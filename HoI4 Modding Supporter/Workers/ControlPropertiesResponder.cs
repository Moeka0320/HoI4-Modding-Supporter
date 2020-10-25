using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoI4_Modding_Supporter.Database;

namespace HoI4_Modding_Supporter.Workers
{
    /// <summary>
    /// フォームの初期プロパティ値を返す
    /// </summary>
    class ControlPropertiesResponder
    {
        Resource rs = new Resource();

        /// <summary>
        /// Main.csのコントロールのラベルを配列で返す
        /// </summary>
        /// <returns></returns>
        public string[] MainFormLabelsResponder()
        {
            string[] properties =
            {
                rs.properNoun["hms"],
                rs.properNoun["neutrality"],
                rs.properNoun["democratic"],
                rs.properNoun["fascism"],
                rs.properNoun["communism"],
                rs.properNoun["neutrality"] + rs.properNoun["party"],
                rs.properNoun["democratic"] + rs.properNoun["party"],
                rs.properNoun["fascism"] + rs.properNoun["party"],
                rs.properNoun["communism"] + rs.properNoun["party"],
                rs.properNoun["vew"] + "：",
                rs.properNoun["def"] + "：",
                rs.properNoun["adj"] + "：",
                rs.properNoun["default"] + rs.properNoun["teach_slot"] + "：",
                rs.properNoun["default"] + rs.properNoun["stability"] + "：",
                rs.properNoun["default"] + rs.properNoun["war_support"] + "：",
                rs.properNoun["default"] + rs.properNoun["political_power"] + "：",
                rs.properNoun["default"] + rs.properNoun["convoy"] + "数：",
                rs.properNoun["default"] + rs.properNoun["popularities"],
                rs.properNoun["neutrality"] + "：",
                rs.properNoun["democratic"] + "：",
                rs.properNoun["fascism"] + "：",
                rs.properNoun["communism"] + "：",
                rs.properNoun["ctag"] + "：",
                rs.properNoun["mod"] + "の接頭語：",
                rs.properNoun["national_leader"] + "の設定",
                "前回の" + rs.properNoun["election"] + " (YYYY/M/D)：",
                rs.properNoun["election"] + "を行う間隔：",
                rs.properNoun["election"] + "なし",
                rs.properNoun["custom_ideology"],
                rs.properNoun["default"] + rs.properNoun["ruling_party"],
            };

            return properties;
        }
    }
}
