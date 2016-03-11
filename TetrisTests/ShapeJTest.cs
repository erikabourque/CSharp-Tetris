using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System.Drawing;

namespace TetrisTests
{
    [TestClass]
    public class shapeJTest
    {

        Board board;
        Shape shapeJ;

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
            shapeJ = new ShapeJ(board);
        }

        [TestMethod]
        public void MoveLeft1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 3), shapeJ[0].Position);
            Assert.AreEqual(new Point(0, 4), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveLeft2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(2, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveLeft3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 3), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 3), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveLeft4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 3), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 3] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace2_Test()
        {
            // Arrange
            createBoard();
            board[0, 4] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace3_Test()
        {
            // Arrange
            createBoard();
            board[1, 3] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            board[0, 4] = Color.FromName("Red");
            shapeJ.MoveLeft();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRight1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 7), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 7), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRight2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(2, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 7), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRight3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(1, 7), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRight4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[0, 7] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            board[0, 7] = Color.FromName("Red");
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            board[1, 7] = Color.FromName("Red");
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            board[1, 6] = Color.FromName("Red");
            shapeJ.MoveRight();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveDown1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveDown2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(3, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveDown3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(2, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveDown4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(3, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(3, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace1_Test()
        {
            // Arrange
            createBoard();
            board[1, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            board[3, 5] = Color.FromName("Red");
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[3].Position);
        }

        public void MoveDownNoSpace3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            board[2, 5] = Color.FromName("Red");
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(1, 7), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            board[3, 5] = Color.FromName("Red");
            shapeJ.MoveDown();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void Drop1_Test()
        {
            // Arrange
            createBoard();
            board[3, 6] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.Drop();
            // Assert
            Assert.AreEqual(new Point(1, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void Drop2_Test()
        {
            // Arrange
            createBoard();
            board[4, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Drop();
            // Assert
            Assert.AreEqual(new Point(3, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void Drop3_Test()
        {
            // Arrange
            createBoard();
            board[3, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Drop();
            // Assert
            Assert.AreEqual(new Point(2, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void Drop4_Test()
        {
            // Arrange
            createBoard();
            board[4, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Drop();
            // Assert
            Assert.AreEqual(new Point(1, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(3, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(3, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void Rotate1_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void Rotate2_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeJ[3].Position);
        }

        public void Rotate3_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void Rotate4_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            // Assert
            // one more because moved down
            Assert.AreEqual(new Point(1, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void Rotate1NoSpace_Test()
        {
            // Arrange
            createBoard();
            board[0, 5] = Color.FromName("Red");
            createShape();
            // Act
            shapeJ.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 4), shapeJ[0].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[2].Position);
            Assert.AreEqual(new Point(1, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void Rotate2NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            board[0, 4] = Color.FromName("Red");
            shapeJ.Rotate();
            // Assert
            Assert.AreEqual(new Point(2, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(0, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 6), shapeJ[3].Position);
        }

        [TestMethod]
        public void Rotate3NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            board[2, 4] = Color.FromName("Red");
            shapeJ.Rotate();
            // Assert
            Assert.AreEqual(new Point(1, 6), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(1, 4), shapeJ[2].Position);
            Assert.AreEqual(new Point(0, 4), shapeJ[3].Position);
        }

        [TestMethod]
        public void Rotate4NoSpace_Test()
        {
            // Arrange
            createBoard();
            createShape();
            // Act
            shapeJ.MoveDown();
            shapeJ.Rotate();
            shapeJ.Rotate();
            shapeJ.Rotate();
            board[1, 4] = Color.FromName("Red");
            shapeJ.Rotate();
            // Assert
            Assert.AreEqual(new Point(0, 5), shapeJ[0].Position);
            Assert.AreEqual(new Point(1, 5), shapeJ[1].Position);
            Assert.AreEqual(new Point(2, 5), shapeJ[2].Position);
            Assert.AreEqual(new Point(2, 4), shapeJ[3].Position);
        }
    }
}
