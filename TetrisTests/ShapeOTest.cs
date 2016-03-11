using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Tetris;

namespace TetrisTests
{
    // Test methods for O Shape
    [TestClass]
    public class ShapeOTest
    {
        Board board;
        Shape shapeO;

        public void createBoard()
        {
            board = new Board();
            for (int i = 0; i < 20; i ++)
            {
                for(int j = 0; j < 10; j ++)
                {
                    board[i, j] = Color.FromName("Black");
                }
            }
        }

        public void createShape()
        {
            shapeO = new ShapeO(board);
        }

        [TestMethod]
        public void MoveLeftSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeO.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeO[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeO[1].Position);
            Assert.AreEqual(new Point(1, 3), shapeO[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeO[3].Position);
        }

        [TestMethod]
        public void MoveRightSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeO.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeO[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeO[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeO[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeO[3].Position);
        }

        [TestMethod]
        public void MoveDownSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeO.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 4), shapeO[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeO[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeO[2].Position);
            Assert.AreEqual(new Point(2, 5), shapeO[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace_Test()
        {
            // Arrange
            createBoard();
            board[1, 3] = Color.FromName("Red");
            createShape();
            // Act
            shapeO.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeO[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeO[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeO[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeO[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace_Test()
        {
            // Arrange
            createBoard();
            board[1, 6] = Color.FromName("Red");
            createShape();
            // Act
            shapeO.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeO[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeO[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeO[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeO[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace_Test()
        {
            // Arrange
            createBoard();
            board[2, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeO.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeO[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeO[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeO[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeO[3].Position);
        }

        [TestMethod]
        public void Drop_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeO.Drop();
            // Assert
            Assert.AreEqual(new Point(2, 3), shapeO[0].Position);
            Assert.AreEqual(new Point(2, 4), shapeO[1].Position);
            Assert.AreEqual(new Point(3, 3), shapeO[2].Position);
            Assert.AreEqual(new Point(3, 4), shapeO[3].Position);
        }
    }
}
