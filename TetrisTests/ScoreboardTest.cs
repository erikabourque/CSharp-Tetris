using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace TetrisTests
{
    // TestBoard for Scoreboard
    public class TestBoard : IBoard
    {
        public System.Drawing.Color this[int i, int j]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IShape Shape
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event GameOverHandler GameOver;
        public event LinesClearedHandler LinesCleared;

        public int GetLength(int rank)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        public void Constructor_Valid()
        {
            // Arrange
            Scoreboard test;
            IBoard board = new TestBoard();

            // Act
            test = new Scoreboard(board);

            // Assert
            Assert.IsInstanceOfType(test, typeof(Scoreboard));
        }
    }
}
