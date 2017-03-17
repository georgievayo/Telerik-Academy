using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueLib.Products.Enumerations;
namespace CatalogueLib.Products
{

    using CatalogueLib.Products.Struct;

    public class MobilePhone : Mobile
    {
        public MobilePhone()
        {

        }

        public MobilePhone(int ID, decimal price, bool isAvailable, Brand brand, int Memory, string CPU, int RAM, string Model, string battery, string connectivity, bool ExpandableMemory, double ScreenSize, string GPU, string OperatingSystem)
            : base(ID, price, isAvailable, brand, Memory, CPU, RAM, Model, battery, connectivity, ExpandableMemory, ScreenSize)
        {
            this.GPU = GPU;
            this.OperatingSystem = OperatingSystem;
        }

        public string GPU { get; private set; }

        public string OperatingSystem { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"GPU: {this.GPU}");
            output.AppendLine($"Operating system: {this.OperatingSystem}");

            return output.ToString();
        }
    }
}
