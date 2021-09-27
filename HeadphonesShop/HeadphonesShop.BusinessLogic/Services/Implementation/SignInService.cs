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
        private readonly IUnitOfWork _unitOfWork;
        //public SignInService()
        //{
        //    _usersRepository = new UsersRepository();
        //}
        public SignInService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User SignIn(User user)
        {
            return _unitOfWork.UsersRepository.GetAllUsers().Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault();
        }
    }
}
