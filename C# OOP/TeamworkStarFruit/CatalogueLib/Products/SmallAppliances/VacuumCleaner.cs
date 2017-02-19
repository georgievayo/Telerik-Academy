namespace CatalogueLib.Products
{
    using CatalogueLib.Products.Enumerations;
    using System.Text;

    public class VacuumCleaner : SmallAppliances
    {
        public VacuumCleaner()
        {

        }

        public VacuumCleaner(int ID, decimal price, bool isAvailable, Brand brand, double Capacity, double CableLength, int Affixes, double GarbageBagVolume)
            : base(ID, price, isAvailable, brand, Capacity, CableLength, Affixes)
        {
            this.GarbageBagVolume = GarbageBagVolume;
        }

        // in litres
        public double GarbageBagVolume { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Garbage bag volume: {this.GarbageBagVolume}");

            return output.ToString();
        }
    }
}
