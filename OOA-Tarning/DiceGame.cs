namespace OOA_Tarning
{
    using System;
    using static Helpers.ConsoleWriteHelper;

    public class DiceGame
    {
        private bool wantToExit = false;
        private int playerPixBalance = 500;
        private int computerPixBalance = 500;
        private int bet = 100;
        Die die = new();
        public void Run()
        {
            Intro();
            while (!wantToExit && playerPixBalance >= bet && computerPixBalance >= bet)
            {
                MainMenu();
                PlayGame();
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
            BorderPrint($"Spelaren har {playerPixBalance} pix, Datorn har {computerPixBalance} pix.", false);
            while (!computerStop)
            {
                GameRoundPrint(gameRound);
                if (playerTotal != 0) Console.WriteLine($"Spelarens poäng: {playerTotal} Datorns poäng: {computerTotal}.");
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
                ThinBorderPrint($"Spelaren vann! Spelaren har nu {playerPixBalance}, datorn har: {computerPixBalance}");
            }
            else
            {
                if (cTotal > pTotal && cTotal <= 21)
                {
                    computerPixBalance += 2 * bet;
                    ThinBorderPrint($"Datorn vann! Spelaren har nu {playerPixBalance}, datorn har: {computerPixBalance}");
                }
                else
                {
                    playerPixBalance += bet;
                    computerPixBalance += bet;
                    ThinBorderPrint($"Oavgjort. Spelaren har nu {playerPixBalance}, datorn har: {computerPixBalance}");
                }
            }
            
        }

        private (bool computerStop, int computerTotal) ComputerRoll(int cTotal, int pTotal)
        {
            bool cStop = false;
            if (cTotal > pTotal || (pTotal>21 && cTotal >= 19)) cStop = true;
            else
            {
                cTotal += die.RollAndPrint("Datorn");
                Console.WriteLine($"Spelaren har {pTotal}, Datorn har: {cTotal}.");
            }
            return (cStop, cTotal);
        }

        private (int playerTotal, int computerTotal, bool playerHold) BothRoll(int pTotal, int cTotal)
        {
            pTotal += die.RollAndPrint("Spelaren");
            if (cTotal < 19) cTotal += die.RollAndPrint("Datorn");
            bool playerHold = false;

            Console.WriteLine($"Spelaren har {pTotal}, Datorn har: {cTotal}.");
            if (pTotal >= 21 || cTotal >= 21) playerHold = true;
            else
            {
                ConsoleKeyInfo input;
                do
                {
                    Console.WriteLine("Vill du stanna på nuvarande poäng eller slå igen? <S> för att stanna, <Enter> för att slå igen.");
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

        private void Details()
        {
            Console.WriteLine($"You have [{playerPixBalance}] pix");
        }

        private void MainMenu()
        {

            Console.Clear();
            Console.WriteLine("\n[1] Play");
            Console.WriteLine("[2] Your Pix");
            Console.WriteLine("[3] Exit game");
            string input = Console.ReadLine();
            int.TryParse(input, out int number);

            while (number < 1 || number > 3)
            {

                Console.Write("Wrong choice. Try again:");
                string inputB = Console.ReadLine();
                int.TryParse(inputB, out number);
            }

            switch (number)
            {
                case 1: PlayGame(); break;
                case 2: Details(); break;
                default: wantToExit=true; break;
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
