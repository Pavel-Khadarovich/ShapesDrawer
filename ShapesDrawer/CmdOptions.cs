using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using ShapesDrawer.Drawers;
using Microsoft.VisualBasic;
using Constants = ShapesDrawer.Drawers.Constants;

namespace ShapesDrawer
{
    public enum ShapeType
    {
        Circle = 1,
        Rectangle = 2,
        Square = 3,
        Triangle = 4
    }

    public class CmdOptions
    {
        [Option('t', "type", Required = true)]
        public ShapeType? ShapeType { get; set; }

        [Option('d', "dimensions", Required = true)]
        public IEnumerable<int> Dimensions { get; set; }

        [Option('f', "file", Required = false, Default = "result.bmp")]
        public string FileName { get; set; }
    }
}
