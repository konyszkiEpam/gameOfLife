namespace GameOfLife.Infrastructure
{
    public class Cell
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