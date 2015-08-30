namespace TicTacToe
{
    class GameEngine
    {
        public string CheckForVictory(string[,] ticTacToeBoard, string currentPlayer)
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
    }
}
