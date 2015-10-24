using System.Collections.Generic;
using TicTacToe.Enums;

namespace TicTacToe.GameModels
{
    public class TicTacToeControlsModel
    {
        public IEnumerable<ControlEnums.GameMode> GameModes { get; }
        public IEnumerable<ControlEnums.Player> Players { get; }

        public TicTacToeControlsModel()
        {
            GameModes = new List<ControlEnums.GameMode> {
                ControlEnums.GameMode.None,
                ControlEnums.GameMode.AI,
                ControlEnums.GameMode.TwoPlayer };

            Players = new List<ControlEnums.Player> {
                ControlEnums.Player.None,
                ControlEnums.Player.X,
                ControlEnums.Player.O };
        }
    }
}
