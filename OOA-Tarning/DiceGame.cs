﻿namespace OOA_Tarning
{
    using System;
    using static Helpers.ConsoleWriteHelper;

    public class DiceGame
    {
        private bool wantToExit = false;
        private int playerPixBalance = 500;
        private int computerPixBalance = 500;
        private int bet = 100;
        private int computerMustPlayUntilAtleast = 19;
        Die die = new();
        public void Run()
        {
            Intro();
            while (!wantToExit && playerPixBalance >= bet && computerPixBalance >= bet)
            {
                MainMenu();
            }
            ExitMsg();

        }

        private void ExitMsg()
        {
            //detta händer när man vill sluta
        }

        private void PlayGame()
        {
            PlaceBets();
            int playerTotal = 0;
            int computerTotal = 0;
            int gameRound = 1;
            bool playerHold = false;
            bool computerStop = false;
            BorderPrint($"Player has {playerPixBalance} pix, Computer has {computerPixBalance} pix.", false);
            while (!computerStop)
            {
                GameRoundPrint(gameRound);
                if (!playerHold)
                {
                    (playerTotal, computerTotal, playerHold) = BothRoll(playerTotal, computerTotal);
                }
                else if (!computerStop) (computerStop, computerTotal) = ComputerRoll(computerTotal, playerTotal);
                
                gameRound++;
            }
            CheckResultAndPrint(playerTotal, computerTotal);
        }

        private void CheckResultAndPrint(int pTotal, int cTotal)
        {
            bool playerWin = false;
            if (cTotal > 21 && pTotal <= 21) playerWin = true;
            else if (pTotal > cTotal && pTotal <= 21) playerWin = true;

            if (playerWin)
            {
                playerPixBalance += 2 * bet;
                ThinBorderPrint($"Player won! Player now have {playerPixBalance} pix, Computer has {computerPixBalance} pix.");
            }
            else
            {
                if (cTotal > pTotal && cTotal <= 21)
                {
                    computerPixBalance += 2 * bet;
                    ThinBorderPrint($"Computer won! Player now have {playerPixBalance} pix , Computer has {computerPixBalance} pix.");
                }
                else
                {
                    playerPixBalance += bet;
                    computerPixBalance += bet;
                    ThinBorderPrint($"Draw. Player have {playerPixBalance} pix, Computer has {computerPixBalance} pix.");
                }
            }
            
        }

        private (bool computerStop, int computerTotal) ComputerRoll(int cTotal, int pTotal)
        {
            bool cStop = false;
            if (cTotal > pTotal || (pTotal>21 && cTotal >= computerMustPlayUntilAtleast) || (cTotal>= computerMustPlayUntilAtleast && cTotal==pTotal)) cStop = true;
            else
            {
                cTotal += die.RollAndPrint("Computer");
                Console.WriteLine($"Player have: {pTotal} points, Computer has: {cTotal} points.");
            }
            return (cStop, cTotal);
        }

        private (int playerTotal, int computerTotal, bool playerHold) BothRoll(int pTotal, int cTotal)
        {
            pTotal += die.RollAndPrint("PLayer");
            if (cTotal < computerMustPlayUntilAtleast) cTotal += die.RollAndPrint("Computer");
            bool playerHold = false;

            Console.WriteLine($"Player have: {pTotal} points, Computer has: {cTotal} points.");
            if (pTotal >= 21 || cTotal >= 21) playerHold = true;
            else
            {
                ConsoleKeyInfo input;
                do
                {
                    Console.WriteLine("Would you like to hold at current points or roll again? <H> to hold, <Enter> to roll again.");
                    input = Console.ReadKey(true);
                } while (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.S);
                if (input.Key == ConsoleKey.S) playerHold = true;
            }

            return (pTotal, cTotal, playerHold);
        }

        private void PlaceBets()
        {
            playerPixBalance -= bet;
            computerPixBalance -= bet;
        }

        public void Details()
        {

        }

        private void MainMenu()
        {

            Console.Clear();
            Console.WriteLine("\n[1] Spela");
            Console.WriteLine("[2] Din information");
            Console.WriteLine("[3] Exit game");
            string input = Console.ReadLine();
            int.TryParse(input, out int number);

            while (number < 1 || number > 3)
            {

                Console.Write("Du har valt fel. Välj tjänst nummer igen:");
                string inputB = Console.ReadLine();
                int.TryParse(inputB, out number);
            }

            switch (number)
            {
                case 1: Run(); break;
                case 2: Details(); break;
                default: Environment.Exit(0); break;
            }
            //spelaren får i en meny välja om man vill spela  eller sluta eller ev. annat
            //även info om hur många pix man har just nu
        }

        private void Intro()
        {
            //detta händer när man startar spelet första gången
            //typ instruktioner och sånt
        }
    }

}
