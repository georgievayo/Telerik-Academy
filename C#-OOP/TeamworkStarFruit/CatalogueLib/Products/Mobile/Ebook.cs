namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using CatalogueLib.Products.Struct;
    using System.Text;

    public class EBook : Mobile
    {
        public EBook()
        {

        }

        public EBook(int ID, decimal price, bool isAvailable, Brand brand, int Memory, string CPU, int RAM, string Model, string battery, string connectivity, bool ExpandableMemory, double ScreenSize, string SupportedFileFormat)
            : base(ID, price, isAvailable, brand, Memory, CPU, RAM, Model, battery, connectivity, ExpandableMemory, ScreenSize)

        {
            this.SupportedFileFormats = SupportedFileFormats;
        }

        public string SupportedFileFormats { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Supported file formats: {this.SupportedFileFormats}");

            return output.ToString();
        }
    }
}
