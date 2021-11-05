namespace OOA_Tarning
{
    using System;
    using static Helpers.ConsoleWriteHelper;
    public class Die
    {
        static Random rng = new();
        private int sides = 6;
        public Die(int sides = 6)
        {
            this.sides = sides;
        }

        public int PrintDice(string whoIsRolling)
        {   
            int diceResult = rng.Next(1, sides + 1);
            int space = 21;
            string whoRolled = $"{whoIsRolling} rolls:";

            Console.WriteLine("".PadRight(space) + "┌─────┐");

            if (diceResult == 1) Console.WriteLine("".PadRight(space) + "│     │");
            else if (diceResult == 2 || diceResult == 3) Console.WriteLine("".PadRight(space) + "│o    │");
            else Console.WriteLine("".PadRight(space) + "│o   o│");

            Console.Write(whoRolled);
            (int X, int Y) firstPos = Console.GetCursorPosition();
            Console.Write("".PadRight(space-whoRolled.Length));
            if (diceResult == 4 || diceResult == 2) Console.WriteLine("│     │");
            else if (diceResult == 6) Console.WriteLine("│o   o│");
            else Console.WriteLine("│  o  │");

            if (diceResult == 3 || diceResult == 2) Console.WriteLine("".PadRight(space) + "│    o│");
            else if (diceResult == 1) Console.WriteLine("".PadRight(space) + "│     │");
            else Console.WriteLine("".PadRight(space) + "│o   o│");

            Console.WriteLine("".PadRight(space) + "└─────┘");
            (int X, int Y) finsihPos = Console.GetCursorPosition();

            PausePrintDots(firstPos, finsihPos);

            return diceResult;
        }
    }
}
