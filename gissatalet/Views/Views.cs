namespace gissatalet.views
{
    public sealed class Views : IDisposable
    {
        public static readonly string[] spinner =
        {
            "[    ]",
            "[=   ]",
            "[==  ]",
            "[=== ]",
            "[ ===]",
            "[  ==]",
            "[   =]",
            "[    ]",
            "[   =]",
            "[  ==]",
            "[ ===]",
            "[====]",
            "[=== ]",
            "[==  ]",
            "[=   ]"
        };
        public static string space = "                                                                                    ";
        public static void Init() { models.Tasks.Xpos = 13; Console.Clear(); }
        public void Dispose()
        {

        }
    }
}