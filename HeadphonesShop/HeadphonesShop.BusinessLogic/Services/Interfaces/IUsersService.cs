using HeadphonesShop.BusinessLogic.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface IUsersService
    {
        public User FillUser(User user);

        public IEnumerable<SmallUser> GetOtherUsers(User user);

        public void Update(IEnumerable<SmallUser> users);

        public void Update(User user);

        public IEnumerable<SmallUser> GetOtherUsers(string login);

        public IEnumerable<Role> GetAllRoles();
        public void DeleteUser(string userEmail);


    }
}
