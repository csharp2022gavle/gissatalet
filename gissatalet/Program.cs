namespace gissatalet
{
    internal class Program
    {
        public static List<string> userList = new List<string>();
        public static List<int> userScore = new List<int>();
        public static int tempUserScore;
        public static int Xpos = 13;
        public static void Init() { Xpos = 13; Console.Clear(); }
        public static WindowWidth windowWidth = new WindowWidth();
        public static string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "Spelare.txt");
        static void Main(string[] args)
        {
            bool startaSpel = true;
            while (startaSpel == true)
            {
                Titel();
                Meny();
                int xPos = 20;
                int windiwSize = 60;
                string makeAMove = "Gör ett val: ";
                Console.SetCursorPosition(windiwSize - makeAMove.Length/2, xPos);
                Console.Write(makeAMove);
                string userValue = Console.ReadLine();
                if (userValue == "1")
                {
                    Init();
                    NewGame();
                }
                if (userValue == "2")
                {
                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, "");
                    }
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
            Xpos = 13;
            Console.ForegroundColor = ConsoleColor.White;
            string optionOne = string.Format("1) Spela Gissa Talet!");
            string optionTwo = string.Format("2) Se Highscore!");
            string optionThree = string.Format("3) Avsluta :(");
            Console.SetCursorPosition(windowWidth.SetWidth(optionOne), windowWidth.SetXpos(1));
            Console.Write(optionOne);
            Console.SetCursorPosition(windowWidth.SetWidth(optionTwo), windowWidth.SetXpos(2));
            Console.Write(optionTwo);
            Console.SetCursorPosition(windowWidth.SetWidth(optionThree), windowWidth.SetXpos(3));
            Console.Write(optionThree);
        }
        public static async void NewGame()
        {
            string title = @" 
                         ███▄    █ ▓█████  █     █░     ▄████  ▄▄▄       ███▄ ▄███▓▓█████  ▐██▌ 
                         ██ ▀█   █ ▓█   ▀ ▓█░ █ ░█░    ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀  ▐██▌ 
                        ▓██  ▀█ ██▒▒███   ▒█░ █ ░█    ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███    ▐██▌ 
                        ▓██▒  ▐▌██▒▒▓█  ▄ ░█░ █ ░█    ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄  ▓██▒ 
                        ▒██░   ▓██░░▒████▒░░██▒██▓    ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒ ▒▄▄  
                        ░ ▒░   ▒ ▒ ░░ ▒░ ░░ ▓░▒ ▒      ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░ ░▀▀▒ 
                        ░ ░░   ░ ▒░ ░ ░  ░  ▒ ░ ░       ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░ ░  ░ 
                           ░   ░ ░    ░     ░   ░     ░ ░   ░   ░   ▒   ░      ░      ░       ░ 
                                 ░    ░  ░    ░             ░       ░  ░       ░      ░  ░ ░    ";
            Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;
            bool nyttSpel = true;
            Random slump = new Random();
            string input = "Nu startas ett spel skriv ditt namn";
            Console.SetCursorPosition(windowWidth.SetWidth(input), Xpos);
            Console.Write(input);
            Console.SetCursorPosition(windowWidth.MaxWidth(), Xpos+1);
            Console.Write("> ");
            string name = Console.ReadLine();
            Console.SetCursorPosition(windowWidth.SetWidth(input), Xpos);
            Console.Write("                                                 ");

            //userList.Add("Tony");
            //userScore.Add(3);
            int slumpTal = slump.Next(1, 11);
            while (nyttSpel == true)
            {
                int tempUserIndex;
                int score;
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
                Console.SetCursorPosition(windowWidth.SetWidth(userBack), windowWidth.SetXpos(5));
                Console.Write(userBack);
                Console.SetCursorPosition(windowWidth.MaxWidth(), windowWidth.SetXpos(1));
                Console.Write("                                                                        ");
                string gissaText = "Gissa ett nummer mellan 1 - 10";
                Console.SetCursorPosition(windowWidth.SetWidth(gissaText), windowWidth.SetXpos());
                Console.Write("                                              ");
                Console.SetCursorPosition(windowWidth.SetWidth(gissaText), windowWidth.SetXpos());
                Console.Write(gissaText);
                Console.SetCursorPosition(windowWidth.MaxWidth(), windowWidth.SetXpos(1));
                Console.Write("> ");
                int gissning = 0;
                string aGissning = Console.ReadLine();
                try 
                {
                    gissning = Int32.Parse(aGissning);
                }
                catch (FormatException) 
                {
                    string error = "Du måste skriva in ett nummer!";
                    Console.SetCursorPosition(windowWidth.SetWidth(error), windowWidth.SetXpos(3));
                    Console.Write(error);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    string correct = "Du gissade rätt!";
                    string press = "Tryck på (N) för att avsluta eller, Tryck på valfri tangent för att fortsätta.";
                    Console.SetCursorPosition(windowWidth.SetWidth(gissaText), windowWidth.SetXpos(-1));
                    Console.Write("                                                                                    ");
                    Console.SetCursorPosition(windowWidth.SetWidth(correct), windowWidth.SetXpos(-1));
                    Console.Write(correct);
                    Console.SetCursorPosition(windowWidth.SetWidth(press), windowWidth.SetXpos());
                    Console.Write(press);
                    Console.SetCursorPosition(windowWidth.MaxWidth(), windowWidth.SetXpos(1));
                    Console.Write("> ");
                    string yN = Console.ReadLine().ToLower();
                    ++score;
                    userScore.Insert(tempUserIndex, score);
                    Console.SetCursorPosition(windowWidth.SetWidth(press), windowWidth.SetXpos());
                    Console.Write("                                                                                 ");
                    if (yN == "n") nyttSpel = false;
                    else 
                    {
                        Console.SetCursorPosition(windowWidth.SetWidth(correct), windowWidth.SetXpos(-1));
                        Console.Write("                                                                                    ");
                        Console.SetCursorPosition(windowWidth.SetWidth(correct), windowWidth.SetXpos());
                        Console.Write("                                                                                    ");
                    }
                }

                else if (gissning < slumpTal)
                {   
                    string guessLow = "Du gissade lägre än talet.";
                    Console.SetCursorPosition((windowWidth.MaxWidth()), Xpos-1);
                    Console.Write("                                                                                    ");
                    Console.SetCursorPosition(windowWidth.SetWidth(guessLow), windowWidth.SetXpos(-1));
                    Console.Write(guessLow);
                }

                else
                {
                    string guessHigh = "Du gissade högre än talet.";
                    Console.SetCursorPosition(windowWidth.MaxWidth(), windowWidth.SetXpos(-1));
                    Console.Write("                                                                                    ");
                    Console.SetCursorPosition(windowWidth.SetWidth(guessHigh), windowWidth.SetXpos(-1));
                    Console.WriteLine(guessHigh);
                }

            }


            Console.WriteLine();
        }
        public static void Highscore()
        {
            string title = @"
                        ██░ ██  ██▓  ▄████  ██░ ██   ██████  ▄████▄   ▒█████   ██▀███  ▓█████  ▐██▌ 
                       ▓██░ ██▒▓██▒ ██▒ ▀█▒▓██░ ██▒▒██    ▒ ▒██▀ ▀█  ▒██▒  ██▒▓██ ▒ ██▒▓█   ▀  ▐██▌ 
                       ▒██▀▀██░▒██▒▒██░▄▄▄░▒██▀▀██░░ ▓██▄   ▒▓█    ▄ ▒██░  ██▒▓██ ░▄█ ▒▒███    ▐██▌ 
                       ░▓█ ░██ ░██░░▓█  ██▓░▓█ ░██   ▒   ██▒▒▓▓▄ ▄██▒▒██   ██░▒██▀▀█▄  ▒▓█  ▄  ▓██▒ 
                       ░▓█▒░██▓░██░░▒▓███▀▒░▓█▒░██▓▒██████▒▒▒ ▓███▀ ░░ ████▓▒░░██▓ ▒██▒░▒████▒ ▒▄▄  
                        ▒ ░░▒░▒░▓   ░▒   ▒  ▒ ░░▒░▒▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░░ ▒░ ░ ░▀▀▒ 
                        ▒ ░▒░ ░ ▒ ░  ░   ░  ▒ ░▒░ ░░ ░▒  ░ ░  ░  ▒     ░ ▒ ▒░   ░▒ ░ ▒░ ░ ░  ░ ░  ░ 
                        ░  ░░ ░ ▒ ░░ ░   ░  ░  ░░ ░░  ░  ░  ░        ░ ░ ░ ▒    ░░   ░    ░       ░ 
                        ░  ░  ░ ░        ░  ░  ░  ░      ░  ░ ░          ░ ░     ░        ░  ░ ░    
                                            ░                                                      ";
            Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;
            List<string> highScore = new List<string>();
            foreach (var user in userList)
            {
                int tempIndex = userList.IndexOf(user);
                highScore.Add(userScore[tempIndex].ToString() + " | " + user);
            }
            highScore.Sort();
            highScore.Reverse();
            foreach (var item in highScore)
            {
                ToFile(item);
            }

            string description = "POÄNG | NAMN";
            Console.SetCursorPosition(windowWidth.SetWidth(description), windowWidth.SetXpos());
            Console.Write(description);

            string[] HighScoreFile = File.ReadAllLines(path);
            List<string> readHighScoreFile = new List<string>(HighScoreFile);
            readHighScoreFile.Sort();
            readHighScoreFile.Reverse();
            foreach (var user in readHighScoreFile) 
            {
                ++Xpos;
                Console.SetCursorPosition(windowWidth.SetWidth(user), ++Xpos);
                Console.Write(user);
            }
            string pressAny = "Tryck på valfri knapp för att återgå till huvudmenyn.";
            Console.SetCursorPosition(windowWidth.SetWidth(pressAny), windowWidth.SetXpos(5));
            Console.Write(pressAny);
            Console.ReadLine();
        }
        public static void ToFile(string name)
        {
            string[] textFilePath = File.ReadAllLines(path);
            List<string> textFile = new List<string>(textFilePath);
            if (!textFile.Contains(name))
            {
                string appendText = name + Environment.NewLine;
                File.AppendAllText(path, appendText);
            }
        }

        public static void Titel()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string titel = @"
                  ▄████  ██▓  ██████   ██████  ▄▄▄         ▄▄▄█████▓ ▄▄▄       ██▓    ▓█████▄▄▄█████▓
                 ██▒ ▀█▒▓██▒▒██    ▒ ▒██    ▒ ▒████▄       ▓  ██▒ ▓▒▒████▄    ▓██▒    ▓█   ▀▓  ██▒ ▓▒
                ▒██░▄▄▄░▒██▒░ ▓██▄   ░ ▓██▄   ▒██  ▀█▄     ▒ ▓██░ ▒░▒██  ▀█▄  ▒██░    ▒███  ▒ ▓██░ ▒░
                ░▓█  ██▓░██░  ▒   ██▒  ▒   ██▒░██▄▄▄▄██    ░ ▓██▓ ░ ░██▄▄▄▄██ ▒██░    ▒▓█  ▄░ ▓██▓ ░ 
                ░▒▓███▀▒░██░▒██████▒▒▒██████▒▒ ▓█   ▓██▒     ▒██▒ ░  ▓█   ▓██▒░██████▒░▒████▒ ▒██▒ ░ 
                 ░▒   ▒ ░▓  ▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░ ▒▒   ▓▒█░     ▒ ░░    ▒▒   ▓▒█░░ ▒░▓  ░░░ ▒░ ░ ▒ ░░   
                  ░   ░  ▒ ░░ ░▒  ░ ░░ ░▒  ░ ░  ▒   ▒▒ ░       ░      ▒   ▒▒ ░░ ░ ▒  ░ ░ ░  ░   ░    
                ░ ░   ░  ▒ ░░  ░  ░  ░  ░  ░    ░   ▒        ░        ░   ▒     ░ ░      ░    ░      
                      ░  ░        ░        ░        ░  ░                  ░  ░    ░  ░   ░  ░        
                                                                                     ";
            Console.WriteLine(titel);

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
    }
}