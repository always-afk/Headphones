using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.PresentationWebAPI.Services.Interface;

namespace HeadphonesShop.PresentationWebAPI.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        public string NavigateByRole(string roleName)
        {
            switch (roleName)
            {
                case "admin":
                    return "/Pages/Admin/Index.html";
                case "common user":
                    return "/Pages/CommonUser/Index.html";
                default:
                    return "/Pages/AccountIndex.html";
            }
        }
    }
}
