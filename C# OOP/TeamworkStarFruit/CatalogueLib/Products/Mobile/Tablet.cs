namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using CatalogueLib.Products.Struct;
    using System.Text;

    public class Tablet : Mobile
    {
        public Tablet()
        {

        }

        public Tablet(int ID, decimal price, bool isAvailable, Brand brand, int Memory, string CPU, int RAM, string Model, string battery, string connectivity, bool ExpandableMemory, double ScreenSize, double FrontCamera, double BackCamera, bool HasGPS)
            : base(ID, price, isAvailable, brand, Memory, CPU, RAM, Model, battery, connectivity, ExpandableMemory, ScreenSize)
        {
            this.FrontCamera = FrontCamera;
            this.BackCamera = BackCamera;
            this.HasGPS = HasGPS;
        }

        public double FrontCamera { get; private set; }

        public double BackCamera { get; private set; }

        public bool HasGPS { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Front camera: {this.FrontCamera} MP");
            output.AppendLine($"Back camera: {this.BackCamera} MP");
            output.AppendLine(string.Format("Has GPS: {0}", this.HasGPS ? "Yes" : "No"));

            return output.ToString();
        }
    }
}