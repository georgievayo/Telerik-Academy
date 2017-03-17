namespace CatalogueLib
{
    using System.Text;
    using CatalogueLib.Products.Enumerations;

    public abstract class BigAppliances : Product
    {
        public BigAppliances()
        {

        }

        public BigAppliances(int ID, decimal price, bool isAvailable, Brand brand, string Color, string CountryOfOrigin)
            : base(ID, price, isAvailable, brand)
        {
            this.Color = Color;
            this.CountryOfOrigin = CountryOfOrigin;
        }

        public string Color { get; private set; }

        public string CountryOfOrigin { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Color: {this.Color}");
            output.AppendLine($"Made in: {this.CountryOfOrigin}");

            return output.ToString();

        }

    }
}
