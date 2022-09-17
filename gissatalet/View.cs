using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace gissatalet
{
    public sealed class View
    {
        public static readonly string[] spinner = 
        {
            "[    ]",
            "[=   ]",
            "[==  ]",
            "[=== ]",
            "[ ===]",
            "[  ==]",
            "[   =]",
            "[    ]",
            "[   =]",
            "[  ==]",
            "[ ===]",
            "[====]",
            "[=== ]",
            "[==  ]",
            "[=   ]"
        };
        public static string space = "                                                                                    ";
        public static void Init() { Tasks.Xpos = 13; Console.Clear(); }
        public static void Front() 
        {
            Tasks.Titel("Gissa Talet");
            View.Meny();
            string makeAMove = "Gör ett val: ";
            SetCursor.SetXandWrite(makeAMove, 5);
            Console.CursorVisible = true;
        }
        public static void Meny()
        {
            string optionOne = string.Format("1) Spela Gissa Talet!");
            string optionTwo = string.Format("2) Se Highscore!");
            string optionThree = string.Format("3) Avsluta :(");
            SetCursor.SetXandWrite(optionOne, 1);
            SetCursor.SetXandWrite(optionTwo, 2);
            SetCursor.SetXandWrite(optionThree, 3);
        }
        public static void NewGame()
        {
            Tasks.Titel("NEW GAME!");
            bool nyttSpel = true;
            Random slump = new();
            string input = "Nu startas ett spel skriv ditt namn";
            SetCursor.SetXandWrite(input);
            SetCursor.SetXandWrite("> ", 1);
            string name = Console.ReadLine()!;
            SetCursor.SetXandWrite(space);
            int slumpTal = slump.Next(1, 11);
            while (nyttSpel == true)
            {
                int tempUserindex = Tasks.Users.FindIndex(x => x.name == name);
                string prompt = "> ";
                if (tempUserindex == -1)
                {
                    Tasks.Users.Add(new User(name, 0, 0));
                    tempUserindex = Tasks.Users.Count()-1;
                }
                string UserBack = string.Format("Du {0} har {1} poäng på {2} försök", Tasks.Users[tempUserindex].name, Tasks.Users[tempUserindex].score, Tasks.Users[tempUserindex].tries);
                SetCursor.SetXandWrite(UserBack, 5);
                SetCursor.SetXandWrite(space);
                string gissaText = "Gissa ett nummer mellan 1 - 10";
                SetCursor.SetXandWrite(gissaText);
                SetCursor.SetXandWrite(space, 1);
                SetCursor.SetXandWrite(prompt, 1);
                int gissning = 0;
                string aGissning = Console.ReadLine()!;
                try
                {
                    SetCursor.SetXandWrite(space, 3);
                    gissning = Int32.Parse(aGissning);
                    ++Tasks.Users[tempUserindex].tries;
                }
                catch (FormatException)
                {
                    string error = "Du måste skriva in ett nummer!";
                    SetCursor.SetXandWrite(error, 3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    ++Tasks.Users[tempUserindex].score;
                    UserBack = string.Format("Du {0} har {1} poäng på {2} försök", Tasks.Users[tempUserindex].name, Tasks.Users[tempUserindex].score, Tasks.Users[tempUserindex].tries);
                    Thread.Sleep(10);
                    string correct = "Du gissade rätt!";
                    string press = "Tryck på (N) för att avsluta eller, Tryck på valfri tangent för att fortsätta.";
                    SetCursor.SetXandWrite(UserBack, 5);
                    SetCursor.SetXandWrite(space, -1);
                    SetCursor.SetXandWrite(correct, -1);
                    SetCursor.SetXandWrite(press);
                    SetCursor.SetXandWrite(prompt, 1);
                    string yN = Console.ReadLine()!.ToLower();
                    SetCursor.SetXandWrite(space);
                    if (yN == "n") nyttSpel = false;
                    else
                    {
                        SetCursor.SetXandWrite(space, -1);
                        SetCursor.SetXandWrite(space);
                    }
                }
                else if (gissning < slumpTal)
                {
                    string guessLow = "Du gissade lägre än talet.";
                    SetCursor.SetXandWrite(space, -1);
                    SetCursor.SetXandWrite(guessLow, -1);
                }
                else
                {
                    string guessHigh = "Du gissade högre än talet.";
                    SetCursor.SetXandWrite(space, -1);
                    SetCursor.SetXandWrite(guessHigh, -1);
                }
            }
            Console.WriteLine();
        }
        public static void Highscore()
        {
            Console.CursorVisible = false;
            Tasks.Titel("HighScore!");
            var highScore = new List<Tuple<int, string, int>>();
            foreach (var user in Tasks.Users) highScore.Add(new Tuple<int, string, int>(user.score, user.name, user.tries));
            highScore.Sort((e1, e2) => { return (e1.Item3 / e1.Item1).CompareTo((e2.Item3 / e2.Item1)); }); 
            string top3 = "De top 3 Bästa spelana";
            SetCursor.SetXandWrite(top3);
            string description = "POÄNG | NAMN | FÖRSÖK";
            SetCursor.SetXandWrite(description, 2);
            int next = 3;
            if (highScore.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    string user = string.Format("{0} | {1} | {2}", highScore[i].Item1.ToString(), highScore[i].Item2, highScore[i].Item3);
                    ++next;
                    SetCursor.SetXandWrite(user, ++next);
                }
            }
            else
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    string user = string.Format("{0} | {1} | {2}", highScore[i].Item1.ToString(), highScore[i].Item2, highScore[i].Item3);
                    ++next;
                    SetCursor.SetXandWrite(user, ++next);
                }
            }
            string pressAny = "Tryck på valfri knapp för att återgå till huvudmenyn.";
            SetCursor.SetXandWrite(pressAny, 13);
            Console.ReadLine();
        }
    }
}