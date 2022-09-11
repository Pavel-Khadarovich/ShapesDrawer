using ShapesDrawer;
using ShapesDrawer.Drawers;
using ShapesDrawer.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Drawers
{
    public class ShapeGraphicsDrawer : IDrawer
    {
        private readonly PointsGetter _pointsGetter;
        private readonly string _fileName;

        public ShapeGraphicsDrawer(
            PointsGetter pointsGetter,
            CmdOptions options)
        {
            _pointsGetter = pointsGetter;
            _fileName = options.FileName;
        }

        public void Draw(Circle circle)
        {
            var width = circle.Radius + Constants.Offset;
            var height = circle.Radius + Constants.Offset;
            var image = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(image);
            using var pen = new Pen(Color.Red);
            using var brush = new SolidBrush(Color.White);
            {
                graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));
            }
            graphics.DrawEllipse(pen, Constants.Offset, Constants.Offset, circle.Radius, circle.Radius);
            SaveToFile(image);
        }

        public void Draw(Rect rect)
        {
            var points = _pointsGetter.ForRect(rect);
            PointByPointDrawer(points);
        }

        public void Draw(Square square)
        {
            var points = _pointsGetter.ForSquare(square);
            PointByPointDrawer(points);
        }

        public void Draw(Triangle triangle)
        {
            var points = _pointsGetter.ForTriangle(triangle);
            PointByPointDrawer(points);
        }

        public void PointByPointDrawer(IList<Point> points)
        {
            var minPointHeight = 0;
            var minPointWidth = 0;
            foreach (var point in points)
            {
                if (point.Y > minPointHeight)
                    minPointHeight = point.Y;
                if (point.X > minPointWidth)
                    minPointWidth = point.X;
            }

            var width = minPointWidth + Constants.Offset;
            var height = minPointHeight + Constants.Offset;

            var image = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(image);
            using var brush = new SolidBrush(Color.White);
            {
                graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));
            }
            using var pen = new Pen(Color.Red);
            for (var i = 0; i <= points.Count - 2; i++)
            {
                graphics.DrawLine(pen, points[i], points[i + 1]);
            }
            if (points.Count > 2)
            {
                graphics.DrawLine(pen, points[points.Count - 1], points[0]);
            }

            SaveToFile(image);
        }

        private void SaveToFile(Image image)
        {
            image.Save(_fileName);
        }
    }
}
