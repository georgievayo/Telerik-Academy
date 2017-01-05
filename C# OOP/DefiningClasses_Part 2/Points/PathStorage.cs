using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Points
{
    public static class PathStorage
    {
        public static Path Load(string fileName)
        {
            Path path= new Path();
            IEnumerable<string> text = File.ReadLines(fileName);
            foreach (var line in text)
            {
                string[] splittedLine = line.Split(',');
                path.Add(new Point3D(double.Parse(splittedLine[0]), double.Parse(splittedLine[1]), double.Parse(splittedLine[2])));
            }
            return path;
        }

        public static void Save(Path path, string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
           
            List<Point3D> points = path.Points;
            for (int i = 0; i < points.Count; i++)
            {
                file.WriteLine(points[i]);
            }

            file.Close();
        }
    }
}
