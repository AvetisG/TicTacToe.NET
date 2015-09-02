using System;

namespace TicTacToe
{
    class GameManager
    {
        private readonly GameVisualizer _gameVisualizer;
        private readonly GameEngine _gameEngine;
        private IPlayer player1;
        private IPlayer player2;

        public GameManager(GameVisualizer argGameVisualizer, GameEngine argGameEngine)
        {
            _gameVisualizer = argGameVisualizer;
            _gameEngine = argGameEngine;
        }

        public void StartGame(string[,] TicTacToeBoard)
        {
            _gameVisualizer.InitializeBoard(TicTacToeBoard);

            ChooseMode();

            ChoosePlayer();

            PlayGame(TicTacToeBoard);
        }

        private void ChooseMode()
        {
            while(true)
            {
                Console.WriteLine("Choose playing mode - 2PLAYER or AI?");
                var mode = Console.ReadLine();
                if (mode.ToUpper().Equals("2PLAYER"))
                {
                    player1 = new RealPlayer();
                    player2 = new RealPlayer();
                    break;
                }
                else if (mode.ToUpper().Equals("AI"))
                {
                    player1 = new RealPlayer();
                    player2 = new AIPlayer();
                    break;
                }
            }
        }

        private void ChoosePlayer()
        {
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
        }

        private void PlayGame(string[,] ticTacToeBoard)
        {
            var Winner = string.Empty;
            var currentPlayer = player1;

            while (Winner.Equals(string.Empty))
            {
                player1.Play(ticTacToeBoard);
                player2.Play(ticTacToeBoard);

                _gameVisualizer.PrintTicTacToeBoard(ticTacToeBoard);

                Winner = _gameEngine.CheckForVictory(ticTacToeBoard, currentPlayer.GetPlayer());

                currentPlayer = currentPlayer.Equals(player1) ? player2 : player1;
            }

            Console.WriteLine("The winner is {0}", Winner);
        }
    }
}
