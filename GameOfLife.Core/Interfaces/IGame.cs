namespace GameOfLife.Core.Interfaces
{
    public interface IGame
    {
        IBoard GetOutsideBoard(IBoard insideBoard);
    }
}