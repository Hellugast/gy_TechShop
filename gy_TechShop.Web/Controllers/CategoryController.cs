using gy_TechShop.Business.Abstract;
using gy_TechShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace gy_TechShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll().Data
            };
            return View(model);
        }
    }
}
