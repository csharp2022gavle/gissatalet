using System.Resources.NetStandard;
using gissatalet.views;

namespace gissatalet.models
{
    internal sealed class Tasks
    {
        public static List<user.User> Users = new();
        public static int lang = -1;
        public static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Spelare.txt");
        public static string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "font.flf");
        public static List<Strings> Strings = new();
        public static int Xpos;
        public static ResXResourceReader rR = new(@".\English.resx");
    }
}