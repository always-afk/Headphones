using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.Common.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    public class UnknownUserController : Controller
    {
        private readonly ISignInService _signInService;
        public UnknownUserController(ISignInService signInService)
        {
            _signInService = signInService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var user = new User()
            {
                Login = email,
                Password = password
            };
            user = _signInService.SignIn(user);
            if(user is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Login),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                if(user.Role.Name == "admin")
                {
                    return Redirect("~/Admin/Index");
                }
                else if(user.Role.Name == "common user")
                {
                    return Redirect("~/CommonUser/Index");
                }

                return Content("Ok");
            }
            else
            {
                return Content("Error");
            }
        }
        public IActionResult SignUp()
        {
            return Content("Sign Up");
        }
    }
}
