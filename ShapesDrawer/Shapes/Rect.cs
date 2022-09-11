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
    public class Rect : IShape
    {
        public int Length { get; }

        public int Height { get; }

        public Rect(int length, int height)
        {
            this.ValidateDimension(length);
            this.ValidateDimension(height);

            if (height <= 0)
                throw new ArgumentException(nameof(height));

            Length = length;
            Height = height;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.Draw(this);
        }
    }
}
