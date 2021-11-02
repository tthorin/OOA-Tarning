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
            DramaticPrint($"{whoIsRolling} slår en {dieRoll}:a.");
            return dieRoll;
        }
    }
}
