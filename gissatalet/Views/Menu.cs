using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gissatalet.models;

namespace gissatalet.views
{
    internal class Menu
    {
        public static void MainTask()
        {
            string optionOne = string.Format(Strings.Localization("optionOne"));
            string optionTwo = string.Format(Strings.Localization("optionTwo"));
            string optionThree = string.Format(Strings.Localization("optionThree"));
            SetCursor.SetXandWrite(optionOne, 1);
            SetCursor.SetXandWrite(optionTwo, 2);
            SetCursor.SetXandWrite(optionThree, 3);
        }
    }
}
