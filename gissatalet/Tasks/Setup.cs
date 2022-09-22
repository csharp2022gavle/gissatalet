using gissatalet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet.Tasks
{
    internal class Setup 
    {
    public static async Task MainTask()
        {
            string loadingHigschore = Strings.Localization("loadingHighscore");
            string loadingFont = Strings.Localization("loadingFont");
            string complete = Strings.Localization("complete");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SetCursor.SetXandWrite(loadingHigschore);
            Task.Delay(500).GetAwaiter().GetResult();
            await CreateHighscore.MainTask(Tasks.Users);
            Task.Delay(500).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(Views.Views.space);
            SetCursor.SetXandWrite(complete);
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(loadingFont);
            await DownloadFont.MainTask();
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(Views.Views.space);
            SetCursor.SetXandWrite(complete);
            Task.Delay(200).GetAwaiter().GetResult();
        }
    }
}
