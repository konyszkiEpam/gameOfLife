using Xunit;

namespace GameOfLife.Tests
{
    public class Class1
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point(Point point)
            {
                X = point.X;
                Y = point.Y;
            }
        }

        public class Cell
        {
            public Point Point { get; set; }

            public bool IsAlive { get; set; }

            public Cell(Point point, bool isAlive=false)
            {
                Point = new Point(point);
                IsAlive = isAlive;
            }
        }

        public class Board
        {
            private Cell[,] Cells { get; set; }

            public bool GetNextLivingCell(Point point)
            {
                int countAliveNeighbours = 0;


                for (int i = -1; i <= 1; i++)
                    for(int j=-1; j<=1; j++)
                {
                        if(i==0 && j==0)
                            continue;

                    countAliveNeighbours = Cells[point.X + i + 1, point.Y + j + 1].IsAlive ? ++countAliveNeighbours : countAliveNeighbours;

                    if (countAliveNeighbours > 2) return true;
                }

                return countAliveNeighbours >= 2 && Cells[point.X+1,point.Y+1].IsAlive || countAliveNeighbours >2;
            }

            public Board(int maxWidth, int maxHeight)
            {
                Cells = new Cell[maxWidth+2, maxHeight+2];

                //+2 for border
                for (int i = 0; i < maxWidth + 2; i++)
                    for (int j = 0; j < maxHeight + 2; j++)
                    {
                        Cells[i, j] = new Cell(new Point(i, j), false);
                    }
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

        public class Game
        {
            public Board GetOutsideBoard(Board insideBoard)
            {
                return null;
            }
        }

        [Fact]
        public void GetNextLivingCell_lessThenThreeNeighboursWithInActiveCell_ShouldReturnFalse()
        {
            //Arrange
            Board board = new Board(3, 3);
            board.SetLivingCell(new Point(0, 0), true);
            board.SetLivingCell(new Point(0, 1), true);
            //Act
            bool expectedAlive = board.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(false, expectedAlive);
        }

        [Fact]
        public void GetNextLivingCell_moreThenThreeNeighboursWithInactiveCell_shouldReturnTrue()
        {
            //Arrange
            Board board = new Board(3, 3);
            board.SetLivingCell(new Point(0, 0), true);
            board.SetLivingCell(new Point(0, 1), true);
            board.SetLivingCell(new Point(0, 2), true);
            board.SetLivingCell(new Point(2, 2), true);
            //Act
            bool expectedAlive = board.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(true, expectedAlive);
        }


        [Fact]
        public void GetNextLivingCell_lessWithTwoActiveNeighboursFromActiveCell_ShouldReturnTrue()
        {
            //Arrange
            Board board = new Board(3, 3);
            board.SetLivingCell(new Point(0, 0), true);
            board.SetLivingCell(new Point(0, 1), true);
            board.SetLivingCell(new Point(1, 1), true);
            //Act
            bool expectedAlive = board.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(true, expectedAlive);
        }
    }
}