using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System.Drawing;

namespace TetrisTests
{
    public class TestEventBoardObserver
    {
        private IBoard board;
        public bool gameIsOver = false;
        public bool linesCleared = false;

        public bool GameOver
        {
            get { return gameIsOver; }
        }

        public bool LinesCleared
        {
            get { return linesCleared; }
        }

        public TestEventBoardObserver(IBoard board)
        {
            this.board = board;
            board.GameOver += onGameOver;
            board.LinesCleared += onLinesCleared;
        }
        public void onGameOver()
        {
            gameIsOver = true;
        }
        public void onLinesCleared(int num)
        {
            linesCleared = true;
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

        [TestMethod]
        public void AddsToPile_Test()
        {
            // Arrange
            IBoard test = new Board();
            bool isEmpty = true;

            // Act
            test.Shape.Drop();
            
            for (int i = 0; i < test.GetLength(1); i++)
            {
                if (test[19, i] != Color.Black)
                {
                    isEmpty = false;
                }
            }

            // Assert
            Assert.AreEqual(false, isEmpty);
        }

        [TestMethod]
        public void GameOverEvent_Valid()
        {
            // Arrange
            Board test = new Board();
            TestEventBoardObserver obs = new TestEventBoardObserver(test);

            // Act
            for (int i = 0; i < 20; i++)
            {
                test.Shape.Drop();
            }

            // Assert
            Assert.AreEqual(true, obs.gameIsOver);
        }
    }
}
