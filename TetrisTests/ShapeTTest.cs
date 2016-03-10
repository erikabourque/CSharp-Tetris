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
        public void Drop_BlockedNotRotated()
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

        [TestMethod]
        public void Drop_BlockedRotated()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            testboard[6, 4] = Color.Red;
            test.MoveDown();
            test.Rotate();

            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(4, 5), test[0].Position);
            Assert.AreEqual(new Point(5, 5), test[1].Position);
            Assert.AreEqual(new Point(6, 5), test[2].Position);
            Assert.AreEqual(new Point(5, 4), test[3].Position);
        }

        [TestMethod]
        public void MoveDown_Valid()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);

            // Act
            test.MoveDown();

            // Assert
            Assert.AreEqual(new Point(1, 4), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 6), test[2].Position);
            Assert.AreEqual(new Point(2, 5), test[3].Position);
        }

        [TestMethod]
        public void MoveDown_Edgeboard()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.Drop();

            // Act
            test.MoveDown();

            // Assert
            Assert.AreEqual(new Point(18, 4), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(18, 6), test[2].Position);
            Assert.AreEqual(new Point(19, 5), test[3].Position);
        }

        [TestMethod]
        public void MoveDown_BlockedNotRotated()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            testboard[1, 4] = Color.Red;

            // Act
            test.MoveDown();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void MoveDown_BlockedRotated()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            testboard[2, 4] = Color.Red;

            // Act
            test.MoveDown();

            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 4), test[3].Position);
        }

        [TestMethod]
        public void MoveLeft_Valid()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);

            // Act
            test.MoveLeft();

            // Assert
            Assert.AreEqual(new Point(0, 3), test[0].Position);
            Assert.AreEqual(new Point(0, 4), test[1].Position);
            Assert.AreEqual(new Point(0, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 4), test[3].Position);
        }

        [TestMethod]
        public void MoveLeft_Edgeboard()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveLeft();
            test.MoveLeft();
            test.MoveLeft();
            test.MoveLeft();

            // Act
            test.MoveLeft();

            // Assert
            Assert.AreEqual(new Point(0, 0), test[0].Position);
            Assert.AreEqual(new Point(0, 1), test[1].Position);
            Assert.AreEqual(new Point(0, 2), test[2].Position);
            Assert.AreEqual(new Point(1, 1), test[3].Position);
        }

        [TestMethod]
        public void MoveLeft_BlockedNotRotated()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            testboard[0, 3] = Color.Red;

            // Act
            test.MoveLeft();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void MoveLeft_BlockedRotated()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            testboard[1, 3] = Color.Red;

            // Act
            test.MoveLeft();

            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 4), test[3].Position);
        }

        [TestMethod]
        public void MoveRight_Valid()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);

            // Act
            test.MoveRight();

            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(0, 6), test[1].Position);
            Assert.AreEqual(new Point(0, 7), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }

        [TestMethod]
        public void MoveRight_Edgeboard()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveRight();
            test.MoveRight();
            test.MoveRight();

            // Act
            test.MoveRight();

            // Assert
            Assert.AreEqual(new Point(0, 7), test[0].Position);
            Assert.AreEqual(new Point(0, 8), test[1].Position);
            Assert.AreEqual(new Point(0, 9), test[2].Position);
            Assert.AreEqual(new Point(1, 8), test[3].Position);
        }

        [TestMethod]
        public void MoveRight_BlockedNotRotated()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            testboard[0, 7] = Color.Red;

            // Act
            test.MoveRight();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void MoveRight_BlockedRotated()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            testboard[1, 6] = Color.Red;

            // Act
            test.MoveRight();

            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 4), test[3].Position);
        }

        [TestMethod]
        public void Reset_RotationNone()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);

            // Act
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void Reset_Rotation1()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void Reset_Rotation2()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();

            // Act
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void Reset_Rotation3()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();
            test.Rotate();

            // Act
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void Reset_Rotation4()
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
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void Rotate_ValidRotation1()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();

            // Act
            test.Rotate();

            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 4), test[3].Position);
        }

        [TestMethod]
        public void Rotate_ValidRotation2()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.Rotate();

            // Assert
            Assert.AreEqual(new Point(1, 6), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 4), test[2].Position);
            Assert.AreEqual(new Point(0, 5), test[3].Position);
        }

        [TestMethod]
        public void Rotate_ValidRotation3()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();

            // Act
            test.Rotate();

            // Assert
            Assert.AreEqual(new Point(2, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }

        [TestMethod]
        public void Rotate_ValidRotation4()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();
            test.Rotate();

            // Act
            test.Rotate();

            // Assert
            Assert.AreEqual(new Point(1, 4), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 6), test[2].Position);
            Assert.AreEqual(new Point(2, 5), test[3].Position);
        }

        [TestMethod]
        public void Rotate_InvalidEdgeboard()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);

            // Act
            test.Rotate();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(0, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void Rotate_InvalidBlocked()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeT(testboard);
            test.MoveDown();
            testboard[0, 5] = Color.Red;

            // Act
            test.Rotate();

            // Assert
            Assert.AreEqual(new Point(1, 4), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 6), test[2].Position);
            Assert.AreEqual(new Point(2, 5), test[3].Position);
        }
    }
}
