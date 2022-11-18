using gissatalet.models;

namespace gissatalet.views
{
    internal class NewGame
    {
        public static void MainTask()
        {
            Titel.MainTask(Strings.Localization("TitleNewGame"));
            bool nyttSpel = true;
            Random slump = new();
            string input = Strings.Localization("input");
            SetCursor.SetXandWrite(input);
            SetCursor.SetXandWrite("> ", 1);
            string name = Console.ReadLine()!;
            SetCursor.SetXandWrite(Views.Space);
            int slumpTal = slump.Next(1, 11);
            while (nyttSpel)
            {
                int userIndex = Tasks.Users.FindIndex(x => x.Name == name);
                string prompt = "> ";
                if (userIndex == -1)
                {
                    Tasks.Users.Add(new user.User(name, 0, 0));
                    userIndex = Tasks.Users.Count - 1;
                }
                Strings.UserUi(userIndex);
                SetCursor.SetXandWrite(Views.Space);
                string guessText = Strings.Localization("guessText");
                SetCursor.SetXandWrite(guessText);
                SetCursor.SetXandWrite(Views.Space, 1);
                SetCursor.SetXandWrite(prompt, 1);
                int gissning = 0;
                string aGissning = Console.ReadLine()!;
                try
                {
                    SetCursor.SetXandWrite(Views.Space, 3);
                    gissning = int.Parse(aGissning);
                    ++Tasks.Users[userIndex].Tries;
                }
                catch (FormatException)
                {
                    string guessError = Strings.Localization("guessError");
                    SetCursor.SetXandWrite(guessError, 3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    ++Tasks.Users[userIndex].Score;
                    Strings.UserUi(userIndex);
                    string correct = Strings.Localization("correct");
                    string press = Strings.Localization("press");
                    SetCursor.SetXandWrite(Views.Space, -1);
                    SetCursor.SetXandWrite(correct, -1);
                    SetCursor.SetXandWrite(press);
                    SetCursor.SetXandWrite(prompt, 1);
                    string yN = Console.ReadLine()!.ToLower();
                    SetCursor.SetXandWrite(Views.Space);
                    if (yN == "n") nyttSpel = false;
                    else
                    {
                        SetCursor.SetXandWrite(Views.Space, -1);
                        SetCursor.SetXandWrite(Views.Space);
                    }
                }
                else if (gissning < slumpTal)
                {
                    string guessLow = Strings.Localization("guessLow");
                    SetCursor.SetXandWrite(Views.Space, -1);
                    SetCursor.SetXandWrite(guessLow, -1);
                }
                else
                {
                    string guessHigh = Strings.Localization("guessHigh");
                    SetCursor.SetXandWrite(Views.Space, -1);
                    SetCursor.SetXandWrite(guessHigh, -1);
                }
            }
            Console.WriteLine();
        }
    }
}
