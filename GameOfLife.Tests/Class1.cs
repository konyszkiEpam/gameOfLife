using GameOfLife.Core;
using GameOfLife.Infrastructure;
using Xunit;

namespace GameOfLife.Tests
{
    public class Class1
    {
        public class Game
        {
            public IBoard GetOutsideBoard(Board insideBoard)
            {
                IBoard board = new Board(insideBoard.MaxWidth, insideBoard.MaxHeight);

                return board;
            }
        }

        [Fact]
        public void GetNextLivingCell_lessThenThreeNeighboursForInActiveCell_ShouldReturnFalse()
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
        public void GetNextLivingCell_moreThenThreeNeighboursForInactiveCell_shouldReturnTrue()
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
        public void GetNextLivingCell_WithTwoActiveNeighboursForActiveCell_ShouldReturnTrue()
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

        [Fact]
        public void GetNextLivingCell_lessThanTwoActiveNeighboursForActiveCell_ShouldReturnTrue()
        {
            //Arrange
            Board board = new Board(3, 3);
            board.SetLivingCell(new Point(0, 0), true);
            board.SetLivingCell(new Point(1, 1), true);
            //Act
            bool expectedAlive = board.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(false, expectedAlive);
        }
    }
}