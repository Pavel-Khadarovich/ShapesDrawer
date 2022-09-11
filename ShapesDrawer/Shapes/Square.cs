using ShapesDrawer.Drawers;
using ShapesDrawer.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawer.Shapes
{
    public class Square : IShape
    {
        public int Length { get; private set; }

        public Square(int length)
        {
            this.ValidateDimension(length);

            Length = length;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.Draw(this);
        }
    }
}
