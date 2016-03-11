using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System.Drawing;

namespace TetrisTests
{
    // Using same ColorableTestBoard as BlockTest

    [TestClass]
    public class ShapeZTest
    {
        [TestMethod]
        public void MoveLeft1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);

            // Act
            test.MoveLeft();
            
            // Assert
            Assert.AreEqual(new Point(0, 3), test[0].Position);
            Assert.AreEqual(new Point(0, 4), test[1].Position);
            Assert.AreEqual(new Point(1, 4), test[2].Position);
            Assert.AreEqual(new Point(1, 5), test[3].Position);
        }

        [TestMethod]
        public void MoveLeftRotated_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.MoveLeft();
            
            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(1, 4), test[1].Position);
            Assert.AreEqual(new Point(1, 3), test[2].Position);
            Assert.AreEqual(new Point(2, 3), test[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            testboard[0, 3] = Color.Red;

            // Act
            test.MoveLeft();
            
            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }

        [TestMethod]
        public void MoveLeftNoSpace2_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            testboard[2, 3] = Color.Red;
            test.MoveDown();
            test.Rotate();

            // Act
            test.MoveLeft();
           
            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 4), test[2].Position);
            Assert.AreEqual(new Point(2, 4), test[3].Position);
        }

        [TestMethod]
        public void MoveRight1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);

            // Act
            test.MoveRight();
            
            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(0, 6), test[1].Position);
            Assert.AreEqual(new Point(1, 6), test[2].Position);
            Assert.AreEqual(new Point(1, 7), test[3].Position);
        }

        [TestMethod]
        public void MoveRight2_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.MoveRight();

            // Assert
            Assert.AreEqual(new Point(0, 6), test[0].Position);
            Assert.AreEqual(new Point(1, 6), test[1].Position);
            Assert.AreEqual(new Point(1, 5), test[2].Position);
            Assert.AreEqual(new Point(2, 5), test[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            testboard[0, 6] = Color.Red;
            
            // Act
            test.MoveRight();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }

        [TestMethod]
        public void MoveRightNoSpace2_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            testboard[0, 6] = Color.Red;
            test.MoveDown();
            test.Rotate();

            // Act
            test.MoveRight();
            
            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 4), test[2].Position);
            Assert.AreEqual(new Point(2, 4), test[3].Position);
        }

        [TestMethod]
        public void MoveDown1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);

            // Act
            test.MoveDown();
            
            // Assert
            Assert.AreEqual(new Point(1, 4), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 5), test[2].Position);
            Assert.AreEqual(new Point(2, 6), test[3].Position);
        }

        [TestMethod]
        public void MoveDown2_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.MoveDown();

            // Assert
            Assert.AreEqual(new Point(1, 5), test[0].Position);
            Assert.AreEqual(new Point(2, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 4), test[2].Position);
            Assert.AreEqual(new Point(3, 4), test[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            testboard[2, 5] = Color.Red;
            
            // Act
            test.MoveDown();
            
            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }

        [TestMethod]
        public void MoveDownNoSpace2_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            testboard[3, 4] = Color.Red;
            test.MoveDown();
            test.Rotate();            

            // Act
            test.MoveDown();

            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 4), test[2].Position);
            Assert.AreEqual(new Point(2, 4), test[3].Position);
        }

        [TestMethod]
        public void Drop1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            
            // Act
            test.Drop();

            // Assert
            Assert.AreEqual(new Point(18, 4), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(19, 5), test[2].Position);
            Assert.AreEqual(new Point(19, 6), test[3].Position);
        }

        [TestMethod]
        public void Drop2_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.Drop();
            
            // Assert
            Assert.AreEqual(new Point(17, 5), test[0].Position);
            Assert.AreEqual(new Point(18, 5), test[1].Position);
            Assert.AreEqual(new Point(18, 4), test[2].Position);
            Assert.AreEqual(new Point(19, 4), test[3].Position);
        }

        [TestMethod]
        public void Rotate1_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            
            // Act
            test.Rotate();
            
            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 4), test[2].Position);
            Assert.AreEqual(new Point(2, 4), test[3].Position);
        }

        [TestMethod]
        public void Rotate2_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();

            // Act
            test.Rotate();
            
            // Assert
            Assert.AreEqual(new Point(1, 4), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 5), test[2].Position);
            Assert.AreEqual(new Point(2, 6), test[3].Position);
        }

        [TestMethod]
        public void Rotate1NoSpace_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            testboard[2, 4] = Color.FromName("Red");
            test.MoveDown();

            // Act
            test.Rotate();
            
            // Assert
            Assert.AreEqual(new Point(1, 4), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(2, 5), test[2].Position);
            Assert.AreEqual(new Point(2, 6), test[3].Position);
        }

        [TestMethod]
        public void Rotate2NoSpace_Test()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();
            testboard[2, 6] = Color.Red;

            // Act
            test.Rotate();
            
            // Assert
            Assert.AreEqual(new Point(0, 5), test[0].Position);
            Assert.AreEqual(new Point(1, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 4), test[2].Position);
            Assert.AreEqual(new Point(2, 4), test[3].Position);
        }

        [TestMethod]
        public void Reset_NoRotation()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.Drop();

            // Act
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }

        [TestMethod]
        public void Reset_Rotation1()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();
            test.Drop();

            // Act
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }

        [TestMethod]
        public void Reset_Rotation2()
        {
            // Arrange
            ColorableTestBoard testboard = new ColorableTestBoard();
            IShape test = new ShapeZ(testboard);
            test.MoveDown();
            test.Rotate();
            test.Rotate();
            test.Drop();

            // Act
            test.Reset();

            // Assert
            Assert.AreEqual(new Point(0, 4), test[0].Position);
            Assert.AreEqual(new Point(0, 5), test[1].Position);
            Assert.AreEqual(new Point(1, 5), test[2].Position);
            Assert.AreEqual(new Point(1, 6), test[3].Position);
        }
    }
}
