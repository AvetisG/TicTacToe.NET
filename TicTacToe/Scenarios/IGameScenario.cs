using TicTacToe.Players;

namespace TicTacToe.Scenarios
{
    public interface IGameScenario
    {
        PlayResponse Execute(PlayRequest PlayRequest);
    }
}
