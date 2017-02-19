namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class Desktop : Computer
    {
        public Desktop()
        {

        }
        public Desktop(int ID, decimal price, bool isAvailable, Brand brand, string CPU, int DriveMemory, string VideoCardModel, string OperationSystem, double ScreenSize, int RAM, bool HasDVDRecorder)
            : base(ID, price, isAvailable, brand, CPU, DriveMemory, VideoCardModel, OperationSystem, ScreenSize, RAM)
        {
            this.HasDVDRecorder = HasDVDRecorder;
        }

        public bool HasDVDRecorder { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine(string.Format("Has DVD recorder: {0}", this.HasDVDRecorder ? "Yes" : "No"));

            return output.ToString();
        }
    }
}
