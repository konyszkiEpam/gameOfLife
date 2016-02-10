using FakeItEasy;
using GameOfLife.Core.Interfaces;
using GameOfLife.Core.Model;
using Xunit;

namespace GameOfLife.Tests
{
    public class BoardTests
    {
        [Fact]
        public void GetNextLivingCell_lessThenThreeNeighboursForInActiveCell_ShouldReturnFalse()
        {
            //Arrange
            IBoard boardFake = A.Fake<Board>(x => x.WithArgumentsForConstructor(() => new Board(3, 3)));
            boardFake.SetLivingCell(new Point(0, 0), true);
            boardFake.SetLivingCell(new Point(0, 1), true);

            //Act
            bool expectedAlive = boardFake.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(false, expectedAlive);
        }

        [Fact]
        public void GetNextLivingCell_moreThenThreeNeighboursForInactiveCell_shouldReturnTrue()
        {
            //Arrange
            IBoard boardFake = A.Fake<Board>(x => x.WithArgumentsForConstructor(() => new Board(3, 3)));
            boardFake.SetLivingCell(new Point(0, 0), true);
            boardFake.SetLivingCell(new Point(0, 1), true);
            boardFake.SetLivingCell(new Point(0, 2), true);
            //Act
            bool expectedAlive = boardFake.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(true, expectedAlive);
        }

        [Fact]
        public void GetNextLivingCell_WithTwoActiveNeighboursForActiveCell_ShouldReturnTrue()
        {
            //Arrange
            IBoard boardFake = A.Fake<Board>(x => x.WithArgumentsForConstructor(() => new Board(3, 3)));
            boardFake.SetLivingCell(new Point(0, 0), true);
            boardFake.SetLivingCell(new Point(0, 1), true);
            boardFake.SetLivingCell(new Point(1, 1), true);
            //Act
            bool expectedAlive = boardFake.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(true, expectedAlive);
        }

        [Fact]
        public void GetNextLivingCell_lessThanTwoActiveNeighboursForActiveCell_ShouldReturnFalse()
        {
            //Arrange
            IBoard boardFake = A.Fake<Board>(x => x.WithArgumentsForConstructor(() => new Board(3, 3)));
            boardFake.SetLivingCell(new Point(0, 0), true);
            boardFake.SetLivingCell(new Point(1, 1), true);
            //Act
            bool expectedAlive = boardFake.GetNextLivingCell(new Point(1, 1));

            //Assert
            Assert.Equal(false, expectedAlive);
        }

        [Fact]
        public void GetNextLivingCell_ThreeActiveNeighboursForInActiveCell_ShouldReturnTrue()
        {
            //Arrange
            IBoard boardFake = A.Fake<Board>(x => x.WithArgumentsForConstructor(() => new Board(3, 3)));
            boardFake.SetLivingCell(new Point(0, 1), true);
            boardFake.SetLivingCell(new Point(1, 1), true);
            boardFake.SetLivingCell(new Point(2, 1), true);
            //Act
            bool expectedAlive = boardFake.GetNextLivingCell(new Point(1, 2));

            //Assert
            Assert.Equal(true, expectedAlive);
        }
    }
}