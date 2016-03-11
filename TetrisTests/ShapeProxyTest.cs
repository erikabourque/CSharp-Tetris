using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace TetrisTests
{
    // Using same ColorableTestBoard as BlockTest

    [TestClass]
    public class ShapeProxyTest
    {
        [TestMethod]
        public void ConstructorTest_Valid()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            ShapeProxy shape;

            // Act
            shape = new ShapeProxy(testboard);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(ShapeProxy));            
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConstructorTest_Invalid()
        {
            // Arrange
            ColorableTestBoard testboard = null;
            ShapeProxy shape;

            // Act
            shape = new ShapeProxy(testboard);
        }
    }
}
