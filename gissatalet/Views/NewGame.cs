using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gissatalet.models;

namespace gissatalet.views
{
    internal class NewGame
    {
        public static void MainTask()
        {
            models.Titel.MainTask(Strings.Localization("TitleNewGame"));
            bool nyttSpel = true;
            Random slump = new();
            string input = Strings.Localization("input");
            SetCursor.SetXandWrite(input);
            SetCursor.SetXandWrite("> ", 1);
            string name = Console.ReadLine()!;
            SetCursor.SetXandWrite(Views.space);
            int slumpTal = slump.Next(1, 11);
            while (nyttSpel == true)
            {
                int userIndex = models.Tasks.Users.FindIndex(x => x.Name == name);
                string prompt = "> ";
                if (userIndex == -1)
                {
                    models.Tasks.Users.Add(new user.User(name, 0, 0));
                    userIndex = models.Tasks.Users.Count - 1;
                }
                Strings.UserUi(userIndex);
                SetCursor.SetXandWrite(Views.space);
                string guessText = Strings.Localization("guessText");
                SetCursor.SetXandWrite(guessText);
                SetCursor.SetXandWrite(Views.space, 1);
                SetCursor.SetXandWrite(prompt, 1);
                int gissning = 0;
                string aGissning = Console.ReadLine()!;
                try
                {
                    SetCursor.SetXandWrite(Views.space, 3);
                    gissning = int.Parse(aGissning);
                    ++models.Tasks.Users[userIndex].Tries;
                }
                catch (FormatException)
                {
                    string guessError = Strings.Localization("guessError");
                    SetCursor.SetXandWrite(guessError, 3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    ++models.Tasks.Users[userIndex].Score;
                    Strings.UserUi(userIndex);
                    string correct = Strings.Localization("correct");
                    string press = Strings.Localization("press");
                    SetCursor.SetXandWrite(Views.space, -1);
                    SetCursor.SetXandWrite(correct, -1);
                    SetCursor.SetXandWrite(press);
                    SetCursor.SetXandWrite(prompt, 1);
                    string yN = Console.ReadLine()!.ToLower();
                    SetCursor.SetXandWrite(Views.space);
                    if (yN == "n") nyttSpel = false;
                    else
                    {
                        SetCursor.SetXandWrite(Views.space, -1);
                        SetCursor.SetXandWrite(Views.space);
                    }
                }
                else if (gissning < slumpTal)
                {
                    string guessLow = Strings.Localization("guessLow");
                    SetCursor.SetXandWrite(Views.space, -1);
                    SetCursor.SetXandWrite(guessLow, -1);
                }
                else
                {
                    string guessHigh = Strings.Localization("guessHigh");
                    SetCursor.SetXandWrite(Views.space, -1);
                    SetCursor.SetXandWrite(guessHigh, -1);
                }
            }
            Console.WriteLine();
        }
    }
}
