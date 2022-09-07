using System.Net;

namespace gissatalet
{
    internal class Program
    {
        public static List<string> userList = new();
        public static List<int> userScore = new();
        public static int tempUserScore;
        public static int Xpos = 13;
        public static string fontPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "font.flf)");
        private static Stream fontStream;

        public static void Init() { Xpos = 13; Console.Clear(); }
        public static WindowWidth windowWidth = new();
        public static string space = "                                                                                    ";
        static void Main(string[] args)
        {
            WebClient client = new();
            File.WriteAllText(fontPath, client.DownloadString("https://raw.githubusercontent.com/xero/figlet-fonts/master/Bloody.flf"));
            bool startaSpel = true;
            while (startaSpel == true)
            {
                Titel();
                Meny();
                string makeAMove = "Gör ett val: ";
                SetXandWrite(makeAMove, 5);
                string userValue = Console.ReadLine();
                if (userValue == "1")
                {
                    Init();
                    NewGame();
                }
                if (userValue == "2")
                {
                    Init();
                    Highscore();
                }
                if (userValue == "3")
                {
                    startaSpel = false;
                    Console.Clear();
                }
            }
        }
        public static void Meny()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string optionOne = string.Format("1) Spela Gissa Talet!");
            string optionTwo = string.Format("2) Se Highscore!");
            string optionThree = string.Format("3) Avsluta :(");
            SetXandWrite(optionOne,1);
            SetXandWrite(optionTwo,2);
            SetXandWrite(optionThree,3);
        }
        public static void NewGame()
        {
            fontStream = new FileStream(fontPath, FileMode.Open, FileAccess.Read);
            var font = new WenceyWang.FIGlet.FIGletFont(fontStream);
            var text = new WenceyWang.FIGlet.AsciiArt("        NEW GAME!", font: font);
            text.ToString(); var result = text.Result;
            Console.WriteLine(space);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
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
                    tempUserIndex = userList.Count()-1;
                    score = userScore[tempUserIndex];
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
                    gissning = Int32.Parse(aGissning);
                }
                catch (FormatException) 
                {
                    string error = "Du måste skriva in ett nummer!";
                    SetXandWrite(error,3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    string correct = "Du gissade rätt!";
                    string press = "Tryck på (N) för att avsluta eller, Tryck på valfri tangent för att fortsätta.";
                    SetXandWrite(space, -1);
                    SetXandWrite(correct, -1);
                    SetXandWrite(press);
                    SetXandWrite(prompt, 1);
                    string yN = Console.ReadLine().ToLower();
                    ++score;
                    userScore.Insert(tempUserIndex, score);
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
            fontStream = new FileStream(fontPath, FileMode.Open, FileAccess.Read);
            var font = new WenceyWang.FIGlet.FIGletFont(fontStream);
            var text = new WenceyWang.FIGlet.AsciiArt("       HighScore!", font: font);
            text.ToString(); var result = text.Result;
            Console.WriteLine(space);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(@result[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            List<string> highScore = new();
            if (userList.Count == 0) 1
            {
                userList.Add("Local Extremum");
                userScore.Add(3);
                userList.Add("The Double Equation");
                userScore.Add(1);
                userList.Add("Root Of Pi");
                userScore.Add(4);
                userList.Add("Golden ratio");
                userScore.Add(2);
            }
            foreach (var user in userList)
            {
                int tempIndex = userList.IndexOf(user);
                highScore.Add(userScore[tempIndex].ToString() + " | " + user);
            }
            highScore.Sort();
            highScore.Reverse();
            string description = "POÄNG | NAMN";
            SetXandWrite(description);
            int next = 1;
            foreach (var user in highScore) 
            {
                ++next;
                SetXandWrite(user, ++next);
            }
            string pressAny = "Tryck på valfri knapp för att återgå till huvudmenyn.";
            SetXandWrite(pressAny, 13);
            Console.ReadLine();
        }
        public static void Titel()
        {
            Console.Clear();
            fontStream = new FileStream(fontPath, FileMode.Open, FileAccess.Read);
            var font = new WenceyWang.FIGlet.FIGletFont(fontStream);
            var text = new WenceyWang.FIGlet.AsciiArt("      Gissa Talet", font: font);
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
                return MaxWidth() -( word.Length/2 );
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
    }
}