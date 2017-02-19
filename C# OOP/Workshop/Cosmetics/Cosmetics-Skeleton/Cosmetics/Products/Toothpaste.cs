using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste, IProduct
    {
        private const int maxIngredientLength = 12;
        private const int minIngredientLength = 4;
        private string ingredients;

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            protected set
            {
                this.ingredients = value;
            }
        }

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) : base(name, brand, price, gender)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, maxIngredientLength, minIngredientLength, $"Each ingredient must be between {minIngredientLength} and {maxIngredientLength} symbols long!");
            }
            this.Ingredients = string.Join(", ", ingredients);
            
        }

        public override string Print()
        {
            return base.Print() + $"\n  * Ingredients: {this.Ingredients}";
        }
    }
}
