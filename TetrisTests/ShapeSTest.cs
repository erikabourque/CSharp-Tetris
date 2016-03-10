using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System.Drawing;

namespace TetrisTests
{

    [TestClass]
    public class ShapeSTest
    {
        Board board;
        Shape shapeS;

        public void createBoard()
        {
            board = new Board();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = Color.FromName("Black");
                }
            }
        }

        public void createShape()
        {
            shapeS = new ShapeS(board);
        }

        [TestMethod]
        public void MoveLeft1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(1, 3), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveLeft2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            shapeS.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(1, 4), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 4] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace2_Test()
        {
            // Arrange
            createBoard();
            board[0, 4] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            shapeS.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveRight1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 6), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 7), shapeS[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveRight2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            shapeS.MoveRight();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 7), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 7), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 7] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace2_Test()
        {
            // Arrange
            createBoard();
            board[1, 7] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            shapeS.MoveRight();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveDown1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeS[2].Position);
            Assert.AreEqual(new Point(2, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveDown2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            shapeS.MoveDown();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(3, 6), shapeS[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[2, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            board[2, 5] = Color.FromName("Red");
            shapeS.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[3].Position);
        }

        [TestMethod]
        public void Drop1_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.Drop();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeS[2].Position);
            Assert.AreEqual(new Point(2, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void Drop2_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.Rotate();
            shapeS.Drop();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(3, 6), shapeS[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeS[3].Position);
        }

        [TestMethod]
        public void Rotate1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[3].Position);
        }

        [TestMethod]
        public void Rotate2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.Rotate();
            shapeS.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void Rotate1NoSpace_Test()
        {
            // Arrange
            createBoard();
            board[2, 6] = Color.FromName("Red");
            createShape();
            // Act
            shapeS.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeS[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeS[3].Position);
        }

        [TestMethod]
        public void Rotate2NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeS.MoveDown();
            shapeS.Rotate();
            board[0, 6] = Color.FromName("Red");
            shapeS.Rotate();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeS[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeS[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeS[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeS[3].Position);
        }
    }
}
