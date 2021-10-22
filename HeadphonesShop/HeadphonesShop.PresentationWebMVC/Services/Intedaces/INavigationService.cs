using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Services.Intedaces
{
    public interface INavigationService
    {
        public IActionResult Navigate(string roleName);
    }
}
