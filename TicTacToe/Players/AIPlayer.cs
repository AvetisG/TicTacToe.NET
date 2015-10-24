using TicTacToe.Enums;

namespace TicTacToe.Players
{
    internal class AIPlayer : IPlayer
    {
        private VictoryValidator _victoryValidator;

        public AIPlayer(VictoryValidator victoryValidator)
        {
            _victoryValidator = victoryValidator;
        }

        public PlayResponse Play(PlayRequest playRequest)
        {
            PlayResponse PlayResponse = new PlayResponse();

            for (int i=0; i< playRequest.TicTacToeBoard.Count; i++)
            {
                for (int j = 0; j < playRequest.TicTacToeBoard.Count; j++)
                {
                    if (playRequest.TicTacToeBoard[i][j].Equals(ControlEnums.Player.None))
                    {
                        playRequest.TicTacToeBoard[i][j] = Player;

                        PlayResponse.TicTacToeBoard = playRequest.TicTacToeBoard;
                        PlayResponse.PlayerWon = _victoryValidator.CheckForVictory(playRequest.TicTacToeBoard, Player);

                        return PlayResponse;
                    }
                }
            }

            PlayResponse.TicTacToeBoard = playRequest.TicTacToeBoard;
            return PlayResponse;
        }

        public ControlEnums.Player Player { get; set; }
    }
}
