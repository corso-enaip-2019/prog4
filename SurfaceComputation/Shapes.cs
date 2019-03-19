using System;

namespace SurfaceComputation
{
    abstract class Shape
    {
        public Shape() { }

        public abstract string ShapeName();
        public abstract double Perimeter();
        public abstract double Surface();
    }
}
