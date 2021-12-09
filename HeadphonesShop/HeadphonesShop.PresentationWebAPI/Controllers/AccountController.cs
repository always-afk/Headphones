using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebAPI.Models.DTO;
using HeadphonesShop.PresentationWebAPI.Models.LogicModels;
using HeadphonesShop.PresentationWebAPI.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace HeadphonesShop.PresentationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, INavigationService navigationService, IMapper mapper)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            _mapper = mapper;
        }

        

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInDTO userDTO)
        {
            Console.WriteLine("POST");
            var userModel = _mapper.Map<BusinessLogic.Models.LogicModels.User>(userDTO.User);
            userModel = _accountService.SignIn(userModel);
            


            if (userModel is null)
            {
                return NotFound();
            }

            var user = _mapper.Map<User>(userModel);

            await Authenticate(user);

            var redirect = _navigationService.NavigateByRole(user.Role.Name);

            return Ok(redirect);
        }

        [HttpPost]
        public IActionResult SignInGoogle()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var user = new User()
            {
                Login = User.FindFirst(ClaimTypes.Email)?.Value,
                Password = "0",
                Role = new Role()
                {
                    Name = "common user"
                }
            };

            var u = _mapper.Map<User, BusinessLogic.Models.LogicModels.User>(user);

            u = _accountService.SignInGoogle(u);

            user = _mapper.Map<BusinessLogic.Models.LogicModels.User, User>(u);

            await Authenticate(user);

            var redirect = _navigationService.NavigateByRole(user.Role.Name);

            return Ok(redirect);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Login),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
        }
    }
}
