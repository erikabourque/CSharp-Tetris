using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System.Drawing;

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

        [TestMethod]
        public void MoveLeft_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            ShapeProxy shape = new ShapeProxy(testboard);
            Point[] newPosition = new Point[4];
            newPosition[0] = new Point((shape[0].Position.X), (shape[0].Position.Y - 1));
            newPosition[1] = new Point((shape[1].Position.X), (shape[1].Position.Y - 1));
            newPosition[2] = new Point((shape[2].Position.X), (shape[2].Position.Y - 1));
            newPosition[3] = new Point((shape[3].Position.X), (shape[3].Position.Y - 1));
            
            // Act
            shape.MoveLeft();

            // Assert
            Assert.AreEqual(newPosition[0], shape[0].Position);
            Assert.AreEqual(newPosition[1], shape[1].Position);
            Assert.AreEqual(newPosition[2], shape[2].Position);
            Assert.AreEqual(newPosition[3], shape[3].Position);
        }

        [TestMethod]
        public void MoveRight_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            ShapeProxy shape = new ShapeProxy(testboard);
            Point[] newPosition = new Point[4];
            newPosition[0] = new Point((shape[0].Position.X), (shape[0].Position.Y + 1));
            newPosition[1] = new Point((shape[1].Position.X), (shape[1].Position.Y + 1));
            newPosition[2] = new Point((shape[2].Position.X), (shape[2].Position.Y + 1));
            newPosition[3] = new Point((shape[3].Position.X), (shape[3].Position.Y + 1));

            // Act
            shape.MoveRight();

            // Assert
            Assert.AreEqual(newPosition[0], shape[0].Position);
            Assert.AreEqual(newPosition[1], shape[1].Position);
            Assert.AreEqual(newPosition[2], shape[2].Position);
            Assert.AreEqual(newPosition[3], shape[3].Position);
        }

        [TestMethod]
        public void MoveDown_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            ShapeProxy shape = new ShapeProxy(testboard);
            Point[] newPosition = new Point[4];
            newPosition[0] = new Point((shape[0].Position.X + 1), (shape[0].Position.Y));
            newPosition[1] = new Point((shape[1].Position.X + 1), (shape[1].Position.Y));
            newPosition[2] = new Point((shape[2].Position.X + 1), (shape[2].Position.Y));
            newPosition[3] = new Point((shape[3].Position.X + 1), (shape[3].Position.Y));

            // Act
            shape.MoveDown();

            // Assert
            Assert.AreEqual(newPosition[0], shape[0].Position);
            Assert.AreEqual(newPosition[1], shape[1].Position);
            Assert.AreEqual(newPosition[2], shape[2].Position);
            Assert.AreEqual(newPosition[3], shape[3].Position);
        }

        [TestMethod]
        public void Reset_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            ShapeProxy shape = new ShapeProxy(testboard);
            Point[] newPosition = new Point[4];
            newPosition[0] = new Point((shape[0].Position.X), (shape[0].Position.Y));
            newPosition[1] = new Point((shape[1].Position.X), (shape[1].Position.Y));
            newPosition[2] = new Point((shape[2].Position.X), (shape[2].Position.Y));
            newPosition[3] = new Point((shape[3].Position.X), (shape[3].Position.Y));
            shape.Drop();

            // Act
            shape.Reset();

            // Assert
            Assert.AreEqual(newPosition[0], shape[0].Position);
            Assert.AreEqual(newPosition[1], shape[1].Position);
            Assert.AreEqual(newPosition[2], shape[2].Position);
            Assert.AreEqual(newPosition[3], shape[3].Position);
        }
    }
}
