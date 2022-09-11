using ShapesDrawer.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawer.Drawers
{
    public class PointsGetter
    {
        private readonly TrianglePointsGetter _trianglePointsGetter;

        public PointsGetter(TrianglePointsGetter trianglePointsGetter)
        {
            _trianglePointsGetter = trianglePointsGetter;
        }

        public IList<Point> ForRect(Rect source)
        {
            return ForRectInternal(source.Length, source.Height);
        }
        

        public IList<Point> ForSquare(Square source)
        {
            return ForRectInternal(source.Length, source.Length);
        }

        public IList<Point> ForTriangle(Triangle source)
        {
            return _trianglePointsGetter.GetPoints(source);
        }

        private IList<Point> ForRectInternal(int length, int height)
        {
            var result = new List<Point>(4);
            var first = new Point(Constants.Offset, Constants.Offset);
            var second = new Point(first.X + length, first.Y);
            var third = new Point(first.X + length, first.Y + height);
            var fourth = new Point(first.X, first.Y + height);

            result.Add(first);
            result.Add(second);
            result.Add(third);
            result.Add(fourth);

            return result;
        }
    }
}
