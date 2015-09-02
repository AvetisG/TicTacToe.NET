using System;

namespace TicTacToe
{
    class RealPlayer : IPlayer
    {
        public string player;

        public void Play(string[,] TicTacToeBoard)
        {
            Console.WriteLine("Enter position X for {0}", player);
            int positionX = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter position Y for {0}", player);
            int positionY = Int32.Parse(Console.ReadLine());

            if (TicTacToeBoard[positionX, positionY].Equals(" ")) TicTacToeBoard[positionX, positionY] = player;
        }

        public void SetPlayer(string player)
        {
            this.player = player;
        }

        public string GetPlayer()
        {
            return player;
        }
    }
}
