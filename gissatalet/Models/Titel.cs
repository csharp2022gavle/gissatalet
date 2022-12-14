using gissatalet.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace gissatalet.models
{
    internal class Titel
    {
        public static void MainTask(string titelText)
        {
            views.Views.Init();
            Stream fontStream;
            fontStream = new FileStream(Tasks.fontPath, FileMode.Open, FileAccess.Read);
            var font = new WenceyWang.FIGlet.FIGletFont(fontStream);
            var text = new WenceyWang.FIGlet.AsciiArt(titelText, font: font);
            text.ToString(); var result = text.Result;
            Console.WriteLine(views.Views.space);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < result.Length; i++)
            {
                int centerLeftSpace = Console.WindowWidth / 2 - result[2].Length / 2;
                Console.SetCursorPosition(centerLeftSpace, 2 + i);
                Console.Write(result[i] + Environment.NewLine);
            }
            fontStream.Close();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
