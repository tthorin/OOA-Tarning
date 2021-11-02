namespace OOA_Tarning
{
    using System;
    using System.Threading;
    using static Helpers.ConsoleWriteHelper;

    public partial class DiceGame
    {
        private void PrintIntro()
        {
            Console.Clear();
            Console.CursorVisible = false;
            SetColors();
            string[] welcome = new string[]
            {
                "Welcome to Dice Blackjack!",
                "How the game works:",
                "The player and computer alternates rolling a dice.",
                "the running total of the rolls are tallied.",
                "",
                "The bout ends when either paticipant reaches 21,",
                "when either participant loses by getting a total above 21",
                "or when both paticipant have passed on making further rolls.",
                "The computer will pass on making further rolls once it",
                $"reaches a total of {computerMustPlayUntilAtleast} or more."
            };
            string[] winConditions = new string[]
            {
                "If, *immediatly* after finishing a bout of Dice Blackjack",
                "(before changing the bet amount) the computer cannot meet the",
                "required amount for placing a bet, YOU WIN! :)"

            };
            string[] loseConditions = new string[]
            {
                "If, *immediatly* after finishing a bout of Dice Blackjack",
                "(before changing the bet amount) you cannot meet the",
                "required amount for placing a bet, YOU LOSE! :("
            };
            Console.WriteLine("WELCOME!");
            BorderPrint(welcome);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("WIN:");
            BorderPrint(winConditions, false);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LOSE:");
            BorderPrint(loseConditions);
            SetColors();
        }
        private void PrintWin()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Random rng = new();
            while (Console.KeyAvailable == false)
            {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = (ConsoleColor)rng.Next(1, 16);
            Console.WriteLine(@" █████ █████                        █████   ███   █████ █████ ██████   █████ ███
░░███ ░░███                        ░░███   ░███  ░░███ ░░███ ░░██████ ░░███ ░███
 ░░███ ███    ██████  █████ ████    ░███   ░███   ░███  ░███  ░███░███ ░███ ░███
  ░░█████    ███░░███░░███ ░███     ░███   ░███   ░███  ░███  ░███░░███░███ ░███
   ░░███    ░███ ░███ ░███ ░███     ░░███  █████  ███   ░███  ░███ ░░██████ ░███
    ░███    ░███ ░███ ░███ ░███      ░░░█████░█████░    ░███  ░███  ░░█████ ░░░ 
    █████   ░░██████  ░░████████       ░░███ ░░███      █████ █████  ░░█████ ███
   ░░░░░     ░░░░░░    ░░░░░░░░         ░░░   ░░░      ░░░░░ ░░░░░    ░░░░░ ░░░ 
                                                                                
                                                                                
                                                                                ");
                Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
                Thread.Sleep(250);
                SetColors();
            }
            Console.ReadKey(true);
        }
        private void PrintLose()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Random rng = new();
            while (Console.KeyAvailable == false)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = (ConsoleColor)rng.Next(1, 16);
                Console.WriteLine(@"                                                                             
@@@ @@@   @@@@@@   @@@  @@@     @@@        @@@@@@    @@@@@@   @@@@@@@@  @@@  
@@@ @@@  @@@@@@@@  @@@  @@@     @@@       @@@@@@@@  @@@@@@@   @@@@@@@@  @@@  
@@! !@@  @@!  @@@  @@!  @@@     @@!       @@!  @@@  !@@       @@!       @@!  
!@! @!!  !@!  @!@  !@!  @!@     !@!       !@!  @!@  !@!       !@!       !@   
 !@!@!   @!@  !@!  @!@  !@!     @!!       @!@  !@!  !!@@!!    @!!!:!    @!@  
  @!!!   !@!  !!!  !@!  !!!     !!!       !@!  !!!   !!@!!!   !!!!!:    !!!  
  !!:    !!:  !!!  !!:  !!!     !!:       !!:  !!!       !:!  !!:            
  :!:    :!:  !:!  :!:  !:!      :!:      :!:  !:!      !:!   :!:       :!:  
   ::    ::::: ::  ::::: ::      :: ::::  ::::: ::  :::: ::    :: ::::   ::  
   :      : :  :    : :  :      : :: : :   : :  :   :: : :    : :: ::   :::  
                                                                             ");
                Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
                Thread.Sleep(250);
                SetColors();
            }
            Console.ReadKey(true);
        }
        private void PrintGameOver()
        {
            Console.Clear();
            Console.CursorVisible = true;
            BorderPrint("Game over! Thank you for playing. Why not have another go?");
        }
    }
}
