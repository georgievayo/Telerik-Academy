﻿using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo, IProduct

    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) : base(name, brand, price * milliliters, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public override string Print()
        {
            return base.Print() + $@"
  * Quantity: {this.Milliliters} ml
  * Usage: {this.Usage}";
        }
    }
}
