using System.Threading.Channels;
using gissatalet.Tasks;
using gissatalet.Views;

namespace gissatalet
{

    internal sealed class Program
    {
        static async Task Main(string[] args)
        {
            Views.Views.Init();
            Strings.GetAndUseLocalizationFiles();
            Console.CursorVisible = false;
            Views.Views.Init();
            var setup = Tasks.Setup.MainTask();
            while (setup.IsCompleted == false) 
            {
                for (int i = 0; i < Views.Views.spinner.Length ; i++)
                {
                    Thread.Sleep(20);
                    SetCursor.SetXandWrite(Views.Views.spinner[i], 3);
                }  
            }
            await setup;
            bool startaSpel = true;
            while (startaSpel == true)
            {
                Views.Front.MainTask();
                string userValue = Console.ReadLine()!;
                if (userValue == "1") Views.NewGame.MainTask();
                if (userValue == "2") Views.Highscore.MainTask();
                if (userValue == "3")
                {
                    Views.Views.Init();
                    await File.WriteAllTextAsync(Tasks.Tasks.path, "");
                    foreach (var item in Tasks.Tasks.Users) await Tasks.ToFile.MainTask(item.score.ToString(), item.name, item.tries.ToString());
                    startaSpel = false;
                }
            }
        }
    }
}
