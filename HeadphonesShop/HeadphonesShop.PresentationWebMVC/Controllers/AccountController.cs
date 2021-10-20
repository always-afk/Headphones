using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public IActionResult SignInGoogle()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var user = new User()
            {
                Login = User.FindFirst(ClaimTypes.Email).Value,
                Password = "0",
                Role = new Role()
                {
                    Name = "common user"
                }
            };

            var u = _mapper.Map<User, BusinessLogic.Models.LogicModels.User>(user);

            u = _accountService.SignInGoogle(u);

            user = _mapper.Map<BusinessLogic.Models.LogicModels.User, User>(u);
            
            return await Authenticate(user);
        }        
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {
            var u = _mapper.Map<User, BusinessLogic.Models.LogicModels.User>(user);
            u = _accountService.SignIn(u);
            user = _mapper.Map<BusinessLogic.Models.LogicModels.User, User>(u);

            if (user is not null)
            {
                return await Authenticate(user);
            }
            else
            {
                return Content("Error");
            }
        }
        private async Task<IActionResult> Authenticate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Login),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

            if (user.Role.Name == "admin")
            {
                return Redirect("~/Admin/Index");
            }
            else if (user.Role.Name == "common user")
            {
                return Redirect("~/CommonUser/Index");
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
