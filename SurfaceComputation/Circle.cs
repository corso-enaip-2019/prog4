using System;

namespace SurfaceComputation
{
    class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        private double Radius { get; }

	public override string ShapeName()
	{
	    return "circle";
	}

        public override double Perimeter()
        {
            return Math.PI * Radius;
        }

        public override double Surface()
        {
            return Math.PI * Math.Pow(Radius, Radius);
        }

        public double Circumference()
        {
            return Perimeter();
        }
    }
}
