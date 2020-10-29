using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HoI4_Modding_Supporter.Workers;

namespace HoI4_Modding_Supporter.Mediators
{
    class UserController
    {
        InputChecker ic = new InputChecker();

        /// <summary>
        /// Main.csの入力チェック
        /// </summary>
        public int MainGenerateChecker(List<TextBox> textBoxes, List<ComboBox> comboBoxes, List<CheckBox> checkBoxes)
        {
            return ic.MainGenrateChecker(textBoxes, comboBoxes, checkBoxes);
        }
    }
}
