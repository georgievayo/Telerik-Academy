namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class AirConditioner : BigAppliances
    {
        public AirConditioner()
        {

        }

        public AirConditioner(int ID, decimal price, bool isAvailable, Brand brand, string Color, string CountryOfBirth, string TypeOfSystem, bool HasWiFi)
            : base(ID, price, isAvailable, brand, Color, CountryOfBirth)
        {
            this.TypeOfSystem = TypeOfSystem;
            this.HasWiFi = HasWiFi;
        }

        public string TypeOfSystem { get; private set; }


        public bool HasWiFi
        { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Type of air conditioning system: {this.TypeOfSystem}");
            output.AppendLine(string.Format("Has WiFi control: {0}", this.HasWiFi ? "Yes" : "No"));

            return output.ToString();
        }
    }
}
