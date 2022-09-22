using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gissatalet.models;

namespace gissatalet.views
{
    public class Front
    {
        public static void MainTask()
        {
            models.Titel.MainTask(Strings.Localization("TitleMain"));
            Menu.MainTask();
            string makeAMove = Strings.Localization("MakeAMove");
            SetCursor.SetXandWrite(makeAMove, 5);
            SetCursor.SetXandWrite("> ", 6);
            Console.CursorVisible = true;
        }
    }
}
