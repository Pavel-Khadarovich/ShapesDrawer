using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ShapesDrawer.Shapes;
using ShapesDrawer.Drawers;
using Constants = ShapesDrawer.Drawers.Constants;

namespace ShapesDrawer.Utils
{
    public static class ShapeExtensions
    {
        public static void ValidateDimension(this IShape shape, int dimension)
        {
            if (dimension <= 0 || dimension >= Constants.MaxDimensionSize)
                throw new ArgumentException($"dimension should be in range (0, {Constants.MaxDimensionSize})");
        }
    }
}
