using GameOfLife.Core.Interfaces;

namespace GameOfLife.Core.Model
{
    public class Game
    {
        public IBoard GetOutsideBoard(IBoard insideBoard)
        {
            Board nextBoard = new Board(insideBoard.MaxWidth, insideBoard.MaxHeight);

            for (int i = 0; i < insideBoard.MaxWidth; ++i)
                for (int j = 0; j < insideBoard.MaxHeight; ++j)
                {
                    IPoint newPoint = new Point(i, j);

                    bool isPointActive = insideBoard.GetNextLivingCell(newPoint);

                    nextBoard.SetLivingCell(newPoint, isPointActive);
                }

            return nextBoard;
        }
    }
}