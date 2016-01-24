namespace GameOfLife.Infrastructure
{
    public class Board
    {
        public Board(Cell[,] cells)
        {
            Cells = cells;
        }

        public Board(int maxWidth, int maxHeight)
        {
            Cells = new Cell[maxWidth + 2, maxHeight + 2];

            //+2 for border
            for (int i = 0; i < maxWidth + 2; i++)
                for (int j = 0; j < maxHeight + 2; j++)
                {
                    Cells[i, j] = new Cell(new Point(i, j));
                }
        }

        private Cell[,] Cells { get; set; }

        public bool GetNextLivingCell(Point point)
        {
            int countAliveNeighbours = 0;

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    countAliveNeighbours = Cells[point.X + i + 1, point.Y + j + 1].IsAlive ? ++countAliveNeighbours : countAliveNeighbours;

                    if (countAliveNeighbours > 2) return true;
                }

            return countAliveNeighbours >= 2 && Cells[point.X + 1, point.Y + 1].IsAlive || countAliveNeighbours > 2;
        }

        public void SetLivingCell(Point point, bool isAlive)
        {
            Cells[point.X + 1, point.Y + 1].IsAlive = isAlive;
        }

        public bool GetLivingCell(int positionX, int positionY)
        {
            return Cells[positionX + 1, positionY + 1].IsAlive;
        }
    }
}