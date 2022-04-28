﻿using gy_TechShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Entities.DomainModels
{
    public class Cart : IDomainModel
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }

        public List<CartLine> CartLines { get; set; }

        //public decimal Total
        //{
        //    get { return CartLines.Sum(c => c.Quantity * c.Product.UnitPrice); }
        //}
    }
}
