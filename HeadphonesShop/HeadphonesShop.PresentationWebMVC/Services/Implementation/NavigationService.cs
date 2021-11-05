using Microsoft.AspNetCore.Mvc;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Services.Implementation
{
    public class NavigationService : Intedaces.INavigationService
    {
        public IActionResult Navigate(string roleName)
        {
            IActionResult result;
            if (roleName == Constants.Roles.Admin)
            {
                result = new RedirectResult("~/Admin/Index");
            }
            else if (roleName == Constants.Roles.CommonUser)
            {
                result = new RedirectResult("~/CommonUser/Index");
            }
            else
            {
                result = new RedirectResult("~/Home/Index");
            }
            return result;
        }
    }
}
