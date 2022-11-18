namespace gissatalet.models
{
    internal class Setup 
    {
    public static async Task MainTask()
        {
            Database.Setup();
            string loadingHigschore = Strings.Localization("loadingHighscore");
            string loadingFont = Strings.Localization("loadingFont");
            string complete = Strings.Localization("complete");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SetCursor.SetXandWrite(loadingHigschore);
            Task.Delay(500).GetAwaiter().GetResult();
            await CreateHighscore.MainTask(Tasks.Users);
            Task.Delay(500).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(views.Views.Space);
            SetCursor.SetXandWrite(complete);
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(loadingFont);
            await DownloadFont.MainTask();
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(views.Views.Space);
            SetCursor.SetXandWrite(complete);
            Task.Delay(200).GetAwaiter().GetResult();
        }
    }
}
