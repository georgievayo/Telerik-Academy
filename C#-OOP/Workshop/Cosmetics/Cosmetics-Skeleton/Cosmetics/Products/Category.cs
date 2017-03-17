using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private string name;
        private const int CategoryMinLength = 2;
        private const int CategoryMaxLength = 15;
        private List<IProduct> products;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, CategoryMaxLength, CategoryMinLength, $"Category name must be between {CategoryMinLength} and {CategoryMaxLength} symbols long!");
                this.name = value;
            }
        }
        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder printProducts = new StringBuilder();
            if (this.products.Count == 1)
            {
                printProducts.AppendLine($"{this.Name} category - {this.products.Count} product in total");
            }
            else
            {
                printProducts.AppendLine($"{this.Name} category - {this.products.Count} products in total");
            }
            foreach (var product in this.products)
            {
                printProducts.AppendLine(product.Print());
            }
            return printProducts.ToString();
        }
    }
}
