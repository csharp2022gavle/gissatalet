namespace gissatalet
{
    internal sealed class SetCursor
    {
        public static WindowWidth windowWidth = new();
        public static void SetXandWrite(string setWord)
        {
            Console.SetCursorPosition(windowWidth.SetWidth(setWord), windowWidth.SetXpos());
            Console.Write(setWord);
        }
        public static void SetXandWrite(string setWord, int setNewXpos)
        {
            Console.SetCursorPosition(windowWidth.SetWidth(setWord), windowWidth.SetXpos(setNewXpos));
            Console.Write(setWord);
        }
    }
}
