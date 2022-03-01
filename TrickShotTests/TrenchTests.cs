using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrickShot;

namespace TrickShotTests
{
    [TestClass]
    public class TrenchTests
    {
        [TestClass]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public class Constructor
        {
            private Position _somePositionInstance;

            [TestInitialize]
            public void Setup()
            {
                _somePositionInstance = A.Dummy<Position>();
            }

            [TestMethod]
            public void WhenTopLeftArgumentIsNull_ShouldThrowArgumentNullException()
            {
                //arrange
                Action act = () => new Trench(null, _somePositionInstance);

                //assert
                act.Should().ThrowExactly<ArgumentNullException>()
                    .And.ParamName.Should().Be("topLeft");
            }

            [TestMethod]
            public void WhenBottomRightArgumentIsNull_ShouldThrowArgumentNullException()
            {
                //arrange
                Action act = () => new Trench(_somePositionInstance, null);

                //assert
                act.Should().ThrowExactly<ArgumentNullException>()
                    .And.ParamName.Should().Be("bottomRight");
            }
        }

        [TestClass]
        public class WillBeHit
        {
            [DataTestMethod]
            [DynamicData(nameof(GetMissData), DynamicDataSourceType.Method)]
            public void WhenPositionIsOutsideTrenchBoundingRectangle_ShouldReturnFalse(Position position, Position trenchTopLeft, Position trenchBottomRight)
            {
                //arrange
                var sut = new Trench(trenchTopLeft, trenchBottomRight);
                var positionToCheck = new Position(position.X, position.Y);

                //act
                var actualResult = sut.WillBeHit(positionToCheck);

                //assert
                actualResult.Should().BeFalse();
            }

            [DataTestMethod]
            [DynamicData(nameof(GetHitData), DynamicDataSourceType.Method)]
            public void WhenPositionIsInsideTrenchBoundingRectangle_ShouldReturnTrue(Position position, Position trenchTopLeft, Position trenchBottomRight)
            {
                //arrange
                var sut = new Trench(trenchTopLeft, trenchBottomRight);
                var positionToCheck = new Position(position.X, position.Y);

                //act
                var actualResult = sut.WillBeHit(positionToCheck);

                //assert
                actualResult.Should().BeTrue();
            }

            public static IEnumerable<Position[]> GetMissData()
            {
                yield return new[]
                {
                    new Position(18,-5), new Position(20,-1), new Position(30,-10)
                };

                yield return new[]
                {
                    new Position(20,-15), new Position(20,-1), new Position(30,-10)
                };
            }

            public static IEnumerable<Position[]> GetHitData()
            {
                yield return new[]
                {
                    new Position(22,-5), new Position(20,-1), new Position(30,-10)
                };

                yield return new[]
                {
                    new Position(28,-1), new Position(20,-1), new Position(30,-10)
                };
            }
        }
    }
}
