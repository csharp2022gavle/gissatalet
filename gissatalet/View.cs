namespace gissatalet
{
    public sealed class View : IDisposable
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
            Tasks.Titel(strings.localization("TitleMain"));
            View.Meny();
            string makeAMove = strings.localization("MakeAMove");
            SetCursor.SetXandWrite(makeAMove, 5);
            SetCursor.SetXandWrite("> ", 6);
            Console.CursorVisible = true;
        }
        public static void Meny()
        {
            string optionOne = string.Format(strings.localization("optionOne"));
            string optionTwo = string.Format(strings.localization("optionTwo"));
            string optionThree = string.Format(strings.localization("optionThree"));
            SetCursor.SetXandWrite(optionOne, 1);
            SetCursor.SetXandWrite(optionTwo, 2);
            SetCursor.SetXandWrite(optionThree, 3);
        }
        public static void NewGame()
        {
            Tasks.Titel(strings.localization("TitleNewGame"));
            bool nyttSpel = true;
            Random slump = new();
            string input = strings.localization("input");
            SetCursor.SetXandWrite(input);
            SetCursor.SetXandWrite("> ", 1);
            string name = Console.ReadLine()!;
            SetCursor.SetXandWrite(space);
            int slumpTal = slump.Next(1, 11);
            while (nyttSpel == true)
            {
                int userIndex = Tasks.Users.FindIndex(x => x.name == name);
                string prompt = "> ";
                if (userIndex == -1)
                {
                    Tasks.Users.Add(new User(name, 0, 0));
                    userIndex = Tasks.Users.Count()-1;
                }
                strings.UserUi(userIndex);
                SetCursor.SetXandWrite(space);
                string guessText = strings.localization("guessText");
                SetCursor.SetXandWrite(guessText);
                SetCursor.SetXandWrite(space, 1);
                SetCursor.SetXandWrite(prompt, 1);
                int gissning = 0;
                string aGissning = Console.ReadLine()!;
                try
                {
                    SetCursor.SetXandWrite(space, 3);
                    gissning = Int32.Parse(aGissning);
                    ++Tasks.Users[userIndex].tries;
                }
                catch (FormatException)
                {
                    string guessError = strings.localization("guessError");
                    SetCursor.SetXandWrite(guessError, 3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    ++Tasks.Users[userIndex].score;
                    strings.UserUi(userIndex);
                    string correct = strings.localization("correct");
                    string press = strings.localization("press");
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
                    string guessLow = strings.localization("guessLow");
                    SetCursor.SetXandWrite(space, -1);
                    SetCursor.SetXandWrite(guessLow, -1);
                }
                else
                {
                    string guessHigh = strings.localization("guessHigh");
                    SetCursor.SetXandWrite(space, -1);
                    SetCursor.SetXandWrite(guessHigh, -1);
                }
            }
            Console.WriteLine();
        }
        public static void Highscore()
        {
            Console.CursorVisible = false;
            Tasks.Titel(strings.localization("TitelHighscore"));
            var highScore = new List<Tuple<int, string, int>>();
            foreach (var user in Tasks.Users) highScore.Add(new Tuple<int, string, int>(user.score, user.name, user.tries));
            highScore.Sort((e1, e2) => { return (e1.Item3 / e1.Item1).CompareTo((e2.Item3 / e2.Item1)); }); 
            string top3 = strings.localization("top3");
            SetCursor.SetXandWrite(top3);
            string description = strings.localization("description");
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
            string pressAny = strings.localization("pressAny");
            SetCursor.SetXandWrite(pressAny, 13);
            Console.ReadLine();
        }
        public void Dispose()
        {
            
        }
    }
}