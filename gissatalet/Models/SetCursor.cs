namespace gissatalet.models
{
    internal sealed class SetCursor
    {
        public static WindowWidth WindowWidth = new();
        public static void SetXandWrite(string setWord)
        {
            Console.SetCursorPosition(WindowWidth.SetWidth(setWord), WindowWidth.SetXpos());
            Console.Write(setWord);
        }
        public static void SetXandWrite(string setWord, int setNewXpos)
        {
            Console.SetCursorPosition(WindowWidth.SetWidth(setWord), WindowWidth.SetXpos(setNewXpos));
            Console.Write(setWord);
        }
    }
}