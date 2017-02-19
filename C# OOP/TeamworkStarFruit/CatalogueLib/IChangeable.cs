namespace CatalogueLib
{
    public interface IChangeable
    {
        void AddProduct(Product product);
        void RemoveProduct(int id, Product product);
        void RemoveAll();
    }
}
