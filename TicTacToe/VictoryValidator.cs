using System.Collections.ObjectModel;

namespace TicTacToe
{
    internal class VictoryValidator
    {
        public bool CheckForVictory(ObservableCollection<ObservableCollection<Enums.ControlEnums.Player>> TicTacToeBoard, Enums.ControlEnums.Player CurrentPlayer)
        {
            var HorizontalVictory = 0;
            var VerticalVictory = 0;
            var DiagonalVictory = 0;

            for (int i = 0; i < TicTacToeBoard.Count; i++)
            {
                if (HorizontalVictory == 3)
                    break;
                else
                    HorizontalVictory = 0;
                for (int j = 0; j < TicTacToeBoard.Count; j++)
                {
                    if (TicTacToeBoard[i][j].Equals(CurrentPlayer))
                        HorizontalVictory++;
                }
            }

            for (int i = 0; i < TicTacToeBoard.Count; i++)
            {
                if (VerticalVictory == 3)
                    break;
                else
                    VerticalVictory = 0;
                for (int j = 0; j < TicTacToeBoard.Count; j++)
                {
                    if (TicTacToeBoard[j][i].Equals(CurrentPlayer))
                        VerticalVictory++;
                }
            }

            for(int i=0; i< TicTacToeBoard.Count; i++)
            {
                if (TicTacToeBoard[i][i].Equals(CurrentPlayer))
                    DiagonalVictory++;
            }

            if (DiagonalVictory != 3)
            {
                DiagonalVictory = 0;
                for (int i = 0; i < TicTacToeBoard.Count; i++)
                {
                    if (TicTacToeBoard[i][(TicTacToeBoard.Count - 1) - i].Equals(CurrentPlayer))
                        DiagonalVictory++;
                }
            }

            return HorizontalVictory == 3 || VerticalVictory == 3 || DiagonalVictory == 3;
        }
    }
}
