using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet
{
    public class View
    {
        public static string space = "                                                                                    ";
        public static void Init() { Tasks.Xpos = 13; Console.Clear(); }
        public static void Front() 
        {
            Tasks.Titel("      Gissa Talet");
            View.Meny();
            string makeAMove = "Gör ett val: ";
            SetCursor.SetXandWrite(makeAMove, 5);
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
            Tasks.Titel("        NEW GAME!");
            bool nyttSpel = true;
            Random slump = new();
            string input = "Nu startas ett spel skriv ditt namn";
            SetCursor.SetXandWrite(input);
            SetCursor.SetXandWrite("> ", 1);
            string name = Console.ReadLine();
            SetCursor.SetXandWrite(space);
            int slumpTal = slump.Next(1, 11);
            while (nyttSpel == true)
            {
                int tempUserIndex = Tasks.users.FindIndex(u => u.Item2 == name);
                bool nameExists = false;
                string prompt = "> ";
                var tempUser = new List<Tuple<int, string>>();
                if (tempUserIndex == -1)
                {
                    Tasks.users.Add(new Tuple<int, string>(0, name));
                    tempUserIndex = Tasks.users.Count()-1;
                }
                string userBack = string.Format("Du {0} har {1} poäng!", Tasks.users[tempUserIndex].Item2, Tasks.users[tempUserIndex].Item1);
                SetCursor.SetXandWrite(userBack, 5);
                SetCursor.SetXandWrite(space);
                string gissaText = "Gissa ett nummer mellan 1 - 10";
                SetCursor.SetXandWrite(gissaText);
                SetCursor.SetXandWrite(space, 1);
                SetCursor.SetXandWrite(prompt, 1);
                int gissning = 0;
                string aGissning = Console.ReadLine();
                try
                {
                    SetCursor.SetXandWrite(space, 3);
                    gissning = Int32.Parse(aGissning);
                }
                catch (FormatException)
                {
                    string error = "Du måste skriva in ett nummer!";
                    SetCursor.SetXandWrite(error, 3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    string correct = "Du gissade rätt!";
                    string press = "Tryck på (N) för att avsluta eller, Tryck på valfri tangent för att fortsätta.";
                    tempUser.Add(new Tuple<int, string>(Tasks.users[tempUserIndex].Item1+1, Tasks.users[tempUserIndex].Item2));
                    Tasks.users.RemoveAt(tempUserIndex);
                    if (tempUserIndex == Tasks.users.Count) Tasks.users.Insert(tempUserIndex-1, tempUser[0]);
                    else Tasks.users.Insert(tempUserIndex, tempUser[0]);
                    tempUser.RemoveAt(0);
                    tempUserIndex = Tasks.users.FindIndex(u => u.Item2 == name);
                    userBack = string.Format("Du {0} har {1} poäng!", Tasks.users[tempUserIndex].Item2, Tasks.users[tempUserIndex].Item1);
                    SetCursor.SetXandWrite(userBack, 5);
                    SetCursor.SetXandWrite(space, -1);
                    SetCursor.SetXandWrite(correct, -1);
                    SetCursor.SetXandWrite(press);
                    SetCursor.SetXandWrite(prompt, 1);
                    string yN = Console.ReadLine().ToLower();
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
            Tasks.Titel("       HighScore!");
            var highScore = new List<Tuple<int, string>>();
            foreach (var user in Tasks.users) highScore.Add(new Tuple<int, string>(user.Item1, user.Item2));
            highScore.Sort((e1, e2) => { return e2.Item1.CompareTo(e1.Item1); });
            string top3 = "De top 3 Bästa spelana";
            SetCursor.SetXandWrite(top3);
            string description = "POÄNG | NAMN";
            SetCursor.SetXandWrite(description, 2);
            int next = 3;
            if (highScore.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    string user = string.Format("{0} | {1}", highScore[i].Item1.ToString(), highScore[i].Item2);
                    ++next;
                    SetCursor.SetXandWrite(user, ++next);
                }
            }
            else
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    string user = highScore[i].ToString();
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
