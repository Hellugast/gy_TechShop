using gy_TechShop.Business.Abstract;
using gy_TechShop.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace gy_TechShop.Web.Controllers
{
    public class RegisterController : Controller
    {

        IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto UserRegisterDto)
        {
            var result = _authService.Register(UserRegisterDto, UserRegisterDto.Password);
            if (result.Success)
            {
                ViewBag.Message = result.Message;
            }
            return View("Index");
        }




    }
}
