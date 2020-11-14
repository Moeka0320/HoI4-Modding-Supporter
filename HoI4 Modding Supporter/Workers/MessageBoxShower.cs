using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter.Workers
{
    /// <summary>
    /// メッセージボックス関連の処理
    /// </summary>
    class MessageBoxShower
    {
        /// <summary>
        /// エラーメッセージ
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error - HoI4 Modding Supporter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// インフォメーションメッセージ
        /// </summary>
        /// <param name="message">表示したいメッセージ</param>
        public void InfoMessage(string message)
        {
            MessageBox.Show(message, "Info - HoI4 Modding Supporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 強制停止時の表示メッセージ
        /// </summary>
        public void GenerateStoppedMessage()
        {
            MessageBox.Show("生成処理が強制終了されました。", "Info - HoI4 Modding Supporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
