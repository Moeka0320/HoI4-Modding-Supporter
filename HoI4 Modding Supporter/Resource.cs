using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoI4_Modding_Supporter
{
    /// <summary>
    /// ゲーム内固有名詞などを格納
    /// </summary>
    class Resource
    {
        public Dictionary<string, string> properNoun = new Dictionary<string, string>()
        {
            {"neutrality", "中道主義"},
            {"democratic", "民主主義"},
            {"fascism", "ファシズム" },
            {"communism", "共産主義" },
            {"despotism", "" },
            {"oligarchism", "" },
            {"anarchism", "" },
            {"moderatism", "" },
            {"centrism", "" },
            {"conservatism", "" },
            {"liberalism", "" },
            {"socialism", "" },
            {"nazism", "" },
            {"fascism_ideology", "" },
            {"rexism", "" },
            {"marxism", "" },
            {"leninism", "" },
            {"stalinism", "" },
            {"anti_revisionism", "" },
            {"anarchist_communism", "" },

        };
    }
}
