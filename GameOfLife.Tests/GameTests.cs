using GameOfLife.Core.Interfaces;
using GameOfLife.Core.Model;
using Xunit;
using System.Runtime;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Fact]
        public void GetNextBoard_GamePlay_ShouldreturnCorrectBoard()
        {
            //Arrange
            Board oldBoard = new Board(3, 3);
            oldBoard.SetLivingCell(new Point(0, 1), true);
            oldBoard.SetLivingCell(new Point(1, 1), true);
            oldBoard.SetLivingCell(new Point(2, 1), true);

            Board newBoard = new Board(3, 3);
            newBoard.SetLivingCell(new Point(1, 0), true);
            newBoard.SetLivingCell(new Point(1, 1), true);
            newBoard.SetLivingCell(new Point(1, 2), true);

            //Act
            Game game = new Game();
            IBoard nextBoard = game.GetOutsideBoard(oldBoard);

            //Assert
            Assert.Equal(newBoard.Compare(nextBoard), true);
        }
    }
}