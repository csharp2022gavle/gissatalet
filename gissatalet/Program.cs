﻿using System.Collections.Generic;
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
            Console.WriteLine("# [1] Starta ett nytt spel");
            Console.WriteLine("# [2] Se aktuellt Highscore");
            Console.WriteLine("# [3] Avsluta");
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
                    int tempUserIndex = userList.IndexOf(user);
                    string userBack = string.Format("Du {0} har {1} poäng!", user, tempUserScore);
                    Console.WriteLine(userBack);
                    int score = 1;
                    userScore[tempUserIndex] += score;
                }
            }

            for (int i = 0; i < userScore.Count; i++)
            {
                            }
        }
        public static void Highscore() 
        {
            if (userList.Count == 0) 
            {
                for (int i = 0; i < 5; i++)
                {
                    userList.Add(String.Format("User {0}", i));
                    userScore.Add(i);
                }
            }
            foreach (var user in userList) 
            {
                int tempScoreIndex = userList.IndexOf(user);

                List<string> highscore = new List<string>();
                highscore.Add(user + " " + tempScoreIndex);
                highscore.Sort();
                foreach (var item in highscore) 
                {
                    Console.WriteLine(highscore);
                }
            }
        }

    }
}