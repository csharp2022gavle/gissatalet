namespace gissatalet.models
{
    internal class CreateHighscore
    {
        public static async Task MainTask(List<user.User> users)
        {
            if (!File.Exists(Tasks.Path))
            {
                string higschoreCreate = Strings.Localization("higschoreCreate");
                string complete = Strings.Localization("complete");
                SetCursor.SetXandWrite(higschoreCreate);
                await File.WriteAllTextAsync(Tasks.Path, "");
                Thread.Sleep(1000);
                SetCursor.SetXandWrite(views.Views.Space);
                SetCursor.SetXandWrite(complete);
                Thread.Sleep(200);
            }
            string[] highScoreFile = await File.ReadAllLinesAsync(Tasks.Path);
            for (int i = 0; i < highScoreFile.Length; ++i)
            {
                string unsplitUser = highScoreFile[i];
                string[] userData = unsplitUser.Split(" | ");
                users.Add(new user.User(userData[1], int.Parse(userData[0]), int.Parse(userData[2])));
            }
        }
    }
}
