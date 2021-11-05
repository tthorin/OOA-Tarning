
namespace OOA_Tarning.Helpers
{
    using System;
    using System.Threading;

    public static class ConsoleWriteHelper
    {
        private static readonly ConsoleColor background = ConsoleColor.Black;
        private static readonly ConsoleColor foreground = ConsoleColor.Gray;
        internal static void DramaticPrint(string msg)
        {
            Console.CursorVisible = false;
            Console.Write(msg);
            for (var i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(70);
            }
            Console.WriteLine();
        }
        internal static void PausePrintDots((int X,int Y)move,(int X,int Y)back)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(move.X, move.Y);
            for (var i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(back.X, back.Y);
        }
        internal static void PrintAndHold(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Press any key to continue.");
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.CursorVisible = true;
        }
        internal static void Hold()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }
        internal static void BorderPrint(string msg, bool holdAtEnd = true)
        {
            Console.WriteLine($"╔{new string('═', msg.Length + 2)}╗");
            Console.WriteLine($"║ {msg} ║");
            Console.WriteLine($"╚{new string('═', msg.Length + 2)}╝");
            if (holdAtEnd)
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }
        internal static void BorderPrint(string[] msg, bool holdAtEnd = true)
        {
            var width = 0;
            foreach (var line in msg)
            {
                if (line.Length + 2 > width) width = line.Length + 2;
            }
            Console.WriteLine($"╔{new string('═', width + 2)}╗");
            foreach (var line in msg)
            {
                Console.WriteLine($"║ {line.PadRight(width)} ║");
            }
            Console.WriteLine($"╚{new string('═', width + 2)}╝");
            if (holdAtEnd)
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }
        internal static void ThinBorderPrint(string msg, bool holdAtEnd = true)
        {
            //┌┐┘└│─
            Console.WriteLine($"┌{new string('─', msg.Length + 2)}┐");
            Console.WriteLine($"│ {msg} │");
            Console.WriteLine($"└{new string('─', msg.Length + 2)}┘");
            if (holdAtEnd)
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }
        internal static void GameRoundPrint(int round)
        {
            //┌┐└┘─┤├
            Console.WriteLine($"           ┌────────┐");
            Console.WriteLine($"───────────┤Round{round,3}├───────────────────────────────────────────────────");
            Console.WriteLine($"           └────────┘");
        }
        internal static void InvertColors()
        {
            Console.ForegroundColor = background;
            Console.BackgroundColor = foreground;
        }

        internal static void SetColors()
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }
    }
}
