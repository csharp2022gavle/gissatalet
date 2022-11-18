using System.Collections;
using System.Resources.NetStandard;

namespace gissatalet.models
{
    public class Strings
    {
        public string StringName;
        public string Value;
        public Strings(string stringName, string value)
        {
            StringName = stringName;
            Value = value;
        }
        public static void GetAndUseLocalizationFiles()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string sourceDirectory = @".\";
            var languageFiles = Directory.EnumerateFiles(sourceDirectory, "*.resx");
            int currentSelection = 0;
            List<string> files = new();
            string input = "Choose your prefered language:";
            SetCursor.SetXandWrite(input, -1);
            foreach (string selection in languageFiles)
            {
                string choice = selection.Remove(0, 2).Remove(selection.Length - 7);
                files.Add(choice);
                string selectionValue = string.Format("{0}) {1}", currentSelection + 1, files[currentSelection]);
                SetCursor.SetXandWrite(selectionValue, currentSelection + 1);
                ++currentSelection;
            }
            Console.ForegroundColor = ConsoleColor.White;
            SetCursor.SetXandWrite("> ", files.Count + 2);
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    int userValue = int.Parse(Console.ReadLine()!);
                    int index = 0;
                    foreach (string option in files)
                    {
                        ++index;
                        if (userValue == index)
                        {
                            Tasks.RR.Close();
                            Tasks.Strings.Clear();
                            Tasks.RR = new ResXResourceReader(string.Format(@".\{0}.resx", files[index - 1]));
                            foreach (DictionaryEntry strings in Tasks.RR)
                            {
                                Tasks.Strings.Add(new Strings((string)strings.Key, (string)strings.Value!));
                            }
                            isRunning = false;
                            Tasks.RR.Close();
                        }
                    }
                }
                catch
                {
                    string notValid = "You have to choose a valid number!";
                    SetCursor.SetXandWrite(notValid, 6);
                }
            }
        }
        public static string Localization(string name)
        {
            int index = Tasks.Strings.FindIndex(x => x.StringName == name);
            return Tasks.Strings[index].Value;
        }
        public static void UserUi(int index)
        {
            string userBack = string.Format("{0} {1} {2} {3} {4} {5}", Tasks.Users[index].Name, Localization("userBackHas"), Tasks.Users[index].Score, Localization("userBackScore"), Tasks.Users[index].Tries, Localization("userBackTries"));
            SetCursor.SetXandWrite(userBack, 5);
        }
    }
}
