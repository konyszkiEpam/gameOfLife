namespace GameOfLife.Core
{
    public interface IBoard
    {
        bool GetLivingCell(int positionX, int positionY);
        bool GetNextLivingCell(IPoint point);
        void SetLivingCell(IPoint point, bool isAlive);
    }
}