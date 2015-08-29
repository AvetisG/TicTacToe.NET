using System;

namespace TicTacToe
{
    class GameEngine
    {
        public void StartGame(string[,] TicTacToeBoard)
        {
            var player1 = string.Empty;
            var player2 = string.Empty;

            InitializeBoard(TicTacToeBoard);

            ChoosePlayer(ref player1, ref player2);

            PlayGame(TicTacToeBoard, player1, player2);
        }

        private void PlayGame(string[,] ticTacToeBoard, string player1, string player2)
        {
            var Winner = string.Empty;
            var currentPlayer = player1;

            while(Winner.Equals(string.Empty))
            {
                Console.WriteLine("Enter position X for {0}", currentPlayer);
                int positionX = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter position Y for {0}", currentPlayer);
                int positionY = Int32.Parse(Console.ReadLine());

                if (ticTacToeBoard[positionX, positionY].Equals(" ")) ticTacToeBoard[positionX, positionY] = currentPlayer;

                PrintTicTacToeBoard(ticTacToeBoard);

                Winner = CheckForVictory(ticTacToeBoard, currentPlayer);

                currentPlayer = currentPlayer.Equals(player1) ? player2 : player1;
            }

            Console.WriteLine("The winner is {0}", Winner);
        }

        private string CheckForVictory(string[,] ticTacToeBoard, string currentPlayer)
        {
            var HorizontalVictory = 0;
            var VerticalVictory = 0;
            var DiagonalVictory = 0;

            for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (HorizontalVictory == 3)
                    break;
                else
                    HorizontalVictory = 0;
                for (int j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    if (ticTacToeBoard[i, j].Equals(currentPlayer))
                        HorizontalVictory++;
                }
            }

            for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (VerticalVictory == 3)
                    break;
                else
                    VerticalVictory = 0;
                for (int j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    if (ticTacToeBoard[j, i].Equals(currentPlayer))
                        VerticalVictory++;
                }
            }

            for(int i=0; i< ticTacToeBoard.GetLength(0); i++)
            {
                if (ticTacToeBoard[i, i].Equals(currentPlayer))
                    DiagonalVictory++;
            }

            if (DiagonalVictory != 3)
            {
                DiagonalVictory = 0;
                for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
                {
                    if (ticTacToeBoard[(ticTacToeBoard.GetLength(0) - 1) - i, (ticTacToeBoard.GetLength(0) - 1) - i].Equals(currentPlayer))
                        DiagonalVictory++;
                }
            }

            return HorizontalVictory == 3 || VerticalVictory == 3 || DiagonalVictory == 3 ? currentPlayer : string.Empty;
        }

        private void PrintTicTacToeBoard(string[,] ticTacToeBoard)
        {
            for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                for (int j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    Console.Write(ticTacToeBoard[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void ChoosePlayer(ref string player1, ref string player2)
        {
            Console.WriteLine("Player1, Do you want to be X or O?");
            while(true)
            {
                player1 = Console.ReadLine().ToUpper();

                if (player1.ToUpper().Equals("X") || player1.ToUpper().Equals("O")) break;
            }

            player2 = player1.ToUpper().Equals("X") ? "O" : "X";
        }

        private void InitializeBoard(string[,] ticTacToeBoard)
        {
            for(int i=0; i<ticTacToeBoard.GetLength(0); i++)
            {
                for (int j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    ticTacToeBoard[i, j] = " ";
                }
            }
        }
    }
}
