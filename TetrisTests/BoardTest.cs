using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace TetrisTests
{
    public class TestEventObserver
    {
        private Board board;
        public bool gameIsOver = false;

        public bool GameOver
        {
            get { return gameIsOver; }
        }

        public TestEventObserver(Board board)
        {
            this.board = board;
            board.GameOver += onGameOver;
        }
        public void onGameOver()
        {
            gameIsOver = true;
        }
    }

    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void Constructor_Valid()
        {
            // Arrange
            IBoard test;

            // Act
            test = new Board();

            // Assert
            Assert.IsInstanceOfType(test, typeof(IBoard));
        }

        [TestMethod]
        public void Constructor_ValidShape()
        {
            // Arrange
            Board test;
            IShape shape;

            // Act
            test = new Board();
            shape = test.Shape;

            // Assert
            Assert.IsInstanceOfType(shape, typeof(IShape));
        }

        [TestMethod]
        public void GetLength_ValidRank0()
        {
            // Arrange
            IBoard test = new Board();
            int length;

            // Act
            length = test.GetLength(0);

            // Assert
            Assert.AreEqual(20, length);
        }

        [TestMethod]
        public void GetLength_ValidRank1()
        {
            // Arrange
            IBoard test = new Board();
            int length;

            // Act
            length = test.GetLength(1);

            // Assert
            Assert.AreEqual(10, length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetLength_Invalid()
        {
            // Arrange
            IBoard test = new Board();
            int length;

            // Act
            length = test.GetLength(2);
        }

        /*
        [TestMethod]
        public void GameOverEvent_Valid()
        {
            // Arrange
            Board test = new Board();
            TestEventObserver obs = new TestEventObserver(test);

            // Act
            for (int i = 0; i < 20; i++)
            {
                test.Shape.Drop();
            }

            // Assert
            Assert.AreEqual(true, obs.gameIsOver);
        } */
    }
}
