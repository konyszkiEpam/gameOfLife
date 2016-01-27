namespace GameOfLife.Core
{
    public interface IBoard
    {

        int MaxWidth { get; set; }
        int MaxHeight { get; set; }
        bool Compare(IBoard boardToCompare);
        bool GetLivingCell(int positionX, int positionY);
        bool GetNextLivingCell(IPoint point);
        void SetLivingCell(IPoint point, bool isAlive);
    }
}