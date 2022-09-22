using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gissatalet.Tasks;

namespace gissatalet.Views
{
    internal class NewGame
    {
        public static void MainTask()
        {
            Tasks.Titel.MainTask(Strings.Localization("TitleNewGame"));
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
                int userIndex = Tasks.Tasks.Users.FindIndex(x => x.name == name);
                string prompt = "> ";
                if (userIndex == -1)
                {
                    Tasks.Tasks.Users.Add(new User(name, 0, 0));
                    userIndex = Tasks.Tasks.Users.Count() - 1;
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
                    ++Tasks.Tasks.Users[userIndex].tries;
                }
                catch (FormatException)
                {
                    string guessError = Strings.Localization("guessError");
                    SetCursor.SetXandWrite(guessError, 3);
                }
                if (gissning == slumpTal)
                {
                    slumpTal = slump.Next(1, 11);
                    ++Tasks.Tasks.Users[userIndex].score;
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
