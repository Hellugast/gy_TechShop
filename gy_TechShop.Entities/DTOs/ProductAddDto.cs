using gy_TechShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Entities.DTOs
{
    public class ProductAddDto : IDto
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
    }
}
