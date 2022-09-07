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
        public static string space = "                                                                                    ";
        static void Main(string[] args)
        {
            bool startaSpel = true;
            while (startaSpel == true)
            {
                Titel();
                Meny();
                string makeAMove = "Gör ett val: ";
                setXandWrite(makeAMove, 5);
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
            setXandWrite(optionOne,1);
            setXandWrite(optionTwo,2);
            setXandWrite(optionThree,3);
        }
        public static void NewGame()
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
            setXandWrite(input);
            setXandWrite("> ", 1);
            string name = Console.ReadLine();
            setXandWrite(space);
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
                setXandWrite(userBack, 5);
                setXandWrite(space);
                string gissaText = "Gissa ett nummer mellan 1 - 10";
                setXandWrite(gissaText);
                setXandWrite(space, 1);
                setXandWrite(prompt, 1)
                int gissning = 0;
                string aGissning = Console.ReadLine();
                try 
                {
                    gissning = Int32.Parse(aGissning);
                }
                catch (FormatException) 
                {
                    string error = "Du måste skriva in ett nummer!";
                    setXandWrite(error,3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    string correct = "Du gissade rätt!";
                    string press = "Tryck på (N) för att avsluta eller, Tryck på valfri tangent för att fortsätta.";
                    setXandWrite(space, -1);
                    setXandWrite(correct, -1);
                    setXandWrite(press);
                    setXandWrite(prompt, 1);
                    string yN = Console.ReadLine().ToLower();
                    ++score;
                    userScore.Insert(tempUserIndex, score);
                    setXandWrite(space);
                    if (yN == "n") nyttSpel = false;
                    else 
                    {
                        setXandWrite(space, -1);
                        setXandWrite(space);
                    }
                }

                else if (gissning < slumpTal)
                {   
                    string guessLow = "Du gissade lägre än talet.";
                    setXandWrite(space, -1);
                    setXandWrite(guessLow, -1);
                }

                else
                {
                    string guessHigh = "Du gissade högre än talet.";
                    setXandWrite(space, -1);
                    setXandWrite(guessHigh, -1);
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
            if (userList.Count == 0) 
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
            setXandWrite(description);
            foreach (var user in highScore) 
            {
                ++Xpos;
                setXandWrite(user, ++Xpos);
            }
            string pressAny = "Tryck på valfri knapp för att återgå till huvudmenyn.";
            setXandWrite(pressAny, 5);
            Console.ReadLine();
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
                      ░  ░        ░        ░        ░  ░                  ░  ░    ░  ░   ░  ░        ";
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
        public static void setXandWrite(string setWord)    
        {
            Console.SetCursorPosition(windowWidth.SetWidth(setWord), windowWidth.SetXpos());
            Console.Write(setWord);
        }
        public static void setXandWrite(string setWord, int setNewXpos)    
        {
            Console.SetCursorPosition(windowWidth.SetWidth(setWord), windowWidth.SetXpos(setNewXpos));
            Console.Write(setWord);
        }
    }
}