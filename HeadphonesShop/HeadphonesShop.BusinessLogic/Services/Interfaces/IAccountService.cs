using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        User SignIn(User user);
        bool SignUp(User user);
    }
}
