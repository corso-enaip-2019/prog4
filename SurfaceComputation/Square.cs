using System;

namespace SurfaceComputation
{
    class Square : Shape
    {
        public Square(double side)
        {
            Side = side;
        }

        private double Side { get; }

	public override string ShapeName()
	{
	    return "square";
	}

        public override double Perimeter()
        {

            return 4 * Side;
        }

        public override double Surface()
        {
            return Math.Pow(Side, Side);
        }
    }
}
