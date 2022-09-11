using ShapesDrawer.Drawers;
using ShapesDrawer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawer.Shapes
{
    public class Triangle : IShape
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Third { get; set; }

        public Triangle(int first, int second, int third)
        {
            this.ValidateDimension(first);
            this.ValidateDimension(second);
            this.ValidateDimension(third);

            First = first;
            Second = second;
            Third = third;

            if (!CheckIfTriangleInequasionSucceed())
                throw new ArgumentException("Triangle inequasion is violated");
        }

        private bool CheckIfTriangleInequasionSucceed()
        {
            var ordered = new List<int>()
            {
                First, Second, Third
            }
            .OrderBy(x => x)
            .ToList();

            return ordered[0] + ordered[1] > ordered[2];
        }

        public void Draw(IDrawer drawer)
        {
            drawer.Draw(this);
        }
    }
}
