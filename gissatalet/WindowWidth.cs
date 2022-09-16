using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet
{
    public sealed class WindowWidth
    {
        public int MaxWidth() { return Console.WindowWidth/2; }
        public int SetWidth(string word) { return MaxWidth() -(word.Length/2); }
        public int SetXpos() { return Tasks.Xpos; }
        public int SetXpos(int yneg)
        {
            return Tasks.Xpos + (yneg);
        }
    }
}
