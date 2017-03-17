using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Product : IProduct
    {
        private string name;
        public string brand;
        private decimal price;

        private const int minNameLength = 3;
        private const int minBrandLength = 2;
        private const int maxLength = 10;
        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                Validator.CheckIfStringLengthIsValid(value, maxLength, minBrandLength, $"Product brand must be between {minBrandLength} and {maxLength} symbols long!");
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get; set;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                Validator.CheckIfStringLengthIsValid(value, maxLength, minNameLength, $"Product name must be between {minNameLength} and {maxLength} symbols long!");
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                this.price = value;
            }
        }

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }
        public virtual string Print()
        {
            return $@"- {this.Brand} – {this.Name}:
  * Price: ${this.Price}
  * For gender: {this.Gender}";
        }
    }
}
