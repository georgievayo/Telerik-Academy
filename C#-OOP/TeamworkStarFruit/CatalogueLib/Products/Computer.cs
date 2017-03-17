namespace CatalogueLib
{
    using System.Text;
    using CatalogueLib.Products.Enumerations;

    public abstract class Computer : Product
    {
        public Computer()
        {

        }
        public Computer(int ID, decimal price, bool isAvailable, Brand brand, string CPU, int DriveMemory, string VideoCardModel, string OperationSystem, double ScreenSize, int RAM)
            : base(ID, price, isAvailable, brand)
        {
            this.CPU = CPU;
            this.DriveMemory = DriveMemory;
            this.VideoCardModel = VideoCardModel;
            this.OperationSystem = OperationSystem;
            this.ScreenSize = ScreenSize;
            this.RAM = RAM;
        }

        public string CPU { get; private set; }

        //in megabytes
        public int DriveMemory { get; private set; }

        public string VideoCardModel { get; private set; }

        public string OperationSystem { get; private set; }

        //in inches
        public double ScreenSize { get; private set; }

        //in gigs
        public int RAM { get; private set; }

        public override string ToString()
        {

            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"CPU: {this.CPU} GHz");
            output.AppendLine($"Drive Memory: {this.DriveMemory} GB");
            output.AppendLine($"Video Card: {this.VideoCardModel}");
            output.AppendLine($"Operation System: {this.OperationSystem}");
            output.AppendLine($"Screen size: {this.ScreenSize}\"");
            output.AppendLine($"RAM: {this.RAM} GB");

            return output.ToString();
        }

    }
}
