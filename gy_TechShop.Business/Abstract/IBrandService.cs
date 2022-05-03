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
    public interface IBrandService
    {
        IResult AddBrand(BrandAddDto brand);
        IDataResult<List<Brand>> GetAllBrands();
    }
}
