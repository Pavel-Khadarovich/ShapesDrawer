using ShapesDrawer.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawer.Shapes
{
    public interface IShape
    {
        public void Draw(IDrawer drawer);
    }
}
