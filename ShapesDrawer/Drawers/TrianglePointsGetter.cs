using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ShapesDrawer.Shapes;
using System.Reflection.Metadata.Ecma335;
using System.Collections;

namespace ShapesDrawer.Drawers
{
    public class TrianglePointsGetter
    {
        public IList<Point> GetPoints(Triangle source)
        {
            var first = new Point(Constants.Offset, Constants.Offset);
            var second = new Point(first.X + source.First, first.Y);
            var third = GetThirdPointFromFirst(first, source);
            var points = new List<Point>(3)
            {
                first, second, third
            };
            var result = Normalize(points);

            return result;
        }

        private Point GetThirdPointFromFirst(Point point, Triangle source)
        {
            var cos = GetCos(source.Second, source.First, source.Third);
            var sin = GetSinByCos(cos);
            var x = point.X + (int)Math.Round(source.Third * cos);
            var y = point.Y + (int)Math.Round(source.Third * sin);

            return new Point(x, y);
        }

        private double GetCos(int side, int otherFirst, int otherSecond)
        {
            var nominator = otherFirst * otherFirst + otherSecond * otherSecond - side * side;
            var demoninator = 2 * otherFirst * otherSecond;
            return (double) nominator / demoninator;
        }

        private double GetSinByCos(double value)
        {
            return Math.Sqrt(1 - value * value);
        }

        /// <summary>
        /// if coordinates are less then 0, move them to be visible
        /// </summary>
        /// <param name="source"></param>
        private IList<Point> Normalize(IList<Point> source)
        {
            var minX = 0;
            var minY = 0;
            foreach (var point in source)
            {
                if (point.X < minX)
                    minX = point.X;
                if (point.Y < minY)
                    minY = point.Y;
            }

            if (minX >= 0 && minY >= 0)
                return source;

            var result = new List<Point>(3);
            if (minX < 0 || minY < 0)
            {
                var xOffset = Math.Abs(minX) + Constants.Offset;
                var yOffset = Math.Abs(minY) + Constants.Offset;
                foreach (var point in source)
                {
                    result.Add(new Point(point.X + xOffset, point.Y + yOffset));
                }
            }

            return result;
        }
    }
}
