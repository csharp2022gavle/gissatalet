using gissatalet.models;
using gissatalet.views;

namespace gissatalet
{
    internal sealed class Program
    {
        static async Task Main(string[] args)
        {
            Views.Init();
            Strings.GetAndUseLocalizationFiles();
            Console.CursorVisible = false;
            Views.Init();
            var setup = Setup.MainTask();
            while (setup.IsCompleted == false) 
            {
                for (int i = 0; i < Views.Spinner.Length ; i++)
                {
                    Thread.Sleep(20);
                    SetCursor.SetXandWrite(Views.Spinner[i], 3);
                }  
            }
            await setup;
            bool startaSpel = true;
            while (startaSpel)
            {
                Front.MainTask();
                string userValue = Console.ReadLine()!;
                if (userValue == "1") NewGame.MainTask();
                if (userValue == "2") Highscore.MainTask();
                if (userValue == "3")
                {
                    Views.Init();
                    await File.WriteAllTextAsync(Tasks.Path, "");
                    foreach (var item in Tasks.Users) await ToFile.MainTask(item.Score.ToString(), item.Name, item.Tries.ToString());
                    startaSpel = false;
                }
            }
        }
    }
}
