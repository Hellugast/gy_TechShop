using gy_TechShop.Business.Abstract;
using gy_TechShop.Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gy_TechShop.Web.Controllers
{
    public class LoginController : Controller
    {
        IAuthService _authService;
        IHttpContextAccessor _httpContextAccessor;
        public LoginController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = _authService.Login(userLoginDto);
            if (result.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,result.Data.Email),
                    new Claim(ClaimTypes.NameIdentifier,result.Data.Id.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "LoginClaims");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
