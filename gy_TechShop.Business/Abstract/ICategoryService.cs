using gy_TechShop.Core.Utilities.Results;
using gy_TechShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();

        IDataResult<Category> GetById(int categoryId);
    }
}
