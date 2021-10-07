using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    [Authorize(Roles ="common user")]
    public class CommonUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
