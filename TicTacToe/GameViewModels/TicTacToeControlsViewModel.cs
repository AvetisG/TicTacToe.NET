using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using TicTacToe.Enums;
using TicTacToe.Factories;
using TicTacToe.GameModels;
using TicTacToe.Scenarios;

namespace TicTacToe.GameViewModels
{
    public class TicTacToeControlsViewModel : ViewModelBase
    {
        private List<ControlEnums.GameMode> _gameModeSource = new List<ControlEnums.GameMode>();
        private List<ControlEnums.Player> _playerSource = new List<ControlEnums.Player>();
        private ControlEnums.GameMode _gameMode;
        private ScenarioFactory _scenarioFactory;
        private bool _gameStarted;
        public ICommand StartGameCommand { get; set; }

        internal TicTacToeControlsViewModel(TicTacToeControlsModel TicTacToeControlsModel, ScenarioFactory scenarioFactory)
        {
            _gameModeSource.AddRange(TicTacToeControlsModel.GameModes);
            _playerSource.AddRange(TicTacToeControlsModel.Players);
            _scenarioFactory = scenarioFactory;

            StartGameCommand = new RelayCommand(this.StartGame);
        }

        public IEnumerable<ControlEnums.GameMode> GameModeSource
        {
            get { return _gameModeSource; }
        }

        public IEnumerable<ControlEnums.Player> PlayerSource
        {
            get { return _playerSource; }
        }

        public ControlEnums.GameMode GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value;}
        }

        public bool GameStarted
        {
            get { return _gameStarted; }
            set {
                _gameStarted = value;
                RaisePropertyChanged(() => GameStarted);
            }
        }

        public ControlEnums.Player Player { get; set; }

        public IGameScenario GameScenario { get; set; }

        public void StartGame()
        {
            if (GameMode != ControlEnums.GameMode.None && Player != ControlEnums.Player.None)
            {
                if (GameMode == ControlEnums.GameMode.AI)
                { 
                    GameScenario = _scenarioFactory.BuildRealPlayerVsAIPlayer(Player);
                }
                else
                {
                    GameScenario = _scenarioFactory.BuildRealPlayerVsRealPlayer(Player);
                }
                
                GameStarted = true;
            }
        }
    }
}
