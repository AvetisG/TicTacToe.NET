namespace TicTacToe.GameModels
{
    internal class TicTacToeGridModel
    {
        public Enums.ControlEnums.Player[][] TicTacToeBoard;

        public TicTacToeGridModel()
        {
            TicTacToeBoard = new Enums.ControlEnums.Player[3][] {

                    new Enums.ControlEnums.Player[ 3 ] { Enums.ControlEnums.Player.None, Enums.ControlEnums.Player.None, Enums.ControlEnums.Player.None},

                    new Enums.ControlEnums.Player[ 3 ] { Enums.ControlEnums.Player.None, Enums.ControlEnums.Player.None, Enums.ControlEnums.Player.None},

                    new Enums.ControlEnums.Player[ 3 ] { Enums.ControlEnums.Player.None, Enums.ControlEnums.Player.None, Enums.ControlEnums.Player.None }
                };
        }
    }
}
