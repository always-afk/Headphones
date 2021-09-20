using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAllUsers();
        bool Add(User user);
        void Delete(User user);
        void Update(IEnumerable<User> users);
        void Save();
    }
}
