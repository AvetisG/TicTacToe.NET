namespace TicTacToe
{
    interface IPlayer
    {
        string GetPlayer();
        void SetPlayer(string player);
        void Play(string[,] TicTacToeBoard);
    }
}
