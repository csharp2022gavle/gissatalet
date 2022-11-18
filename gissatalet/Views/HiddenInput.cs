namespace gissatalet.views
{
    internal class HiddenInput
    {
        public static string MainTask(string hiddenInfo) 
        {
            ConsoleKeyInfo keyinfo;
            do 
            {
                var pos = Console.GetCursorPosition();
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key != ConsoleKey.Backspace && keyinfo.Key != ConsoleKey.Enter)
                {
                    hiddenInfo += keyinfo.KeyChar;
                    Console.Write(@"*");
                }
                else 
                {
                    if (keyinfo.Key == ConsoleKey.Backspace && hiddenInfo.Length > 0) 
                    {
                        hiddenInfo = hiddenInfo.Substring(0, hiddenInfo.Length - 1);
                        Console.SetCursorPosition(pos.Left -1, pos.Top);
                        Console.Write(@" ");
                        Console.SetCursorPosition(pos.Left -1, pos.Top);
                    }
                }
            }
            while (keyinfo.Key != ConsoleKey.Enter);
            return hiddenInfo;
        }
    }
}
