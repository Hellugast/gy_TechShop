using Castle.DynamicProxy;
using gy_TechShop.Business.Constants;
using gy_TechShop.Core.Extensions;
using gy_TechShop.Core.Utilities.IoC;
using gy_TechShop.Core.Utilities.MethodInterceptors;
using gy_TechShop.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string[] _roles;

        public SecuredOperation(string roles)
        {
            /*
            using (var context = new gyTechShopDbContext())
            {
                var claim = context.OperationClaims.FirstOrDefault(i => i.Name == roles);
                var user = context.UserOperationClaims.FirstOrDefault(i => i.OperationClaimId == claim.Id);
            }
            */
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
                if (roleClaims.Contains(role))
                    return;
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
