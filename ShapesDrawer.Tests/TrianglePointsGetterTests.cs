using ShapesDrawer.Drawers;
using ShapesDrawer.Shapes;
using ShapesDrawer.Utils;

namespace ShapesDrawer.Tests
{
    public class TrianglePointsGetterTests
    {
        [Fact]
        public void PointsReturnedCorrect()
        {
            var source = new Triangle(3, 4, 5);
            var ptsGetter = new TrianglePointsGetter();
            var result = ptsGetter.GetPoints(source);

            Assert.Equal(3, result.Count);

            var firstSideLength = Math.Round(result[0].CalculateDistance(result[1]));
            Assert.Equal(source.First, firstSideLength);

            var secondSideLength = Math.Round(result[1].CalculateDistance(result[2]));
            Assert.Equal(secondSideLength, source.Second);

            var thirdSideLength = Math.Round(result[2].CalculateDistance(result[0]));
            Assert.Equal(thirdSideLength, source.Third);
        }

        [Fact]
        public void PointsAreShiftedIfCoordinateOutOfView()
        {
            // by default, such a triangle would have it's last coordinate as negative number
            var source = new Triangle(80, 170, 100);
            var ptsGetter = new TrianglePointsGetter();
            var result = ptsGetter.GetPoints(source);

            var pointHasCoordinateLessThanMinimum = result.Any(point => point.X < Constants.Offset && point.Y < Constants.Offset);
            Assert.False(pointHasCoordinateLessThanMinimum);
        }
    }
}