using gy_TechShop.Business.Abstract;
using gy_TechShop.Business.BusinessAspects.Autofac;
using gy_TechShop.Business.Constants;
using gy_TechShop.Business.ValidationRules.FluentValidation;
using gy_TechShop.Core.Aspects.Autofac.Caching;
using gy_TechShop.Core.Aspects.Autofac.Validation;
using gy_TechShop.Core.Utilities.Business;
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
    
    public class ProductManager : IProductService
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(ProductAddDto product)
        {
            var result = BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName));
                //CheckIfCategoryLimitExceded());
            if (result != null) return result;

            var addToProduct = new Product
            {
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice,
                Picture = product.Picture,
                Description = product.Description
            };

            _productDal.Add(addToProduct);

            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheAspect]
        //[SecuredOperation("user")]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10) return new ErrorResult(Messages.ProductCountOfCategoryError);
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result) return new ErrorResult(Messages.ProductNameAlreadyExists);
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15) return new ErrorResult(Messages.CategoryLimitExceded);
            return new SuccessResult();
        }

        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(int productId)
        {
            var product = _productDal.Get(p => p.ProductId == productId);
            if (product == null) { return new ErrorResult(Messages.ProductNotFound); }
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            var productUpdated = _productDal.Get(p => p.ProductId == product.ProductId);
            if (product == null) { return new ErrorResult(Messages.ProductNotFound); }
            productUpdated.CategoryId = product.CategoryId;
            productUpdated.ProductName = product.ProductName;
            productUpdated.UnitsInStock = product.UnitsInStock;
            productUpdated.UnitPrice = product.UnitPrice;
            productUpdated.Picture = product.Picture == null ? product.Picture : productUpdated.Picture;
            productUpdated.Description = product.Description;
            _productDal.Update(productUpdated);
            return new SuccessResult(Messages.ProductUpdated);
        }

    }
}
