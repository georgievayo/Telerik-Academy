namespace CatalogueLib
{
    using CatalogueLib.Products.Enumerations;
    using CatalogueLib.Products.Struct;
    using System.Text;

    public abstract class Mobile : Product
    {
        public Mobile()
        {

        }

        public Mobile(int ID, decimal price, bool isAvailable, Brand brand, int Memory, string CPU, int RAM, string Model, string battery, string connectivity, bool ExpandableMemory, double ScreenSize)
            : base(ID, price, isAvailable, brand)
        {
            this.Memory = Memory;
            this.CPU = CPU;
            this.RAM = RAM;
            this.Model = Model;
            this.battery = battery;
            this.Connectivity = Connectivity;
            this.ExpandableMemory = ExpandableMemory;
            this.ScreenSize = ScreenSize;
        }

        public int Memory { get; private set; }

        public string CPU { get; private set; }

        public int RAM { get; private set; }

        public string Model { get; private set; }

        public string battery { get; private set; }

        public string Connectivity { get; private set; }

        public bool ExpandableMemory { get; private set; }

        public double ScreenSize { get; private set; }

       public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Model: {this.Model}");
            output.AppendLine($"Screen size: {this.ScreenSize}\"");
            output.AppendLine($"Memory: {this.Memory} GB");
            output.AppendLine($"CPU: {this.CPU} GHz");
            output.AppendLine($"RAM: {this.RAM} GB");
            output.AppendLine($"Expandable memory: {this.Memory} GB");
            output.AppendLine($"Battery: {this.battery}");

            return output.ToString();
        }

    }
}

