using ShapesDrawer.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawer
{
    public class ShapeFactory
    {
        private readonly Dictionary<ShapeType, Func<CmdOptions, IShape>> _factoryMethods = new();
        
        public ShapeFactory()
        {
            _factoryMethods.Add(ShapeType.Circle, (options) => CreateCircle(options));
            _factoryMethods.Add(ShapeType.Rectangle, (options) => CreateRectangle(options));
            _factoryMethods.Add(ShapeType.Square, (options) => CreateSquare(options));
            _factoryMethods.Add(ShapeType.Triangle, (options) => CreateTriangle(options));
        }

        public IShape Create(CmdOptions options)
        {
            return _factoryMethods[options.ShapeType.Value](options);
        }

        private Circle CreateCircle(CmdOptions options)
        {
            return CreateInternal(options, 1, (dims) => new Circle(dims[0]));
        }

        private Triangle CreateTriangle(CmdOptions options)
        {
            return CreateInternal(options, 3, (dims) => new Triangle(dims[0], dims[1], dims[2]));
        }

        private Rect CreateRectangle(CmdOptions options)
        {
            return CreateInternal(options, 2, (dims) => new Rect(dims[0], dims[1]));
        }

        private Square CreateSquare(CmdOptions options)
        {
            return CreateInternal(options, 1, (dims) => new Square(dims[0]));
        }

        private T CreateInternal<T>(CmdOptions options, int dimensionsNumber, Func<int[], T> dimensionsToShapeFunc) where T : IShape
        {
            var items = options.Dimensions
                .Take(dimensionsNumber)
                .ToArray();
            if (items.Length < dimensionsNumber)
                throw new ArgumentException("not valid dimensions count");

            return dimensionsToShapeFunc(items);
        }
    }
}
