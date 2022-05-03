using gy_TechShop.Business.Abstract;
using gy_TechShop.Business.Constants;
using gy_TechShop.Business.ValidationRules.FluentValidation;
using gy_TechShop.Core.Aspects.Autofac.Validation;
using gy_TechShop.Core.Utilities.Results;
using gy_TechShop.DataAccess.Abstract;
using gy_TechShop.Entities.Concrete;
using gy_TechShop.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult AddBrand(BrandAddDto brand)
        {
            var addToBrand = new Brand()
            {
                BrandName = brand.BrandName
            };
            _brandDal.Add(addToBrand);
            return new SuccessResult(Messages.BrandAdded);
        }
        public IDataResult<List<Brand>> GetAllBrands()
        {
            var result = _brandDal.GetAll();
            if (result == null) return new ErrorDataResult<List<Brand>>(Messages.BrandNotFound);
            return new SuccessDataResult<List<Brand>>(result);
        }
    }
}
