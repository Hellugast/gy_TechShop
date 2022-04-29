using gy_TechShop.Business.Abstract;
using gy_TechShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace gy_TechShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int category)
        {
            var model = new ProductListViewModel
            {
                Products = category > 0
                    ? _productService.GetAllByCategoryId(category).Data
                    : _productService.GetAll().Data
            };
            return View(model);
        }
    }
}
