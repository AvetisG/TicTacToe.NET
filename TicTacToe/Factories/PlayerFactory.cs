using TicTacToe.Players;

namespace TicTacToe.Factories
{
    internal class PlayerFactory
    {
        VictoryValidator _victoryValidator;

        public PlayerFactory(VictoryValidator victoryValidator)
        {
            _victoryValidator = victoryValidator;
        }

        public RealPlayer BuildRealPlayer()
        {
            return new RealPlayer(_victoryValidator);
        }

        public AIPlayer BuildAIPlayer()
        {
            return new AIPlayer(_victoryValidator);
        }
    }
}
