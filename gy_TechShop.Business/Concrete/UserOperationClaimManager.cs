using gy_TechShop.Business.Abstract;
using gy_TechShop.Core.Entities.Concrete;
using gy_TechShop.Core.Utilities.Results;
using gy_TechShop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult AddClaims(int userId, int claimId)
        {
            var claim = new UserOperationClaim()
            {
                OperationClaimId = claimId,
                UserId = userId
            };
            _userOperationClaimDal.Add(claim);
            return new SuccessResult("Claim added.");
        }
    }
}
