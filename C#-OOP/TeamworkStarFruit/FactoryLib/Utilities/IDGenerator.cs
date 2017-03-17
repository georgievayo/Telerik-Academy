namespace FactoryLib.Utilities
{
    using System.Linq;

    using CatalogueLib;

    public struct IDGenerator
    {
        public static int IdGen()
        {
            Catalogue c = new Catalogue();
            int max = c.CatalogueList.Max(x => x.ID);
            max++;
            return max;
        }
    }
}
