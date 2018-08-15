using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGame;

namespace RotatableShapeTests
{
    [TestClass]
    public class RotatableShapeTests
    {
        [TestMethod]
        public void ShapeRotationShouldBeNinety()
        {
            // Arrange
            var shapeI = new ShapeI(0, 0, ShapeRotation.Zero);

            // Act
            shapeI.Rotate();

            // Assert
            shapeI.Rotation.Should().Be(ShapeRotation.Ninety);
        }

        [TestMethod]
        public void RotationShouldBeZeroAfter270()
        {
            var shapeJ = new ShapeJ(5, 6, ShapeRotation.TwoSeventy);
            shapeJ.Rotate();
            shapeJ.Rotation.Should().Be(ShapeRotation.Zero);
        }

    }
}
