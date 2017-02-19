namespace BagLib
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using CatalogueLib;
    using ExceptionLib;
    using CatalogueLib.Products;
    using CatalogueLib.Products.Enumerations;

    public class Bag : IChangeable
    {
        private ICollection<Product> productsInBag;

        public Bag()
        {
            this.ProductsInBag = new List<Product>();
            //test the bag content
            productsInBag.Add(new Laptop(44, 33, true, Brand.HP, "cpu", 3334, "video", "win", 22, 445, 6));

        }

        public ICollection<Product> ProductsInBag
        {
            get
            {
                return new List<Product>(this.productsInBag);
            }
            private set
            {
                this.productsInBag = value;
            }
        }

        public void AddProduct(Product product)
        {
            this.productsInBag.Add(product);
        }

        public void RemoveProduct(int id, Product p)
        {
            bool hasBeenRemoved = false;
            foreach (var product in this.productsInBag)
            {
                if (product.ID == id)
                {
                    this.productsInBag.Remove(product);
                    hasBeenRemoved = true;
                    break;
                }
            }
            if (!hasBeenRemoved)
            {
                throw new ProductNotFoundException("There is not such a product in your bag.");
            }
        }

        public void RemoveAll()
        {
            productsInBag.Clear();
        }

        public decimal Pay()
        {
            decimal sum = 0M;
            foreach (var product in this.productsInBag)
            {
                sum += product.Price;
            }
            RemoveAll();
            return sum;
        }

        public override string ToString()
        {
            StringBuilder products = new StringBuilder();
            foreach (var product in productsInBag)
            {
                products.Append(product.ToString());

            }
            return products.ToString();
        }
    }
}
