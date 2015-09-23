using System;

namespace TicTacToe
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string[,] TicTacToeBoard = new string[3, 3];
            IPlayer player1;
            IPlayer player2;

            GameEngine gameEngine = new GameEngine();
            GameVisualizer gameVisualizer = new GameVisualizer();
            GameManager gameManager = new GameManager(gameVisualizer, gameEngine);

            GameWindow gameWindow = new GameWindow();
            gameWindow.ShowDialog();

            //while (true)
            //{
            //    Console.WriteLine("Choose playing mode - 2PLAYER or AI?");
            //    var mode = Console.ReadLine();
            //    if (mode.ToUpper().Equals("2PLAYER"))
            //    {
            //        player1 = new RealPlayer();
            //        player2 = new RealPlayer();
            //        break;
            //    }
            //    else if (mode.ToUpper().Equals("AI"))
            //    {
            //        player1 = new RealPlayer();
            //        player2 = new AIPlayer();
            //        break;
            //    }
            //}

            //gameManager.PlayGame(TicTacToeBoard, player1, player2);
        }
    }
}
