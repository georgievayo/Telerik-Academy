namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class Mixer : SmallAppliances
    {
        public Mixer()
        {

        }

        public Mixer(int ID, decimal price, bool isAvailable, Brand brand, double Capacity, double CableLength, int Affixes, bool HasBowl)
            : base(ID, price, isAvailable, brand, Capacity, CableLength, Affixes)
        {
            this.HasBowl = HasBowl;
        }

        public bool HasBowl { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine(string.Format("Has a bowl: {0}", this.HasBowl ? "Yes" : "No"));

            return output.ToString();
        }
    }
}
