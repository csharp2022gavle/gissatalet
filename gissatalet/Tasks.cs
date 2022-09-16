using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet
{
    internal sealed class Tasks
    {
        public static List<Tuple<int, string>> users = new();
        public static string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "Spelare.txt");
        public static string fontPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "font.flf");
        public static int Xpos;

        public static async Task Setup() 
        {
            
            string loadingHigschore = "Loading Highscore.....";
            string loadingFont = " Downloading ascii font.....";
            string complete = " Complete!";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SetCursor.SetXandWrite(loadingHigschore, 13);
            Task.Delay(500).GetAwaiter().GetResult();
            await Tasks.CreateHighscore(Tasks.users);
            Task.Delay(500).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(View.space, 13);
            SetCursor.SetXandWrite(complete, 13);
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(loadingFont, 13);
            await Tasks.DownloadFont();
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(View.space, 13);
            SetCursor.SetXandWrite(complete, 13);
            Task.Delay(200).GetAwaiter().GetResult();
        }
        public static async Task CreateHighscore(List<Tuple<int, string>> users)
        {
            if (!File.Exists(path)) 
            {
                string higschoreCreate = "Highscore doesn't existst, creating file....";
                string complete = " Complete!";
                SetCursor.SetXandWrite(higschoreCreate, 13);
                await File.WriteAllTextAsync(path, "");
                Thread.Sleep(1000);
                SetCursor.SetXandWrite(View.space, 13);
                SetCursor.SetXandWrite(complete, 13);
                Thread.Sleep(200);
            }
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
            HttpClient client = new();
            var response = await client.GetStringAsync("https://raw.githubusercontent.com/xero/figlet-fonts/master/Bloody.flf");
            await File.WriteAllTextAsync(fontPath, response.ToString());
        }
        public static void Titel(string titelText)
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
