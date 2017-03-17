namespace CatalogueLib.Products
{

    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class Refrigerator : BigAppliances
    {
        public Refrigerator()
        {

        }

        public Refrigerator(int ID, decimal price, bool isAvailable, Brand brand, string Color, string CountryOfBirth, string TypeOfTechnology)
            : base(ID, price, isAvailable, brand, Color, CountryOfBirth)
        {
            this.TypeOfTechnology = TypeOfTechnology;
        }

        public string TypeOfTechnology { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Type of cooling system: {this.TypeOfTechnology}");

            return output.ToString();
        }
    }
}