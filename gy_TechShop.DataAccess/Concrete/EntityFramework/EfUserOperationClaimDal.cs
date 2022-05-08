using gy_TechShop.Core.DataAccess.EntityFramework;
using gy_TechShop.Core.Entities.Concrete;
using gy_TechShop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, gyTechShopDbContext>, IUserOperationClaimDal
    {
    }
}
