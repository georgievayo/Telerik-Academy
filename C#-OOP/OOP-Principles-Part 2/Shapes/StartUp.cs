using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2.55, 5.22);
            Square square = new Square(5.69);
            Triangle triangle = new Triangle(3.14, 5.88);
            Console.WriteLine(@"Rectangle's surface is: {0}
Triangle's surface is: {1}
Square's surface is: {2}", rectangle.CalculateSurface(), triangle.CalculateSurface(), square.CalculateSurface());
        }
    }
}
