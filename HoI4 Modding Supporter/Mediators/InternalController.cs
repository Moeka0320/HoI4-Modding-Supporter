using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using HoI4_Modding_Supporter.Workers;

namespace HoI4_Modding_Supporter.Mediators
{
    /// <summary>
    /// アプリケーションによって呼び出される処理
    /// </summary>
    class InternalController
    {
        MessageBoxShower msb = new MessageBoxShower();

        /// <summary>
        /// エラーメッセージを表示
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public void ErrorMessageShow(string message)
        {
            msb.ErrorMessage(message);
        }

        /// <summary>
        /// インフォメーションメッセージを表示
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public void InfoMessageShow(string message)
        {
            msb.InfoMessage(message);
        }

        /// <summary>
        /// その他のメッセージ（定型文）を表示
        /// </summary>
        /// <param name="type">どのメッセージを表示するか</param>
        public void MessageShow(string type)
        {
            switch (type)
            {
                case "GenerateStopped":
                    msb.GenerateStoppedMessage();
                    break;
            }
        }
    }
}
