namespace gissatalet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Tasks.CreateHighscore(Tasks.users);
            await Tasks.DownloadFont();
            bool startaSpel = true;
            while (startaSpel == true)
            {
                View.Front();
                string userValue = Console.ReadLine();
                if (userValue == "1") View.NewGame();
                if (userValue == "2") View.Highscore();
                if (userValue == "3")
                {
                    View.Init();
                    await File.WriteAllTextAsync(Tasks.path, "");
                    foreach (var item in Tasks.users) await Tasks.ToFile(item.Item1.ToString(), item.Item2.ToString());
                    startaSpel = false;
                }
            }
        }
    }
}