using System.Net;
namespace gissatalet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tasks.CreateHighscore(Tasks.users);
            Tasks.DownloadFont();
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
                    File.WriteAllText(Tasks.path, "");
                    foreach (var item in Tasks.users) Tasks.ToFile(item.Item1.ToString(), item.Item2.ToString());
                    startaSpel = false;
                }
            }
        }
    }
}