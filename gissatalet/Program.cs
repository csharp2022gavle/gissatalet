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
            Console.SetCursorPosition(windowWidth.SetWidth(input), Xpos);
            Console.Write(input);
            Console.SetCursorPosition(windowWidth.MaxWidth(), Xpos+1);
            Console.Write("> ");
            string name = Console.ReadLine();
            userList.Add(name);
            userScore.Add(0);
            foreach (var user in userList)
            {
                if (userList.Contains(user))
                {
                    int tempUserIndex = userList.IndexOf(user);
                    string userBack = string.Format("Du {0} har {1} poäng!", user, tempUserScore);
                    Console.WriteLine(userBack);
                    int score = 1;
                    userScore[tempUserIndex] += score;
                }

                else if (gissning < slumpTal)
                {   
                    string guessLow = "Du gissade lägre än talet.";
                    Console.SetCursorPosition((windowWidth.MaxWidth()), Xpos-1);
                    Console.Write("                                                                                    ");
                    Console.SetCursorPosition(windowWidth.SetWidth(guessLow), windowWidth.SetXpos(-1));
                    Console.Write(guessLow);
                }

            for (int i = 0; i < userScore.Count; i++)
            {
            }
        }
        public static void Highscore()
        {
            
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