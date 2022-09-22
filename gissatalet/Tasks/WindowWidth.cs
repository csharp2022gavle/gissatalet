namespace gissatalet.Tasks
{
    public sealed class WindowWidth
    {
        public int MaxWidth() { return Console.WindowWidth / 2; }
        public int SetWidth(string word) { return MaxWidth() - word.Length / 2; }
        public int SetXpos() { return Tasks.Xpos; }
        public int SetXpos(int yneg)
        {
            return Tasks.Xpos + yneg;
        }
    }
}