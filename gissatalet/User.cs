namespace gissatalet
{
    public sealed class User
    {
        public string name;
        public int score;
        public int tries;

        public User(string Name, int Score, int Tries)
        {
            this.name=Name;
            this.score=Score;
            this.tries=Tries;
        }
        public static void UserUi(int index) 
        {
            string UserBack = string.Format("{0} har {1} poäng på {2} försök", Tasks.Users[index].name, Tasks.Users[index].score, Tasks.Users[index].tries);
            SetCursor.SetXandWrite(UserBack, 5);
        }
    }
}