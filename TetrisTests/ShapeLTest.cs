using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System.Drawing;

namespace TetrisTests
{

    [TestClass]
    public class ShapeLTest
    {

        Board board;
        Shape shapeL;

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
            shapeL = new ShapeL(board);
        }

        [TestMethod]
        public void MoveLeft1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeL[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 3), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveLeft2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(2, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveLeft3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 3), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveLeft4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 3), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 3] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace2_Test()
        {
            // Arrange
            createBoard();
            board[0, 4] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace3_Test()
        {
            // Arrange
            createBoard();
            board[1, 3] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace4_Test()
        {
            // Arrange
            createBoard();
            board[0, 3] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRight1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 7), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRight2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(2, 6), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 7), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRight3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(1, 7), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 7), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRight4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 6), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 7] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            board[2, 7] = Color.FromName("Red");
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            board[1, 7] = Color.FromName("Red");
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            board[1, 6] = Color.FromName("Red");
            shapeL.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveDown1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveDown2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(3, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(3, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveDown3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(2, 6), shapeL[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveDown4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(3, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[1, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            board[3, 5] = Color.FromName("Red");
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[3].Position);
        }

        public void MoveDownNoSpace3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            board[2, 5] = Color.FromName("Red");
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 7), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 7), shapeL[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            board[3, 5] = Color.FromName("Red");
            shapeL.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void Drop1_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.Drop();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[3].Position);
        }

        [TestMethod]
        public void Drop2_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.Rotate();
            shapeL.Drop();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(3, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void Drop3_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.Drop();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[3].Position);
        }

        [TestMethod]
        public void Drop4_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.Rotate();
            shapeL.Drop();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void Rotate1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void Rotate2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[3].Position);
        }

        public void Rotate3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void Rotate4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            // Assert
            // one more because moved down
            Assert.AreEqual(new Point(1, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void Rotate1NoSpace_Test()
        {
            // Arrange
            createBoard();
            board[0, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeL.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeL[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[3].Position);
        }

        [TestMethod]
        public void Rotate2NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            board[0, 6] = Color.FromName("Red");
            shapeL.Rotate();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void Rotate3NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            board[0, 5] = Color.FromName("Red");
            shapeL.Rotate();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeL[3].Position);
        }

        [TestMethod]
        public void Rotate4NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeL.MoveDown();
            shapeL.Rotate();
            shapeL.Rotate();
            shapeL.Rotate();
            board[1, 4] = Color.FromName("Red");
            shapeL.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeL[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeL[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeL[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeL[3].Position);
        }
    }
}
