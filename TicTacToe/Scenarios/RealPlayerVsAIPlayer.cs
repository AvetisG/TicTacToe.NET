using TicTacToe.Enums;
using TicTacToe.Factories;
using TicTacToe.Players;

namespace TicTacToe.Scenarios
{
    internal class RealPlayerVsAIPlayer : IGameScenario
    {
        private IPlayer _realPlayer;
        private IPlayer _AIPlayer;
        private IPlayer _currentPlayer;

        public RealPlayerVsAIPlayer(PlayerFactory playerFactory, ControlEnums.Player player)
        {
            _realPlayer = playerFactory.BuildRealPlayer();
            _AIPlayer = playerFactory.BuildAIPlayer();

            _realPlayer.Player = player;
            _AIPlayer.Player = player == ControlEnums.Player.O ? ControlEnums.Player.X : ControlEnums.Player.O;
        }

        public PlayResponse Execute(PlayRequest PlayRequest)
        {
            _currentPlayer = ((_currentPlayer != null) && _currentPlayer.Equals(_realPlayer)) ? _AIPlayer : _realPlayer;
            PlayResponse response = _currentPlayer.Play(PlayRequest);

            if (!response.PlayerWon)
            {
                _currentPlayer = ((_currentPlayer != null) && _currentPlayer.Equals(_realPlayer)) ? _AIPlayer : _realPlayer;

                PlayRequest request = new PlayRequest();
                request.TicTacToeBoard = response.TicTacToeBoard;

                response = _currentPlayer.Play(request);
            }

            return response;
        }
    }
}
