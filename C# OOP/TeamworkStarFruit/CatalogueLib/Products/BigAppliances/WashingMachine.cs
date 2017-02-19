namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class WashingMachine : BigAppliances
    {
        public WashingMachine()
        {

        }

        public WashingMachine(int ID, decimal price, bool isAvailable, Brand brand, string Color, string CountryOfBirth, string LaundryCapacity, string MotorType) 
            : base(ID,price, isAvailable, brand, Color, CountryOfBirth)
        {
            this.LaundryCapacity = LaundryCapacity;
            this.MotorType = MotorType;
        }

        public string LaundryCapacity { get; private set; }

        public string MotorType { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Type of motor: {this.MotorType}");
            output.AppendLine($"Laundry capacity: {this.LaundryCapacity}");

            return output.ToString();
        }
    }
}
