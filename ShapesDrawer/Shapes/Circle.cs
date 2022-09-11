using ShapesDrawer.Drawers;
using ShapesDrawer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawer.Shapes
{
    public class Circle : IShape
    {
        public int Radius { get; private set; }

        public Circle(int radius)
        {
            this.ValidateDimension(radius);

            Radius = radius;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.Draw(this);
        }
    }
}
