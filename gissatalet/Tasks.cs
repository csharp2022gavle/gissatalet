using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet
{
    internal class Tasks
    {
        public static List<Tuple<int, string>> users = new();
        public static string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "Spelare.txt");
        public static string fontPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "font.flf");
        public static int Xpos;
        public static async Task CreateHighscore(List<Tuple<int, string>> users)
        {
            if (!File.Exists(path))  await File.WriteAllTextAsync(path, "");
            string[] HighScoreFile = await File.ReadAllLinesAsync(path);
            for (int i = 0; i < HighScoreFile.Length; ++i)
            {
                string UnsplitUser = HighScoreFile[i];
                String[] userData = UnsplitUser.Split(" | ");
                users.Add(new Tuple<int, string>(Int32.Parse(userData[0]), userData[1]));
            }
        }
        public static async Task DownloadFont()
        {
            WebClient client = new();
            await File.WriteAllTextAsync(fontPath, client.DownloadString("https://raw.githubusercontent.com/xero/figlet-fonts/master/Bloody.flf"));
        }
        public static async Task Titel(string titelText)
        {
            View.Init();
            Stream fontStream;
            fontStream = new FileStream(fontPath, FileMode.Open, FileAccess.Read);
            var font = new WenceyWang.FIGlet.FIGletFont(fontStream);
            var text = new WenceyWang.FIGlet.AsciiArt(titelText, font: font);
            text.ToString(); var result = text.Result;
            Console.WriteLine(View.space);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < result.Length; i++) Console.WriteLine(result[i]);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static async Task ToFile(string userScore, string name)
        {
            string[] textFilePath = await File.ReadAllLinesAsync(path);
            List<string> textFile = new(textFilePath);
            if (!textFile.Contains(name))
            {
                string appendText = userScore + " | " + name + Environment.NewLine;
                await File.AppendAllTextAsync(path, appendText);
            }
        } 
        public static async Task StoreHighscore() 
        {
            await File.WriteAllTextAsync(path, "");
            foreach (var item in users) await ToFile(item.Item1.ToString(), item.Item2.ToString());
        }
    }
}
