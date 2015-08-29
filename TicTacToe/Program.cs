namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] TicTacToeBoard = new string[3, 3];

            GameEngine gameEngine = new GameEngine();

            gameEngine.StartGame(TicTacToeBoard);
        }
    }
}
