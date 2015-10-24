using TicTacToe.Enums;

namespace TicTacToe.Players
{
    internal class RealPlayer : IPlayer
    {
        private VictoryValidator _victoryValidator;

        public RealPlayer(VictoryValidator victoryValidator)
        {
            _victoryValidator = victoryValidator;
        }

        public PlayResponse Play(PlayRequest playRequest)
        {
            PlayResponse playResponse = new PlayResponse();

            if (playRequest.TicTacToeBoard[playRequest.PositionX][playRequest.PositionY] == ControlEnums.Player.None)
            {
                playRequest.TicTacToeBoard[playRequest.PositionX][playRequest.PositionY] = Player;

                playResponse.TicTacToeBoard = playRequest.TicTacToeBoard;
            }

            playResponse.PlayerWon = _victoryValidator.CheckForVictory(playRequest.TicTacToeBoard, Player);

            return playResponse;
        }

        public ControlEnums.Player Player { get; set; }
    }
}
