using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System.Drawing;

namespace TetrisTests
{
    // Using same ColorableTestBoard as BlockTest

    [TestClass]
    public class ShapeTTest
    {
        // Things to test
        // Drop: 4 rotations, edgeboard, blocked
        // MoveDown: edgeboard 4 rotations, blocked 4 rotations, valid
        // MoveLeft: edgeboard 4 rotations, blocked 4 rotations, valid
        // MoveRight: edgeboard 4 rotations, blocked 4 rotations, valid
        // Reset: 4 rotations
        // Rotate: 4 rotations, edgeboard, blocked

        [TestMethod]
        public void Constructor_Valid()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test;

            // Act
            test = new ShapeT(testboard);

            // Assert
            Assert.IsInstanceOfType(test, typeof(ShapeT));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_Invalid()
        {
            // Arrange
            ColorableTestBoard testboard = null;
            IShape test;

            // Act
            test = new ShapeT(testboard);
        }

        [TestMethod]
        public void Drop_RotationNone()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(18, 4), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(18, 6), test[2].Position);
            Assert.AreEqual(new Point(19, 5), test[3].Position);
        }

        [TestMethod]
        public void Drop_Rotation1()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(17, 5), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(19, 5), test[2].Position);
            Assert.AreEqual(new Point(18, 4), test[3].Position);
        }

        [TestMethod]
        public void Drop_Rotation2()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(19, 6), test[0].Position);
            Assert.AreEqual(new Point(19, 5), test[1].Position);
            Assert.AreEqual(new Point(19, 4), test[2].Position);
            Assert.AreEqual(new Point(18, 5), test[3].Position);
        }

        [TestMethod]
        public void Drop_Rotation3()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();
            test.Rotate();

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(19, 5), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(17, 5), test[2].Position);
            Assert.AreEqual(new Point(18, 6), test[3].Position);
        }

        [TestMethod]
        public void Drop_Rotation4()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();
            test.Rotate();
            test.Rotate();

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(18, 4), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(18, 6), test[2].Position);
            Assert.AreEqual(new Point(19, 5), test[3].Position);
        }

        [TestMethod]
        public void Drop_Edgeboard()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.Drop();

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(18, 4), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(18, 6), test[2].Position);
            Assert.AreEqual(new Point(19, 5), test[3].Position);
        }

        [TestMethod]
        public void Drop_Blocked()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            testboard[7, 5] = Color.Red;

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(5, 4), test[0].Position);
            Assert.AreEqual(new Point(5, 5), test[1].Position);
            Assert.AreEqual(new Point(5, 6), test[2].Position);
            Assert.AreEqual(new Point(6, 5), test[3].Position);
        }
    }
}
