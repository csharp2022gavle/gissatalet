using System.Resources.NetStandard;

namespace gissatalet.models
{
    internal sealed class Tasks
    {
        public static List<user.User> Users = new();
        public static int Lang = -1;
        public static string Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Spelare.txt");
        public static string FontPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "font.flf");
        public static List<Strings> Strings = new();
        public static int Xpos;
        public static ResXResourceReader RR = new(@".\English.resx");
    }
}