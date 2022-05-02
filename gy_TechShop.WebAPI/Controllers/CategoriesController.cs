using gy_TechShop.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace gy_TechShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
