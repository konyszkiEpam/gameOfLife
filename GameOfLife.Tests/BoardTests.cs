using GameOfLife.Core.Model;
using Xunit;

namespace GameOfLife.Tests
{
    internal class BoardTests
    {
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
        public void GetNextLivingCell_lessThanTwoActiveNeighboursForActiveCell_ShouldReturnFalse()
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

        [Fact]
        public void GetNextLivingCell_ThreeActiveNeighboursForInActiveCell_ShouldReturnTrue()
        {
            //Arrange
            Board board = new Board(3, 3);
            board.SetLivingCell(new Point(0, 1), true);
            board.SetLivingCell(new Point(1, 1), true);
            board.SetLivingCell(new Point(2, 1), true);
            //Act
            bool expectedAlive = board.GetNextLivingCell(new Point(1, 2));

            //Assert
            Assert.Equal(true, expectedAlive);
        }
    }
}