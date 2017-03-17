using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class PointsTest
    {
        static void Main(string[] args)
        {
            Point3D firstPoint = new Point3D(2, 8, 1);
            Point3D secondPoint = new Point3D(5, 7, 8);
            double distance = Calculator.CalculateDistance(firstPoint, secondPoint);
            Console.WriteLine("Distance between point {0} and {1} is: {2}", firstPoint, secondPoint, distance);

            Path path = new Path();
            path = PathStorage.Load("./loadPath.txt");

            foreach (var point in path.Points)
            {
                Console.WriteLine(point);
            }

            PathStorage.Save(path, "./savePath.txt");
        }
    }
}
