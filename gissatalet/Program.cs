using System.Collections.Generic;
using System.Reflection.Metadata;

namespace gissatalet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool startaSpel = true;
            /* Titel sida , meny, promt 1-3
             * New game
                Startar ett nytt spel direkt med en ny skärm
                    Gissa ett tal mellasn 1 - 10
                    Gissar du rätt skriv in ditt namn
                    Fortsätt spela eller avsluta
             * Highscore
                - Namn, Poäng(antal rätt gissningar)

             * Quit
            */
            while (startaSpel = true)
            {
                Titel();
                string userValue = Console.ReadLine();
                Meny(startaSpel);
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
                    startaSpel = false;
                }
                Console.ReadLine();
            }

        }
        public static List<string> userList = new List<string>();
        public static List<int> userScore = new List<int>();
        public static int tempUserScore;
        public static void Meny(Boolean gameOn)
        {


        }
        public static void NewGame()
        {
            Console.WriteLine("Nu startas ett spel skriv ditt namn:");
            string name = Console.ReadLine();
            userList.Add(name);
            userScore.Add(0);
            foreach (var user in userList)
            {
                if (userList.Contains(user))
                {
                    int tempUserScore = userList.IndexOf(user);
                    string userBack = string.Format("Du {0} har {1} poäng!", user, tempUserScore);
                    Console.WriteLine(userBack);
                }
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
            string titel = @"
                  ▄████  ██▓  ██████   ██████  ▄▄▄          ▒█████   ██▀███  ▓█████▄ ▓█████▄▄▄█████▓
                 ██▒ ▀█▒▓██▒▒██    ▒ ▒██    ▒ ▒████▄       ▒██▒  ██▒▓██ ▒ ██▒▒██▀ ██▌▓█   ▀▓  ██▒ ▓▒
                ▒██░▄▄▄░▒██▒░ ▓██▄   ░ ▓██▄   ▒██  ▀█▄     ▒██░  ██▒▓██ ░▄█ ▒░██   █▌▒███  ▒ ▓██░ ▒░
                ░▓█  ██▓░██░  ▒   ██▒  ▒   ██▒░██▄▄▄▄██    ▒██   ██░▒██▀▀█▄  ░▓█▄   ▌▒▓█  ▄░ ▓██▓ ░ 
                ░▒▓███▀▒░██░▒██████▒▒▒██████▒▒ ▓█   ▓██▒   ░ ████▓▒░░██▓ ▒██▒░▒████▓ ░▒████▒ ▒██▒ ░ 
                    ░▒   ▒ ░▓  ▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░ ▒▒   ▓▒█░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░ ▒▒▓  ▒ ░░ ▒░ ░ ▒ ░░   
                    ░   ░  ▒ ░░ ░▒  ░ ░░ ░▒  ░ ░  ▒   ▒▒ ░     ░ ▒ ▒░   ░▒ ░ ▒░ ░ ▒  ▒  ░ ░  ░   ░    
                ░ ░   ░  ▒ ░░  ░  ░  ░  ░  ░    ░   ▒      ░ ░ ░ ▒    ░░   ░  ░ ░  ░    ░    ░      
                        ░  ░        ░        ░        ░  ░       ░ ░     ░        ░       ░  ░        
                                                                                ░                     ";
            Console.WriteLine(titel);

        }
    }
}