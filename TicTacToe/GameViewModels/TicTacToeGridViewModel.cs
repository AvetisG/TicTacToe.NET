using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TicTacToe.Enums;
using TicTacToe.GameModels;
using TicTacToe.Players;

namespace TicTacToe.GameViewModels
{
    public class TicTacToeGridViewModel : ViewModelBase
    {
        private ObservableCollection<ObservableCollection<ControlEnums.Player>> _ticTacToeBoard = new ObservableCollection<ObservableCollection<ControlEnums.Player>>();
        private TicTacToeControlsViewModel _ticTacToeControlsViewModel;
        private bool _playerWon;

        public ICommand MakeMoveCommand { get; set; }

        internal TicTacToeGridViewModel(TicTacToeGridModel ticTacToeGridModel, TicTacToeControlsViewModel ticTacToeControlsViewModel)
        {
            _playerWon = false;
            _ticTacToeControlsViewModel = ticTacToeControlsViewModel;
            ConvertTicTacToeToObservableCollection(ticTacToeGridModel);
            
            MakeMoveCommand = new RelayCommand<int[]>(this.MakeMove);
        }

        private void ConvertTicTacToeToObservableCollection(TicTacToeGridModel TicTacToeGridModel)
        {
            foreach (var items in TicTacToeGridModel.TicTacToeBoard)
            {
                ObservableCollection<ControlEnums.Player> TicTacToeRow = new ObservableCollection<ControlEnums.Player>();
                foreach (var item in items) TicTacToeRow.Add(item);
                _ticTacToeBoard.Add(TicTacToeRow);
            }
        }

        public ObservableCollection<ObservableCollection<ControlEnums.Player>> TicTacToeBoard
        {
            get { return _ticTacToeBoard; }
            set {
                _ticTacToeBoard = value;
                RaisePropertyChanged("TicTacToeBoard");
            }
        }

        public bool PlayerWon
        {
            get { return _playerWon; }
            set
            {
                _playerWon = value;
                RaisePropertyChanged("PlayerWon");
            }
        }

        private void MakeMove(int[] movePositions)
        {
            if (_ticTacToeControlsViewModel.GameStarted && TicTacToeBoard[movePositions[1]][movePositions[0]] == ControlEnums.Player.None)
            {
                PlayRequest request = BuildPlayRequest(movePositions);

                PlayResponse response = _ticTacToeControlsViewModel.GameScenario.Execute(request);

                PlayerWon = response.PlayerWon;
            }
        }

        private PlayRequest BuildPlayRequest(int[] movePositions)
        {
            PlayRequest PlayRequest = new PlayRequest();
            PlayRequest.TicTacToeBoard = TicTacToeBoard;
            PlayRequest.PositionX = movePositions[1];
            PlayRequest.PositionY = movePositions[0];
            return PlayRequest;
        }
    }
}