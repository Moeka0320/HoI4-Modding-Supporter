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
            {"despotism", "独裁主義者" },
            {"oligarchism", "寡頭主義者" },
            {"anarchism", "無政府主義者" },
            {"moderatism", "近代主義者" },
            {"centrism", "中道主義者" },
            {"conservatism", "保守主義者" },
            {"liberalism", "自由主義者" },
            {"socialism", "社会主義者" },
            {"nazism", "国家社会主義者" },
            {"fascism_ideology", "ファシスト" },
            {"falangism", "ファランジスト" },
            {"rexism", "レクシスト" },
            {"marxism", "マルクス主義者" },
            {"leninism", "レーニン主義者" },
            {"stalinism", "スターリン主義者" },
            {"anti_revisionism", "反修正主義者" },
            {"anarchist_communism", "無政府共産主義者" },
            {"popularities", "政党支持率" },
            {"party", "政党" },
            {"vew", "表示名" },
            {"def", "通称名" },
            {"adj", "正式名" },
            {"election", "選挙" },
            {"political_power", "政治力" },
            {"convoy", "輸送船" },
            {"stability", "安定度" },
            {"war_support", "戦争協力度" },
            {"teach_slot", "研究スロット" },
            {"state", "ステート" },
            {"province", "プロヴィンス" },
            {"faction", "陣営" },


        };
    }
}
