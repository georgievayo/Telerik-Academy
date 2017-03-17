namespace CatalogueLib
{
    using System.Text;
    using CatalogueLib.Products.Enumerations;
     

    public abstract class SmallAppliances : Product
    {
        public SmallAppliances()
        {

        }

        public SmallAppliances(int ID, decimal price, bool isAvailable, Brand brand, double Capacity, double CableLength, int Affixes)
            : base(ID, price, isAvailable, brand)
        {
            this.Capacity = Capacity;
            this.CableLength = CableLength;
            this.Affixes = Affixes;
        }

        public double Capacity { get; private set; }

        public double CableLength { get; private set; }

        public int Affixes { get; private set; }

       public override string ToString()
        { 
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Capacity: {this.Capacity}");
            output.AppendLine($"Cable length: {this.CableLength}");
            output.Append($"Affixes: {this.Affixes}");

            return output.ToString();
        }
    }
}
