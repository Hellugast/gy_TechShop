using gy_TechShop.Business.Abstract;
using gy_TechShop.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gy_TechShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("get-all-brands")]
        public IActionResult GetAllBrands()
        {
            var result = _brandService.GetAllBrands();
            return StatusCode(result.Success ? 200 : 400,result);
        }
        [HttpPost("add-brand")]
        public IActionResult AddBrand(BrandAddDto brand)
        {
            var result = _brandService.AddBrand(brand);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
