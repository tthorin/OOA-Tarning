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

            Console.WriteLine("".PadRight(20) + "┌─────┐");

            if (diceResult == 1) Console.WriteLine("".PadRight(20) + "│     │");
            else if (diceResult == 2 || diceResult == 3) Console.WriteLine("".PadRight(20) + "│o    │");
            else Console.WriteLine("".PadRight(20) + "│o   o│");

            if (diceResult == 4 || diceResult == 2) Console.WriteLine($"{whoIsRolling} rolls:".PadRight(20) + "│     │");
            else if (diceResult == 6) Console.WriteLine($"{whoIsRolling} rolls:".PadRight(20) + "│o   o│");
            else Console.WriteLine($"{whoIsRolling} rolls:".PadRight(20) + "│  o  │");

            if (diceResult == 3 || diceResult == 2) Console.WriteLine("".PadRight(20) + "│    o│");
            else if (diceResult == 1) Console.WriteLine("".PadRight(20) + "│     │");
            else Console.WriteLine("".PadRight(20) + "│o   o│");

            Console.WriteLine("".PadRight(20) + "└─────┘");

            return diceResult;
        }
    }
}
