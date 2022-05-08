using gy_TechShop.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult AddClaims(int userId, int claimId);
    }
}
