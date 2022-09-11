using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesDrawer.Shapes;

namespace ShapesDrawer.Utils
{
    public static class ShapeExtensions
    {
        public static void ValidateDimension(this IShape shape, int dimension)
        {
            if (dimension <= 0 || dimension >= 1000)
                throw new ArgumentException("dimension should be in range (0, 1000)");
        }
    }
}
