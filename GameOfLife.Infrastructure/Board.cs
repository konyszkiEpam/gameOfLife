using System.Net.NetworkInformation;
using GameOfLife.Core;

namespace GameOfLife.Infrastructure
{
    public class Board : IBoard
    {
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }

        public Cell[,] Cells { get; set; }

        public Board(int maxWidth, int maxHeight)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;

            Cells = new Cell[maxWidth + 2, maxHeight + 2];

            //+2 for border
            for (int i = 0; i < maxWidth + 2; i++)
                for (int j = 0; j < maxHeight + 2; j++)
                {
                    Cells[i, j] = new Cell(new Point(i, j));
                }
        }


        public bool Compare(IBoard boardToCompare)
        {

            if (MaxWidth != boardToCompare.MaxWidth) return false;
            if (MaxHeight != boardToCompare.MaxHeight) return false;


            for (int i = 0; i < MaxWidth + 2; i++)
                for (int j = 0; j < MaxHeight + 2; j++)
                {
                    if(Cells[i, j].IsAlive != boardToCompare.GetLivingCell(i - 1, j - 1))
                    return false;
                }

            return true;
        }

        public bool GetNextLivingCell(IPoint point)
        {
            int countAliveNeighbours = 0;

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j==0)
                        continue;

                    countAliveNeighbours = Cells[point.X + i + 1, point.Y + j + 1].IsAlive ? ++countAliveNeighbours : countAliveNeighbours;

                    if (countAliveNeighbours > 2) return true;
                }

            return countAliveNeighbours >= 2 && Cells[point.X + 1, point.Y + 1].IsAlive || countAliveNeighbours > 2;
        }

        public void SetLivingCell(IPoint point, bool isAlive)
        {
            Cells[point.X + 1, point.Y + 1].IsAlive = isAlive;
        }

        public bool GetLivingCell(int positionX, int positionY)
        {
            return Cells[positionX + 1, positionY + 1].IsAlive;
        }
    }
}