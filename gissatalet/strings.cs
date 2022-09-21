using System.Collections;
using System.Resources.NetStandard;
namespace gissatalet
{
    public class strings
    {
        public string stringName;
        public string value;
        public strings(string stringName, string value)
        {
            this.stringName=stringName;
            this.value=value;
        }
        public static void getAndUseLocalizationFiles()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string sourceDirectory = @".\";
            var languageFiles = Directory.EnumerateFiles(sourceDirectory, "*.resx");
            int currentSelection = 0;
            List<string> files = new List<string>();
            string input = "Choose your prefered language:";
            SetCursor.SetXandWrite(input, -1);
            foreach (string selection in languageFiles) 
            {
                string choice = selection.Remove(0,2).Remove(selection.Length -7);
                files.Add(choice);
                string selectionValue = string.Format("{0}) {1}", currentSelection+1, files[currentSelection]);
                SetCursor.SetXandWrite(selectionValue, currentSelection+1);
                ++currentSelection;
            }
            Console.ForegroundColor = ConsoleColor.White;
            SetCursor.SetXandWrite("> ", files.Count + 2);
            bool isRunning = true;
            while (isRunning == true) 
            {
                try
                {
                    int userValue = Int32.Parse(Console.ReadLine()!);
                    int index = 0;
                    foreach (string option in files)
                    {
                        ++index;
                        if (userValue == index)
                        {
                            Tasks.rR.Close();
                            Tasks.Strings.Clear();
                            Tasks.rR = new ResXResourceReader(String.Format(@".\{0}.resx", files[index-1]));
                            foreach (DictionaryEntry strings in Tasks.rR)
                            {
                                Tasks.Strings.Add(new strings((string)strings.Key, (string)strings.Value!));
                            }
                            isRunning = false;
                            Tasks.rR.Close();
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
        public static string localization(string name) 
        {
            int index = Tasks.Strings.FindIndex(x => x.stringName == name);
            return Tasks.Strings[index].value;
        }
        public static void UserUi(int index)
        {
            string UserBack = string.Format("{0} {1} {2} {3} {4} {5}", Tasks.Users[index].name, strings.localization("userBackHas"), Tasks.Users[index].score, strings.localization("userBackScore"), Tasks.Users[index].tries, strings.localization("userBackTries"));
            SetCursor.SetXandWrite(UserBack, 5);
        }
    }
}
