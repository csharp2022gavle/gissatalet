using System.Threading.Channels;
using gissatalet.models;
using gissatalet.views;

namespace gissatalet
{

    internal sealed class Program
    {
        static async Task Main(string[] args)
        {
            views.Views.Init();
            models.Strings.GetAndUseLocalizationFiles();
            Console.CursorVisible = false;
            views.Views.Init();
            var setup = models.Setup.MainTask();
            while (setup.IsCompleted == false) 
            {
                for (int i = 0; i < views.Views.spinner.Length ; i++)
                {
                    Thread.Sleep(20);
                    SetCursor.SetXandWrite(views.Views.spinner[i], 3);
                }  
            }
            await setup;
            bool startaSpel = true;
            while (startaSpel == true)
            {
                views.Front.MainTask();
                string userValue = Console.ReadLine()!;
                if (userValue == "1") views.NewGame.MainTask();
                if (userValue == "2") views.Highscore.MainTask();
                if (userValue == "3")
                {
                    views.Views.Init();
                    await File.WriteAllTextAsync(models.Tasks.path, "");
                    foreach (var item in models.Tasks.Users) await models.ToFile.MainTask(item.Score.ToString(), item.Name, item.Tries.ToString());
                    startaSpel = false;
                }
            }
        }
    }
}
