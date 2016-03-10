using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Tetris;

namespace TetrisTests
{
    public class BlockTestBoard : IBoard
    {
        private Color[,] board = new Color[20, 10];

        // Constructor
        public BlockTestBoard()
        {
            // Fill board with black - default no-shape color
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = Color.Black;
                }
            }
        }

        public Color this[int i, int j]
        {
            get
            {
                if ((i > -1) && (i < 20) && (j > -1) && (j < 10))
                {
                    return board[i, j];
                }
                else
                {
                    throw new ArgumentException("Board error. Invalid coordinates for indexer: " + i + ", " + j);
                }
            }
            set
            {
                board[i, j] = value;
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
            if ((rank != 0) && (rank != 1))
            {
                throw new ArgumentException("Board GetLength error.  Rank is invalid number: " + rank);
            }

            return board.GetLength(rank);
        }
    }

    [TestClass]
    public class BlockTest
    {
        [TestMethod]
        public void MoveLeft_Test()
        {
            // Arrange
            Block block = new Block();
            block.Position = new Point(0, 1);
            
            // Act
            block.MoveLeft();
            
            // Assert
            Assert.AreEqual(new Point(0, 0), block.Position);
        }

        [TestMethod]
        public void MoveRight_Test()
        {
            // Arrange
            Block block = new Block();
            block.Position = new Point (0, 0);
            
            // Act
            block.MoveRight();
            
            // Assert
            Assert.AreEqual(new Point(0, 1), block.Position);
        }

        [TestMethod]
        public void MoveDown_Test()
        {
            // Arrange
            Block block = new Block();
            block.Position = new Point(0, 0);
            
            // Act
            block.MoveDown();
            
            // Assert
            Assert.AreEqual(new Point(1, 0), block.Position);
        }

        [TestMethod]
        public void Rotate_Test()
        {
            // Arrange
            Block block = new Block();
            block.Position = new Point(2, 2);
            
            // Act
            block.Rotate(new Point(1, 1));
            
            // Assert
            Assert.AreEqual(new Point(3, 3), block.Position);
        }

        [TestMethod]
        public void TryMoveLeft_Valid()
        {
            // Arrange
            IBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(0, 1), testboard);
            bool result;

            // Act
            result = block.TryMoveLeft();

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TryMoveLeft_InvalidBoardEdge()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(0, 0), testboard);
            bool result;

            // Act
            result = block.TryMoveLeft();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryMoveLeft_InvalidBlocked()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            testboard[0, 0] = Color.Red;
            Block block = new Block(Color.Blue, new Point(0, 1), testboard);
            bool result;

            // Act
            result = block.TryMoveLeft();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryMoveRight_Valid()
        {
            // Arrange
            IBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(0, 0), testboard);
            bool result;

            // Act
            result = block.TryMoveRight();

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TryMoveRight_InvalidBoardEdge()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(0, 9), testboard);
            bool result;

            // Act
            result = block.TryMoveRight();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryMoveRight_InvalidBlocked()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            testboard[0, 1] = Color.Red;
            Block block = new Block(Color.Blue, new Point(0, 0), testboard);
            bool result;

            // Act
            result = block.TryMoveRight();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryMoveDown_Valid()
        {
            // Arrange
            IBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(0, 0), testboard);
            bool result;

            // Act
            result = block.TryMoveDown();

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TryMoveDown_InvalidBoardEdge()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(19, 0), testboard);
            bool result;

            // Act
            result = block.TryMoveDown();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryMoveDown_InvalidBlocked()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            testboard[1, 0] = Color.Red;
            Block block = new Block(Color.Blue, new Point(0, 0), testboard);
            bool result;

            // Act
            result = block.TryMoveDown();

            // Assert
            Assert.AreEqual(false, result);
        }




        [TestMethod]
        public void TryRotate_Valid()
        {
            // Arrange
            IBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(5, 5), testboard);
            Point offset = new Point(1, 1);
            bool result;

            // Act
            result = block.TryRotate(offset);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TryRotate_InvalidBoardEdgeLeft()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(5, 9), testboard);
            Point offset = new Point(1, 1);
            bool result;

            // Act
            result = block.TryRotate(offset);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryRotate_InvalidBoardEdgeRight()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(5, 0), testboard);
            Point offset = new Point(1, -1);
            bool result;

            // Act
            result = block.TryRotate(offset);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryRotate_InvalidBoardEdgeDown()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            Block block = new Block(Color.Blue, new Point(19, 5), testboard);
            Point offset = new Point(1, 1);
            bool result;

            // Act
            result = block.TryRotate(offset);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TryRotate_InvalidBlocked()
        {
            // Arrange
            BlockTestBoard testboard = new BlockTestBoard();
            testboard[6, 6] = Color.Red;
            Block block = new Block(Color.Blue, new Point(5, 5), testboard);
            Point offset = new Point(1, 1);
            bool result;

            // Act
            result = block.TryRotate(offset);

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
