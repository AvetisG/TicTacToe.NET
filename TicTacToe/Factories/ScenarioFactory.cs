using TicTacToe.Enums;
using TicTacToe.Scenarios;

namespace TicTacToe.Factories
{
    internal class ScenarioFactory
    {
        private PlayerFactory _playerFactory;

        public ScenarioFactory(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public RealPlayerVsAIPlayer BuildRealPlayerVsAIPlayer(ControlEnums.Player player)
        {
            return new RealPlayerVsAIPlayer(_playerFactory, player);
        }

        public RealPlayerVsRealPlayer BuildRealPlayerVsRealPlayer(ControlEnums.Player player)
        {
            return new RealPlayerVsRealPlayer(_playerFactory, player);
        }
    }
}
