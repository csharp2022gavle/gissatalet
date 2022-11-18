namespace gissatalet.views
{
    public sealed class Views : IDisposable
    {
        public static readonly string[] Spinner =
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
        public static readonly string Space = "                                                                                    ";
        public static void Init() { models.Tasks.Xpos = 13; Console.Clear(); }
        public void Dispose()
        {

        }
    }
}