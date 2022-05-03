using Castle.DynamicProxy;
using gy_TechShop.Core.CrossCuttingConcerns.Caching;
using gy_TechShop.Core.Utilities.IoC;
using gy_TechShop.Core.Utilities.MethodInterceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly string _pattern;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
