namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class Oven : BigAppliances
    {
        public Oven()
        {

        }

        public Oven(int ID, decimal price, bool isAvailable, Brand brand, string Color, string CountryOfBirth, string ElectricOrGas)
            : base(ID, price, isAvailable, brand, Color, CountryOfBirth)
        {
            this.ElectricOrGas = ElectricOrGas;
        }

        public string ElectricOrGas { get; private set; }
        public object StrinBuilder { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"The oven is {this.ElectricOrGas}.");

            return output.ToString();
        }
    }
}