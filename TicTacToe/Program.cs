using System;
using TicTacToe.Factories;
using TicTacToe.GameModels;
using TicTacToe.GameViewModels;

namespace TicTacToe
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            VictoryValidator victoryValidator = new VictoryValidator();
            PlayerFactory playerFactory = new PlayerFactory(victoryValidator);
            ScenarioFactory scenarioFactory = new ScenarioFactory(playerFactory);

            TicTacToeControlsViewModel TicTacToeControlsViewModel = new TicTacToeControlsViewModel(new TicTacToeControlsModel(), scenarioFactory);
            TicTacToeGridViewModel TicTacToeGridViewModel = new TicTacToeGridViewModel(new TicTacToeGridModel(), TicTacToeControlsViewModel);
            GameWindowViewModel GameWindowViewModel = new GameWindowViewModel(TicTacToeControlsViewModel, TicTacToeGridViewModel);

            GameWindow gameWindow = new GameWindow(GameWindowViewModel);
            gameWindow.ShowDialog();
        }
    }
}
