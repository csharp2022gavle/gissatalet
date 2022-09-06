namespace gissatalet
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            bool startaSpel = true;
            /* Titel sida
             * New game
                Startar ett nytt spel direkt med en ny skärm
                    Gissa ett tal mellasn 1 - 10
                    Gissar du rätt skriv in ditt namn
                    Fortsätt spela eller avsluta
             * Highscore
                - Namn, Poäng(antal rätt gissningar)

             * Quit
            */
            while (startaSpel = true) 
            {
                string userValue = Console.ReadLine();
                Meny(startaSpel);
                if (userValue == "1")
                {
                    NewGame();
                }
                if (userValue == "2")
                {
                    Highscore();
                }
                if (userValue == "3") 
                {
                    startaSpel = false;
                }
            }

        }
        public static void Meny(Boolean gameOn)
        {
            

        }
        public static void NewGame() 
        {
        
        }
        public static void Highscore() 
        {
        
        }
    }
}