using gy_TechShop.Core.Utilities.Results;
using gy_TechShop.Entities.Concrete;
using gy_TechShop.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();

        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetail();

        IDataResult<Product> GetById(int productId);

        IResult Add(ProductAddDto product);

        IResult Delete(int productId);

        IResult SoftDelete(int productId);

        IResult Update(Product product);
    }
}
