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

        public int Roll()
        {
            return rng.Next(1, sides + 1);
        }
        public int RollAndPrint(string whoIsRolling)
        {
            int dieRoll = rng.Next(1, sides + 1);
            DramaticPrint($"{whoIsRolling} rolls a {dieRoll}");
            return dieRoll;
        }
        public int PrintDice(string whoIsRolling)
        {   
            int diceHeight = 5;
            int diceResult = rng.Next(1, sides + 1);

            for (int diceRow = 0; diceRow < diceHeight; diceRow++)
            {

                if (diceRow == 0) Console.WriteLine("".PadRight(20)+"┌─────┐");
                if (diceRow == 1)
                {
                    if (diceResult == 1) Console.WriteLine("".PadRight(20) + "│     │");
                    else if (diceResult == 2 || diceResult == 3) Console.WriteLine("".PadRight(20) + "│o    │");
                    else Console.WriteLine("".PadRight(20) + "│o   o│");
                }
                if (diceRow == 2)
                {
                    if (diceResult == 4 || diceResult == 2) Console.WriteLine($"{whoIsRolling} rolls:".PadRight(20) + "│     │");
                    else if (diceResult == 6) Console.WriteLine($"{whoIsRolling} rolls:".PadRight(20) + "│o   o│");
                    else Console.WriteLine($"{whoIsRolling} rolls:".PadRight(20) + "│  o  │");
                }
                if (diceRow == 3)
                {
                    if (diceResult == 3 || diceResult == 2) Console.WriteLine("".PadRight(20) + "│    o│");
                    else if (diceResult == 1) Console.WriteLine("".PadRight(15) + "│     │");
                    else Console.WriteLine("".PadRight(20) + "│o   o│");
                }
                if (diceRow == 4) Console.WriteLine("".PadRight(20) + "└─────┘");
            }

            return diceResult;
        }
    }
}
