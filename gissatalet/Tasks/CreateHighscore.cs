using gissatalet.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet.Tasks
{
    internal class CreateHighscore
    {
        public static async Task MainTask(List<User> Users)
        {
            if (!File.Exists(Tasks.path))
            {
                string higschoreCreate = Strings.Localization("higschoreCreate");
                string complete = Strings.Localization("complete");
                SetCursor.SetXandWrite(higschoreCreate);
                await File.WriteAllTextAsync(Tasks.path, "");
                Thread.Sleep(1000);
                SetCursor.SetXandWrite(Views.Views.space);
                SetCursor.SetXandWrite(complete);
                Thread.Sleep(200);
            }
            string[] HighScoreFile = await File.ReadAllLinesAsync(Tasks.path);
            for (int i = 0; i < HighScoreFile.Length; ++i)
            {
                string UnsplitUser = HighScoreFile[i];
                string[] userData = UnsplitUser.Split(" | ");
                Users.Add(new User(userData[1], int.Parse(userData[0]), int.Parse(userData[2])));
            }
        }
    }
}
