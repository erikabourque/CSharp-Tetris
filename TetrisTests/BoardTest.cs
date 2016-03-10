using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace TetrisTests
{
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
    }
}
