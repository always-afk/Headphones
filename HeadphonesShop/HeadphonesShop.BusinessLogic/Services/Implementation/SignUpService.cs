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
    public class SignUpService : Interfaces.ISignUpService
    {
        private readonly IUsersRepository _usersRepository;
        //public SignUpService()
        //{
        //    _usersRepository = new UsersRepository();
        //}
        public SignUpService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool SignUp(User user)
        {
            return _usersRepository.Add(user);
        }
    }
}
