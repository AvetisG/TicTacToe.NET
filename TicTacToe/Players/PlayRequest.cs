using System.Collections.ObjectModel;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class PlayRequest
    {
        public ObservableCollection<ObservableCollection<ControlEnums.Player>> TicTacToeBoard { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
