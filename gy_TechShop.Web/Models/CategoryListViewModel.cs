using gy_TechShop.Entities.Concrete;
using System.Collections.Generic;

namespace gy_TechShop.Web.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int ActiveCategoryId { get; set; }
    }
}
