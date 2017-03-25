using System;

namespace Abstraction
{
    abstract class Figure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        protected bool IsValid(double size, string message)
        {
            if(size > 0)
            {
                return true;
            }
            else
            {
                throw new ArgumentException(message);
            }
        }
    }
}
