using gy_TechShop.Core.DataAccess.EntityFramework;
using gy_TechShop.DataAccess.Abstract;
using gy_TechShop.Entities.Concrete;
using gy_TechShop.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, gyTechShopDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (var context = new gyTechShopDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                                 on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock,
                                 Picture = p.Picture
                             };
                return result.ToList();
            }
        }
    }
}
