namespace OOA_Tarning
{
    using System;
    using Helpers;
    using static Helpers.ConsoleWriteHelper;

    public class DiceGame
    {
        private bool wantToExit = false;
        private int pixBalance = 500;
        public void Run()
        {
            Intro();
            while (!wantToExit && pixBalance > 100)
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
            //kör en runda av spelet
        }

        private void MainMenu()
        {
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
