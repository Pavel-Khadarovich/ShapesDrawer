// See https://aka.ms/new-console-template for more information
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp1.Drawers;
using ShapesDrawer.Drawers;
using System.Drawing;
using ShapesDrawer.Shapes;
using System;

namespace ShapesDrawer;

internal class Program
{
    static void Main(string[] args)
    {
        var parser = new Parser(cfg => cfg.CaseInsensitiveEnumValues = true);
        parser.ParseArguments<CmdOptions>(args)
            .WithParsed(options =>
            {
                if (!options.ShapeType.HasValue)
                {
                    Console.WriteLine("shape type is not supported");
                    Console.ReadLine();
                    return;
                }
                if (!string.Equals(Path.GetExtension(options.FileName), ".bmp", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("only .bmp files are supported");
                    Console.ReadLine();
                    return;
                }

                var services = new ServiceCollection();
                ConfigureServices(services, options);
                var serviceProvider = services.BuildServiceProvider();

                var shapeFactory = serviceProvider.GetRequiredService<ShapeFactory>();
                IShape shape;
                try
                {
                    shape = shapeFactory.Create(options);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    return;
                }
                var drawer = serviceProvider.GetRequiredService<ShapeGraphicsDrawer>();
                shape.Draw(drawer);
            })
            .WithNotParsed((errors) =>
            {
                Console.WriteLine("unable to parse input");
                Console.ReadLine();
            });
    }

    static void ConfigureServices(IServiceCollection services, CmdOptions options)
    {
        services
            .AddSingleton<ShapeFactory>()
            .AddSingleton<ShapeGraphicsDrawer>()
            .AddSingleton<PointsGetter>()
            .AddSingleton<TrianglePointsGetter>()
            .AddSingleton(options);
    }
}