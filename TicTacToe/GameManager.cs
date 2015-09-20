using System;

namespace TicTacToe
{
    class GameManager
    {
        private readonly GameVisualizer _gameVisualizer;
        private readonly GameEngine _gameEngine;

        public GameManager(GameVisualizer argGameVisualizer, GameEngine argGameEngine)
        {
            _gameVisualizer = argGameVisualizer;
            _gameEngine = argGameEngine;
        }

        public void PlayGame(string[,] TicTacToeBoard, IPlayer player1, IPlayer player2)
        {
            _gameVisualizer.InitializeBoard(TicTacToeBoard);

            Console.WriteLine("Player1, Do you want to be X or O?");
            while (true)
            {
                var player1Name = Console.ReadLine().ToUpper();

                if (player1Name.ToUpper().Equals("X") || player1Name.ToUpper().Equals("O"))
                {
                    player1.SetPlayer(player1Name);
                    break;
                }
            }

            player2.SetPlayer(player1.GetPlayer().ToUpper().Equals("X") ? "O" : "X");

            var Winner = string.Empty;
            var currentPlayer = player1;

            while (Winner.Equals(string.Empty))
            {
                player1.Play(TicTacToeBoard);
                player2.Play(TicTacToeBoard);

                _gameVisualizer.PrintTicTacToeBoard(TicTacToeBoard);

                Winner = _gameEngine.CheckForVictory(TicTacToeBoard, currentPlayer.GetPlayer());

                currentPlayer = currentPlayer.Equals(player1) ? player2 : player1;
            }

            Console.WriteLine("The winner is {0}", Winner);
        }
    }
}
