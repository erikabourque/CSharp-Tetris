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
        Block block = new Block();

        [TestMethod]
        public void MoveLeft_Test()
        {
            // Arrange
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
            block.Position = new Point(1, 5);
            // Act
            block.Rotate(new Point(-1, -1));
            // Assert
            Assert.AreEqual(new Point(0, 4), block.Position);
        }
    }
}
