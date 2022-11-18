using gissatalet.models;

namespace gissatalet.views
{
    public class Front
    {
        public static void MainTask()
        {
            Titel.MainTask(Strings.Localization("TitleMain"));
            Menu.MainTask();
            string makeAMove = Strings.Localization("MakeAMove");
            SetCursor.SetXandWrite(makeAMove, 5);
            SetCursor.SetXandWrite("> ", 6);
            Console.CursorVisible = true;
        }
    }
}
