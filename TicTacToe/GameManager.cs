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

        public void StartGame(string[,] TicTacToeBoard)
        {
            var player1 = string.Empty;
            var player2 = string.Empty;

            _gameVisualizer.InitializeBoard(TicTacToeBoard);

            ChoosePlayer(ref player1, ref player2);

            PlayGame(TicTacToeBoard, player1, player2);
        }

        private void ChoosePlayer(ref string player1, ref string player2)
        {
            Console.WriteLine("Player1, Do you want to be X or O?");
            while (true)
            {
                player1 = Console.ReadLine().ToUpper();

                if (player1.ToUpper().Equals("X") || player1.ToUpper().Equals("O")) break;
            }

            player2 = player1.ToUpper().Equals("X") ? "O" : "X";
        }

        private void PlayGame(string[,] ticTacToeBoard, string player1, string player2)
        {
            var Winner = string.Empty;
            var currentPlayer = player1;

            while (Winner.Equals(string.Empty))
            {
                Console.WriteLine("Enter position X for {0}", currentPlayer);
                int positionX = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter position Y for {0}", currentPlayer);
                int positionY = Int32.Parse(Console.ReadLine());

                if (ticTacToeBoard[positionX, positionY].Equals(" ")) ticTacToeBoard[positionX, positionY] = currentPlayer;

                _gameVisualizer.PrintTicTacToeBoard(ticTacToeBoard);

                Winner = _gameEngine.CheckForVictory(ticTacToeBoard, currentPlayer);

                currentPlayer = currentPlayer.Equals(player1) ? player2 : player1;
            }

            Console.WriteLine("The winner is {0}", Winner);
        }
    }
}
