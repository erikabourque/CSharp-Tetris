using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Tetris;

namespace TetrisTests
{
    [TestClass]
    public class ShapeITest
    {
        Board board;
        Shape shapeI;

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
            shapeI = new ShapeI(board);
        }

        [TestMethod]
        public void MoveLeft1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 2), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 3), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 4), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveLeft2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeI[2].Position);
            Assert.AreEqual(new Point(3, 4), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 2] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace2_Test()
        {
            // Arrange
            createBoard();
            board[0, 4] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(3, 5), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveRight1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 7), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveRight2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 6), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeI[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeI[2].Position);
            Assert.AreEqual(new Point(3, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 7] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace2_Test()
        {
            // Arrange
            createBoard();
            board[0, 6] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(3, 5), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveDown1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 3), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveDown2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeI[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(3, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(4, 5), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[1, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace2_Test()
        {
            // Arrange
            createBoard();
            board[5, 4] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(3, 5), shapeI[3].Position);
        }

        [TestMethod]
        public void Drop1_Test()
        {
            // Arrange
            createBoard();
            board[1, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.Drop();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void Drop2_Test()
        {
            // Arrange
            createBoard();
            board[0, 6] = Color.FromName("Red");
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.Drop();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(3, 5), shapeI[3].Position);
        }

        [TestMethod]
        public void Rotate1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.MoveDown();
            shapeI.Rotate();
            // Assert
            Assert.AreEqual(new Point(3, 5), shapeI[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[3].Position);
        }

        [TestMethod]
        public void Rotate2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void Rotate1NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeI[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeI[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeI[3].Position);
        }

        [TestMethod]
        public void Rotate2NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeI.Rotate();
            shapeI.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeI[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeI[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeI[2].Position);
            Assert.AreEqual(new Point(3, 5), shapeI[3].Position);
        }
    }
}
