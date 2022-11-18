using gissatalet.models;
namespace gissatalet.views
{
    public class NewUser
    {
        string _user;
        string _pass;
        public string Name 
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Password 
        { 
            get { return _pass; } 
            set { _pass = value; } 
        }
        public static void CreateUser() 
        {
            Titel.MainTask("Create User");
            NewUser user = new();
            string createUser = "Enter a user name :";
            SetCursor.SetXandWrite(createUser);
            SetCursor.SetXandWrite("> ", 1);
            user.Name = Console.ReadLine()!;
            bool correct = false;
            do
            {
                string createUserPassword = "Enter a password :";
                SetCursor.SetXandWrite(Views.Space);
                SetCursor.SetXandWrite(Views.Space, 1);
                SetCursor.SetXandWrite(createUserPassword);
                SetCursor.SetXandWrite("> ", 1);
                HiddenInput.MainTask(user.Password);
                string createUserPasswordVerify = "Enter the password again and verify :";
                SetCursor.SetXandWrite(Views.Space);
                SetCursor.SetXandWrite(Views.Space, 1);
                string verifiedPassword = "";
                HiddenInput.MainTask(verifiedPassword);
                if (user.Password != verifiedPassword) 
                {
                    string noMatch = "The password don't match, enter a new password and redo the process";
                    SetCursor.SetXandWrite(noMatch, 6);
                }
                if (user.Password == verifiedPassword)
                {
                    string noMatch = string.Format("Creating new user {0}", user.Name);
                    SetCursor.SetXandWrite(noMatch, 6);
                }
            } while (correct);

        }
    }
}
