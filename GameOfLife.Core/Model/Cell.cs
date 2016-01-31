using GameOfLife.Core.Interfaces;

namespace GameOfLife.Core.Model
{
    public class Cell : ICell
    {
        public Cell(Point point, bool isAlive = false)
        {
            Point = point;
            IsAlive = isAlive;
        }

        public Point Point { get; set; }
        public bool IsAlive { get; set; }
    }
}