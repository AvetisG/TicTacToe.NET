using System.Collections.ObjectModel;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class PlayResponse
    {
        public ObservableCollection<ObservableCollection<ControlEnums.Player>> TicTacToeBoard { get; set; }
        public bool PlayerWon { get; set; }
    }
}
