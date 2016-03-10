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

        public void OnLinesCleared(int numLines)
        {
            if (LinesCleared != null)
            {
                LinesCleared(numLines);
            }
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

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_Null()
        {
            // Arrange
            Scoreboard test;
            IBoard board = null;

            // Act
            test = new Scoreboard(board);
        }

        [TestMethod]
        public void incrementLinesCleared_validNum_ScoreNoBonus()
        {
            // Arrange
            int numLines = 2;
            TestBoard board = new TestBoard();
            Scoreboard test = new Scoreboard(board);

            // Act
            board.OnLinesCleared(numLines);
            int score = test.Score;

            // Assert
            Assert.AreEqual(200, score);
        }

        [TestMethod]
        public void incrementLinesCleared_validNum_ScoreBonus()
        {
            // Arrange
            int numLines = 4;
            TestBoard board = new TestBoard();
            Scoreboard test = new Scoreboard(board);

            // Act
            board.OnLinesCleared(numLines);
            int score = test.Score;

            // Assert
            Assert.AreEqual(800, score);
        }

        [TestMethod]
        public void incrementLinesCleared_validNum_Lines()
        {
            // Arrange
            int numLines = 2;
            TestBoard board = new TestBoard();
            Scoreboard test = new Scoreboard(board);

            // Act
            board.OnLinesCleared(numLines);
            int lines = test.Lines;

            // Assert
            Assert.AreEqual(numLines, lines);
        }

        [TestMethod]
        public void incrementLinesCleared_validNum_Level()
        {
            // Arrange
            int numLines = 2;
            TestBoard board = new TestBoard();
            Scoreboard test = new Scoreboard(board);

            // Act
            board.OnLinesCleared(numLines);
            int level = test.Level;

            // Assert
            Assert.AreEqual(0, level);
        }

        [TestMethod]
        public void incrementLinesCleared_validNum_LevelIncrease()
        {
            // Arrange
            int numLines = 4;
            TestBoard board = new TestBoard();
            Scoreboard test = new Scoreboard(board);

            // Act
            board.OnLinesCleared(numLines);
            board.OnLinesCleared(numLines);
            board.OnLinesCleared(numLines);
            int level = test.Level;

            // Assert
            Assert.AreEqual(1, level);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void incrementLinesCleared_LowerInvalidNum()
        {
            // Arrange
            int numLines = 0;
            TestBoard board = new TestBoard();
            Scoreboard test = new Scoreboard(board);

            // Act
            board.OnLinesCleared(numLines);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void incrementLinesCleared_HigherInvalidNum()
        {
            // Arrange
            int numLines = 5;
            TestBoard board = new TestBoard();
            Scoreboard test = new Scoreboard(board);

            // Act
            board.OnLinesCleared(numLines);
        }
    }
}
