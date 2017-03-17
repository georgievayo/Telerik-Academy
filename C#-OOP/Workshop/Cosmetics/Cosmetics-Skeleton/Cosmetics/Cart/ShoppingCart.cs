using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Cart
{
    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = null;
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            set { this.productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            if (this.productList == null)
            {
                this.productList = new List<IProduct>();
            }
            this.ProductList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.ProductList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.ProductList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal total = 0;
            foreach (var product in this.productList)
            {
                total += product.Price;
            }
            return total;
        }
    }
}
