using System.Linq;
using System.Net;

namespace gissatalet
{
    internal class Program
    {
        public static List<string> userList = new();
        public static List<int> userScore = new();
        public static int tempUserScore;
        public static int Xpos;
        public static string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "Spelare.txt");
        public static string fontPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "font.flf)");
        private static Stream fontStream;
        public static void Init() { Xpos = 13; Console.Clear(); }
        public static WindowWidth windowWidth = new();
        public static string space = "                                                                                    ";
        static void Main(string[] args)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "");
            }
            string[] HighScoreFile = File.ReadAllLines(path);
            for (int i = 0; i < HighScoreFile.Length; ++i)
            {
                string UnsplitUser = HighScoreFile[i];
                String[] userData = UnsplitUser.Split(" | ");
                int userUnSetScore = Int32.Parse(userData[0]);
                string user = userData[1];
                userList.Add(user);
                userScore.Add(userUnSetScore);
            }
            WebClient client = new();
            File.WriteAllText(fontPath, client.DownloadString("https://raw.githubusercontent.com/xero/figlet-fonts/master/Bloody.flf"));
            bool startaSpel = true;
            while (startaSpel == true)
            {
                Titel("      Gissa Talet");
                Meny();
                string makeAMove = "Gör ett val: ";
                SetXandWrite(makeAMove, 5);
                string userValue = Console.ReadLine();
                if (userValue == "1")
                {
                    NewGame();
                }
                if (userValue == "2")
                {
                    Highscore();
                }
                if (userValue == "3")
                {
                    Init();
                    File.WriteAllText(path, "");
                    foreach (var item in userList)
                    {
                        int tempUserUpload = userList.FindIndex(a => a.Contains(item));
                        string tempUserUploadScore = userScore[tempUserUpload].ToString();
                        ToFile(tempUserUploadScore, item);
                    }
                    startaSpel = false;
                }
            }
        }
        public static void Meny()
        {
            string optionOne = string.Format("1) Spela Gissa Talet!");
            string optionTwo = string.Format("2) Se Highscore!");
            string optionThree = string.Format("3) Avsluta :(");
            SetXandWrite(optionOne, 1);
            SetXandWrite(optionTwo, 2);
            SetXandWrite(optionThree, 3);
        }
        public static void NewGame()
        {
            Titel("        NEW GAME!");
            bool nyttSpel = true;
            Random slump = new();
            string input = "Nu startas ett spel skriv ditt namn";
            SetXandWrite(input);
            SetXandWrite("> ", 1);
            string name = Console.ReadLine();
            SetXandWrite(space);
            int slumpTal = slump.Next(1, 11);
            while (nyttSpel == true)
            {
                int tempUserIndex;
                int score;
                string prompt = "> ";
                if (userList.Contains(name))
                {
                    tempUserIndex = userList.FindIndex(a => a.Contains(name));
                    score = userScore[tempUserIndex];
                }
                else
                {
                    userList.Add(name);
                    userScore.Add(0);
                    score = 0;
                    tempUserIndex = userList.Count()-1;
                }
                string userBack = string.Format("Du {0} har {1} poäng!", userList[tempUserIndex], score);
                SetXandWrite(userBack, 5);
                SetXandWrite(space);
                string gissaText = "Gissa ett nummer mellan 1 - 10";
                SetXandWrite(gissaText);
                SetXandWrite(space, 1);
                SetXandWrite(prompt, 1);
                int gissning = 0;
                string aGissning = Console.ReadLine();
                try
                {
                    SetXandWrite(space, 3);
                    gissning = Int32.Parse(aGissning);
                }
                catch (FormatException)
                {
                    string error = "Du måste skriva in ett nummer!";
                    SetXandWrite(error, 3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    string correct = "Du gissade rätt!";
                    string press = "Tryck på (N) för att avsluta eller, Tryck på valfri tangent för att fortsätta.";
                    score++;
                    userScore.RemoveAt(tempUserIndex);
                    userScore.Insert(tempUserIndex, score);
                    SetXandWrite(space, -1);
                    SetXandWrite(correct, -1);
                    SetXandWrite(press);
                    SetXandWrite(prompt, 1);
                    string yN = Console.ReadLine().ToLower();
                    SetXandWrite(space);
                    if (yN == "n") nyttSpel = false;
                    else
                    {
                        SetXandWrite(space, -1);
                        SetXandWrite(space);
                    }
                }
                else if (gissning < slumpTal)
                {
                    string guessLow = "Du gissade lägre än talet.";
                    SetXandWrite(space, -1);
                    SetXandWrite(guessLow, -1);
                }
                else
                {
                    string guessHigh = "Du gissade högre än talet.";
                    SetXandWrite(space, -1);
                    SetXandWrite(guessHigh, -1);
                }
            }
            Console.WriteLine();
        }
        public static void Highscore()
        {
            Titel("       HighScore!");
            var highScore = new List<Tuple<int, string>>();
            foreach (var user in userList)
            {
                int tempIndex = userList.IndexOf(user);
                highScore.Add(new Tuple<int, string>(userScore[tempIndex], user));
            }
            highScore.Sort((e1, e2) =>
            {
                return e2.Item1.CompareTo(e1.Item1);
            });
            string top3 = "De top 3 Bästa spelana";
            SetXandWrite(top3);
            string description = "POÄNG | NAMN";
            SetXandWrite(description, 2);
            int next = 3;
            if (highScore.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    string user = string.Format("{0} | {1}", highScore[i].Item1.ToString(), highScore[i].Item2);
                    ++next;
                    SetXandWrite(user, ++next);
                }
            }
            else
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    string user = highScore[i].ToString();
                    ++next;
                    SetXandWrite(user, ++next);
                }
            }
            string pressAny = "Tryck på valfri knapp för att återgå till huvudmenyn.";
            SetXandWrite(pressAny, 13);
            Console.ReadLine();
        }
        public static void Titel(string titelText)
        {
            Init();
            fontStream = new FileStream(fontPath, FileMode.Open, FileAccess.Read);
            var font = new WenceyWang.FIGlet.FIGletFont(fontStream);
            var text = new WenceyWang.FIGlet.AsciiArt(titelText, font: font);
            text.ToString(); var result = text.Result;
            Console.WriteLine(space);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public class WindowWidth
        {
            public int MaxWidth()
            {
                return Console.WindowWidth/2;
            }
            public int SetWidth(string word)
            {
                return MaxWidth() -(word.Length/2);
            }
            public int SetXpos()
            {
                return Xpos;
            }
            public int SetXpos(int yneg)
            {
                return Xpos + (yneg);
            }
        }
        public static void SetXandWrite(string setWord)
        {
            Console.SetCursorPosition(windowWidth.SetWidth(setWord), windowWidth.SetXpos());
            Console.Write(setWord);
        }
        public static void SetXandWrite(string setWord, int setNewXpos)
        {
            Console.SetCursorPosition(windowWidth.SetWidth(setWord), windowWidth.SetXpos(setNewXpos));
            Console.Write(setWord);
        }
        public static void ToFile(string userScore, string name)
        {
            string[] textFilePath = File.ReadAllLines(path);
            List<string> textFile = new(textFilePath);
            if (!textFile.Contains(name))
            {
                string appendText = userScore + " | " + name + Environment.NewLine;
                File.AppendAllText(path, appendText);
            }
        }
    }
}