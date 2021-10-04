using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<User> GetOtherUsers(User user);
        void Update(IEnumerable<User> users);
        void Update(User user);
    }
}
