namespace gissatalet
{
    internal sealed class Tasks
    {
        public static List<User> Users = new();
        public static string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "Spelare.txt");
        public static string fontPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "font.flf");
        public static int Xpos;
        public static async Task Setup() 
        {
            string loadingHigschore = "Loading Highscore.....";
            string loadingFont = "Downloading ascii font.....";
            string complete = "Complete!";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SetCursor.SetXandWrite(loadingHigschore);
            Task.Delay(500).GetAwaiter().GetResult();
            await Tasks.CreateHighscore(Tasks.Users);
            Task.Delay(500).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(View.space);
            SetCursor.SetXandWrite(complete);
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(loadingFont);
            await Tasks.DownloadFont();
            Task.Delay(200).GetAwaiter().GetResult();
            SetCursor.SetXandWrite(View.space);
            SetCursor.SetXandWrite(complete);
            Task.Delay(200).GetAwaiter().GetResult();
        }
        public static async Task CreateHighscore(List<User> Users)
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
                Users.Add(new User(userData[1], Int32.Parse(userData[0]), Int32.Parse(userData[2])));
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
            for (int i = 0; i < result.Length; i++) 
            {
                int centerLeftSpace = (Console.WindowWidth / 2) - (result[2].Length / 2);
                Console.SetCursorPosition(centerLeftSpace, 2+i);
                Console.Write(result[i]+ System.Environment.NewLine);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static async Task ToFile(string userScore, string name, string tries)
        {
            string[] textFilePath = await File.ReadAllLinesAsync(path);
            List<string> textFile = new(textFilePath);
            if (!textFile.Contains(name))
            {
                string appendText = userScore + " | " + name + " | " + tries + Environment.NewLine;
                await File.AppendAllTextAsync(path, appendText);
            }
        } 
    }
}