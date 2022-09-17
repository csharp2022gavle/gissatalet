﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
    }
}