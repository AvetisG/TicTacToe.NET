namespace TicTacToe.GameViewModels
{
    public class GameWindowViewModel
    {
        public TicTacToeControlsViewModel TicTacToeControlsViewModel { get; }
        public TicTacToeGridViewModel TicTacToeGridViewModel { get; }

        public GameWindowViewModel(TicTacToeControlsViewModel TicTacToeControlsViewModel, TicTacToeGridViewModel TicTacToeGridViewModel)
        {
            this.TicTacToeControlsViewModel = TicTacToeControlsViewModel;
            this.TicTacToeGridViewModel = TicTacToeGridViewModel;
        }
    }
}
