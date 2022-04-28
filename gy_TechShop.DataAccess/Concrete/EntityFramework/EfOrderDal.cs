using gy_TechShop.Core.DataAccess.EntityFramework;
using gy_TechShop.DataAccess.Abstract;
using gy_TechShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, gyTechShopDbContext>, IOrderDal
    {
    }
}
