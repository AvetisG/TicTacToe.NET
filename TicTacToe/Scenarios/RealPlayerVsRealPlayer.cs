using TicTacToe.Enums;
using TicTacToe.Factories;
using TicTacToe.Players;

namespace TicTacToe.Scenarios
{
    internal class RealPlayerVsRealPlayer : IGameScenario
    {
        private IPlayer _realPlayer1;
        private IPlayer _realPlayer2;
        private IPlayer _currentPlayer;

        public RealPlayerVsRealPlayer(PlayerFactory playerFactory, ControlEnums.Player player)
        {
            _realPlayer1 = playerFactory.BuildRealPlayer();
            _realPlayer2 = playerFactory.BuildRealPlayer();

            _realPlayer1.Player = player;
            _realPlayer2.Player = player == ControlEnums.Player.O ? ControlEnums.Player.X : ControlEnums.Player.O;
        }

        public PlayResponse Execute(PlayRequest PlayRequest)
        {
            _currentPlayer = ((_currentPlayer != null) && _currentPlayer.Equals(_realPlayer1)) ? _realPlayer2 : _realPlayer1;

            PlayResponse response = _currentPlayer.Play(PlayRequest);
            
            return response;
        }
    }
}
