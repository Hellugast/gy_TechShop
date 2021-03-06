using gy_TechShop.Business.Abstract;
using gy_TechShop.Entities.Concrete;
using gy_TechShop.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace gy_TechShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ProductAddDto product)
        {
            var result = _productService.Add(product);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int productId)
        {
            var result = _productService.Delete(productId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("softdelete")]
        public IActionResult SoftDelete(int productId)
        {
            var result = _productService.SoftDelete(productId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
