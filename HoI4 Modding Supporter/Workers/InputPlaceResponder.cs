using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HoI4_Modding_Supporter.Workers
{
	/// <summary>
	/// ユーザーによって入力される場所を返す
	/// </summary>
	class InputPlaceResponder
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="tag">コントロールのTag</param>
		/// <returns></returns>
		public string ReturnMainInputPlace(string tag)
		{

			switch (tag)
			{
				case "CountryTag":
					return "[国家タグ]";

				case "ModPrefix":
					return "[Modの接頭語]";

				case "CountryName_Internal":
					return "[国名] - [内部処理用]";

				case "CountryName_NeutralityViewName":
					return "[国名] - [中道主義] - [表示名]";

				case "CountryName_NeutralityDefineName":
					return "[国名] - [中道主義] - [正式名]";

				case "CountryName_NeutralityAdjectiveName":
					return "[国名] - [中道主義] - [通称名]";

				case "CountryName_DemocraticViewName":
					return "[国名] - [民主主義] - [表示名]";

				case "CountryName_DemocraticDefineName":
					return "[国名] - [民主主義] - [正式名]";

				case "CountryName_DemocraticAdjectiveName":
					return "[国名] - [民主主義] - [通称名]";

				case "CountryName_FascismViewName":
					return "[国名] - [ファシズム] - [表示名]";

				case "CountryName_FascismDefineName":
					return "[国名] - [ファシズム] - [正式名]";

				case "CountryName_FascismAdjectiveName":
					return "[国名] - [ファシズム] - [通称名]";

				case "CountryName_CommunismViewName":
					return "[国名] - [共産主義] - [表示名]";

				case "CountryName_CommunismDefineName":
					return "[国名] - [共産主義] - [正式名]";

				case "CountryName_CommunismAdjectiveName":
					return "[国名] - [共産主義] - [通称名]";

				case "CountryFlag_NeutralityBigFlagPath":
					return "[国旗] - [中道主義] - [大]";

				case "CountryFlag_NeutralityMediumFlagPath":
					return "[国旗] - [中道主義] - [中]";

				case "CountryFlag_NeutralitySmallFlagPath":
					return "[国旗] - [中道主義] - [小]";

				case "CountryFlag_DemocraticBigFlagPath":
					return "[国旗] - [民主主義] - [大]";

				case "CountryFlag_DemocraticMediumFlagPath":
					return "[国旗] - [民主主義] - [中]";

				case "CountryFlag_DemocraticSmallFlagPath":
					return "[国旗] - [民主主義] - [小]";

				case "CountryFlag_FascismBigFlagPath":
					return "[国旗] - [ファシズム] - [大]";

				case "CountryFlag_FascismMediumFlagPath":
					return "[国旗] - [ファシズム] - [中]";

				case "CountryFlag_FascismSmallFlagPath":
					return "[国旗] - [ファシズム] - [小]";

				case "CountryFlag_CommunismBigFlagPath":
					return "[国旗] - [共産主義] - [大]";

				case "CountryFlag_CommunismMediumFlagPath":
					return "[国旗] - [共産主義] - [中]";

				case "CountryFlag_CommunismSmallFlagPath":
					return "[国旗] - [共産主義] - [小]";

				case "PartyName_NeutralityViewName":
					return "[政党名] - [中道主義] - [表示名]";

				case "PartyName_NeutralityAdjectiveName":
					return "[政党名] - [中道主義] - [正式名]";

				case "PartyName_DemocraticViewName":
					return "[政党名] - [民主主義] - [表示名]";

				case "PartyName_DemocraticAdjectiveName":
					return "[政党名] - [民主主義] - [正式名]";

				case "PartyName_FascismViewName":
					return "[政党名] - [ファシズム] - [表示名]";

				case "PartyName_FascismAdjectiveName":
					return "[政党名] - [ファシズム] - [正式名]";

				case "PartyName_CommunismViewName":
					return "[政党名] - [共産主義] - [表示名]";

				case "PartyName_CommunismAdjectiveName":
					return "[政党名] - [共産主義] - [正式名]";

				case "SuzeraintyCountryTag":
					return "[各種設定] - [宗主国の国家タグ]";

				case "RegionalSetting":
					return "[各種設定] - [汎用顔グラフィックの地域設定]";

				case "DefaultIdeology":
					return "[各種設定] - [初期与党] - [イデオロギー]";

				case "TotalPopularity":
					return "[各種設定] - [初期政党支持率] - [合計]";

				default:
					return null;
			}
		}
	}
}