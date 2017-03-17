namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class HairDryer : SmallAppliances
    {
        public HairDryer()
        {

        }

        public HairDryer(int ID, decimal price, bool isAvailable, Brand brand, double Capacity, double CableLength, int Affixes, int DifferentSpeeds)
            : base(ID, price, isAvailable, brand, Capacity, CableLength, Affixes)
        {
            this.DifferentSpeeds = DifferentSpeeds;
        }

        public int DifferentSpeeds { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Number of different speeds: {this.DifferentSpeeds}");

            return output.ToString();
        }
    }
}
