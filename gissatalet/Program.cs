namespace gissatalet
{
    internal sealed class Program
    {
        static async Task Main(string[] args)
        {
            Console.CursorVisible = false;
            View.Init();
            var setup = Tasks.Setup();
            while (setup.IsCompleted == false) 
            {
                for (int i = 0; i < View.spinner.Length ; i++)
                {
                    Thread.Sleep(20);
                    SetCursor.SetXandWrite(View.spinner[i], 3);
                }  
            }
            await setup;
            bool startaSpel = true;
            while (startaSpel == true)
            {
                View.Front();
                string userValue = Console.ReadLine()!;
                if (userValue == "1") View.NewGame();
                if (userValue == "2") View.Highscore();
                if (userValue == "3")
                {
                    View.Init();
                    await File.WriteAllTextAsync(Tasks.path, "");
                    foreach (var item in Tasks.Users) await Tasks.ToFile(item.score.ToString(), item.name, item.tries.ToString());
                    startaSpel = false;
                }
            }
        }
    }
}