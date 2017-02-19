namespace CatalogueLib
{
    using System.Collections.Generic;

    public interface ISortable
    {
        IEnumerable<Product> Show(Product p);
    }
}
