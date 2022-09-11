using ShapesDrawer.Drawers;
using ShapesDrawer.Shapes;
using ShapesDrawer.Utils;
using System.Drawing;

namespace ShapesDrawer.Tests
{
    public class PointsExtensionsTest
    {
        [Fact]
        public void DistanceIsCorrect()
        {
            // distance should be 50
            var first = new Point(30, 30);
            var second = new Point(60, 70);
            var result = first.CalculateDistance(second);
            Assert.Equal(50, result);
        }
    }
}
