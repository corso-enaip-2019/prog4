using System;
using System.Collections.Generic;

namespace SurfaceComputation
{
    class Program
    {
        static void Main(string[] args)
        {
	    List<Shape> shapes = new List<Shape> ();

	    shapes.Add(new Square(4));
	    shapes.Add(new Circle(5));

	    foreach (var shape in shapes)
	    {
		Console.WriteLine(string.Concat($"The perimenter and the area of the",
				  $"{shape.ShapeName()} are {shape.Perimeter()}",
						$" and {shape.Surface()}"));
	    }
        }
    }
}
