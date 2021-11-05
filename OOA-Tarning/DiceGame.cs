namespace OOA_Tarning
{
    using System;
    using static Helpers.ConsoleWriteHelper;

    public partial class DiceGame
    {
        private bool wantToExit = false;
        private int playerPixBalance = 500;
        private int computerPixBalance = 500;
        private int bet = 100;
        Die die = new();
        private int computerMustPlayUntilAtleast = 18;
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
            if (playerPixBalance < bet) PrintLose();
            else if (computerPixBalance < bet) PrintWin();

            PrintGameOver();
        }

        private void PlayGame()
        {
            Console.Clear();
            PlaceBets();
            int playerTotal = 0;
            int computerTotal = 0;
            int gameRound = 1;
            bool playerHold = false;
            bool computerStop = false;
            BorderPrint($"Player has {playerPixBalance} pix, Computer has {computerPixBalance} pix.", false);
            GameRoundPrint(gameRound);
            do
            {
                if (!playerHold) (playerTotal, computerTotal, playerHold) = PlayerRoll(playerTotal, computerTotal);
                else if (!computerStop) (computerStop, computerTotal) = ComputerRoll(computerTotal, playerTotal);

                gameRound++;
                if (!playerHold && computerTotal<computerMustPlayUntilAtleast) GameRoundPrint(gameRound);
            } while (!computerStop);

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
                if ((cTotal > pTotal && cTotal <= 21) || (pTotal > 21 && cTotal <= 21))
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
            if (cTotal > pTotal || pTotal >= 21 || cTotal >= computerMustPlayUntilAtleast) cStop = true;
            else
            {
                cTotal += die.PrintDice("Computer");
                ThinBorderPrint($"Player have: {pTotal} points, Computer has: {cTotal} points.", false);
            }
            return (cStop, cTotal);
        }

        private (int playerTotal, int computerTotal, bool playerHold) PlayerRoll(int pTotal, int cTotal)
        {
            pTotal += die.PrintDice("Player");
            if (cTotal < computerMustPlayUntilAtleast) cTotal += die.PrintDice("Computer");
            bool playerHold = false;

            ThinBorderPrint($"Player have: {pTotal} points, Computer has: {cTotal} points.", false);
            if (pTotal >= 21 || cTotal >= 21) playerHold = true;
            else
            {
                ConsoleKeyInfo input;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Would you like to hold at current points or roll again? <H> to hold, <Enter> to roll again.");
                    SetColors();
                    input = Console.ReadKey(true);
                } while (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.H);
                if (input.Key == ConsoleKey.H) playerHold = true;
            }

            return (pTotal, cTotal, playerHold);
        }

        private void PlaceBets()
        {
            playerPixBalance -= bet;
            computerPixBalance -= bet;
        }

        private void Details()
        {
            Console.WriteLine($"You have [{playerPixBalance}] pix");
        }

        private void MainMenu()
        {
            Console.Clear();
            ThinBorderPrint($"You have {playerPixBalance} pix, the computer has {computerPixBalance} pix.",false);
            Console.WriteLine($"Current bet is {bet} pix.");
            Console.ForegroundColor = ConsoleColor.Red;
            if (bet > playerPixBalance || bet > computerPixBalance) Console.WriteLine("Bet is too high to continue playing, either lower bet or exit game.");
            SetColors();
            Console.WriteLine("\n[1] Play.");
            Console.WriteLine("[2] Change bet.");
            Console.WriteLine("[3] Exit game.");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Press a number key to select something.");
           
            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1: if (bet <= playerPixBalance && bet <= computerPixBalance) PlayGame(); break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2: ChangeBet(); break;
                case ConsoleKey.D3 or ConsoleKey.NumPad3 or ConsoleKey.Escape: wantToExit = true; break;
                default: break;
            }
        }

        private void ChangeBet()
        {
            Console.Clear();
            ThinBorderPrint($"Current bet is: {bet} pix, you have {playerPixBalance} pix and the computer has {computerPixBalance} pix.", false);
            Console.WriteLine("New bet must be over 0 and cannot be over either yours or the computers current pix balance.");
            Console.Write("New bet: ");
            _ = int.TryParse(Console.ReadLine(), out int number);
            while (number <= 0 || number > playerPixBalance || number > computerPixBalance)
            {
                Console.Write("Invalid amount. New bet: ");
                _ = int.TryParse(Console.ReadLine(), out number);
            }
            bet = number;
        }

        private void Intro()
        {
            PrintIntro();
        }
    }

}
