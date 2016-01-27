namespace GameOfLife.Core
{
    public interface IGame
    {
        IBoard GetOutsideBoard(IBoard insideBoard);
    }
}