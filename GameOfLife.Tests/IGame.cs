using GameOfLife.Core;
using GameOfLife.Infrastructure;

namespace GameOfLife.Tests
{
    public interface IGame
    {
        IBoard GetOutsideBoard(IBoard insideBoard);
    }
}