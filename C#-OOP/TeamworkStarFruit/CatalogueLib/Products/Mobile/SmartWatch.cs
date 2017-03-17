namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using CatalogueLib.Products.Struct;
    using System.Text;

    public class SmartWatch : Mobile
    {
        public SmartWatch()
        {

        }

        public SmartWatch(int ID, decimal price, bool isAvailable, Brand brand, int Memory, string CPU, int RAM, string Model, string battery, string connectivity, bool ExpandableMemory, double ScreenSize, double Size, bool WaterResistance)
            : base(ID, price, isAvailable, brand, Memory, CPU, RAM, Model, battery, connectivity, ExpandableMemory, ScreenSize)
        {
            this.Size = Size;
            this.WaterResistance = WaterResistance;
        }

        public double Size { get; private set; }

        public bool WaterResistance { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Size: {this.Size}");
            output.AppendLine($"Water resistance: {this.WaterResistance}");

            return output.ToString();
        }
    }
}
