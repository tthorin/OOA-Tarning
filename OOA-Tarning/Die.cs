namespace OOA_Tarning
{
    using System;
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
    }
}
