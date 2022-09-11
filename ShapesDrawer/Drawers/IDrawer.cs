using ShapesDrawer.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawer.Drawers
{
    public interface IDrawer
    {
        void Draw(Circle circle);
        void Draw(Rect rect);
        void Draw(Square square);
        void Draw(Triangle triangle);
    }
}
