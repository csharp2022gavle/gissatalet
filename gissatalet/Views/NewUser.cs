using gissatalet.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet.views
{
    public class NewUser
    {
        string user;
        string pass;
        public string Name 
        {
            get { return user; }
            set { user = value; }
        }
        public string password 
        { 
            get { return pass; } 
            set { pass = value; } 
        }
        public static void CreateUser() 
        {
            models.Titel.MainTask("Create User");
            NewUser user = new();
            string createUser = "Enter a user name :";
            SetCursor.SetXandWrite(createUser);
            SetCursor.SetXandWrite("> ", 1);
            user.Name = Console.ReadLine()!;
            bool correct = false;
            do
            {
                string createUserPassword = "Enter a password :";
                SetCursor.SetXandWrite(Views.space);
                SetCursor.SetXandWrite(Views.space, 1);
                SetCursor.SetXandWrite(createUserPassword);
                SetCursor.SetXandWrite("> ", 1);
                views.HiddenInput.MainTask(user.password);
                string createUserPasswordVerify = "Enter the password again and verify :";
                SetCursor.SetXandWrite(Views.space);
                SetCursor.SetXandWrite(Views.space, 1);
                string verifiedPassword = "";
                views.HiddenInput.MainTask(verifiedPassword);
                if (user.password != verifiedPassword) 
                {
                    string noMatch = "The password don't match, enter a new password and redo the process";
                    SetCursor.SetXandWrite(noMatch, 6);
                }
                if (user.password == verifiedPassword)
                {
                    string noMatch = string.Format("Creating new user {0}", user.Name);
                    SetCursor.SetXandWrite(noMatch, 6);
                }
            } while (correct == true);

        }
    }
}
