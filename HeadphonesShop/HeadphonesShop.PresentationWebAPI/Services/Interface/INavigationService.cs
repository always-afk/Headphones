using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebAPI.Services.Interface
{
    public interface INavigationService
    {
        string NavigateByRole(string roleName);
    }
}
