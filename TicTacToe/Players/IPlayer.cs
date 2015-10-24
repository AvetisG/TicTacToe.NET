using TicTacToe.Enums;

namespace TicTacToe.Players
{
    internal interface IPlayer
    {
        ControlEnums.Player Player { get; set; }
        PlayResponse Play(PlayRequest playRequest);
    }
}
