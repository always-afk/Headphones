using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Repository.Implementation;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class UsersService : Interfaces.IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        //public UsersService()
        //{
        //    _usersRepository = new UsersRepository();
        //}
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public IEnumerable<User> GetOtherUsers(User user)
        {
            return _usersRepository.GetOtherUsers(user);
        }

        public void Update(IEnumerable<User> users)
        {
            _usersRepository.Update(users);
        }
    }
}
