using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Repository.Implementation;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class SignInService : Interfaces.ISignInService
    {
        private readonly IUsersRepository _usersRepository;
        //public SignInService()
        //{
        //    _usersRepository = new UsersRepository();
        //}
        public SignInService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User SignIn(User user)
        {
            return _usersRepository.GetAllUsers().Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault();
        }
    }
}
