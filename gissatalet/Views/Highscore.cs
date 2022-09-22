using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gissatalet.Tasks;

namespace gissatalet.Views
{
    internal class Highscore
    {
        public static void MainTask()
        {
            Console.CursorVisible = false;
            Tasks.Titel.MainTask(Strings.Localization("TitelHighscore"));
            var highScore = new List<Tuple<int, string, int>>();
            foreach (var user in Tasks.Tasks.Users) highScore.Add(new Tuple<int, string, int>(user.score, user.name, user.tries));
            highScore.Sort((e1, e2) => { return (e1.Item3 / e1.Item1).CompareTo(e2.Item3 / e2.Item1); });
            string top3 = Strings.Localization("top3");
            SetCursor.SetXandWrite(top3);
            string description = Strings.Localization("description");
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
            string pressAny = Strings.Localization("pressAny");
            SetCursor.SetXandWrite(pressAny, 13);
            Console.ReadLine();
        }
    }
}
