using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Tetris;

namespace TetrisTests
{

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
            Block block = new Block();
            block.Position = new Point(0, 1);
            bool result;

            // Act
            result = block.TryMoveLeft();

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
