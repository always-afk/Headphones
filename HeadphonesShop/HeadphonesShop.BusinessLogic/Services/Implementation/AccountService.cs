using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User SignIn(User user)
        {
            return _unitOfWork.UsersRepository.GetAllUsers().Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault();
        }

        public bool SignUp(User user)
        {
            if (_unitOfWork.UsersRepository.Add(user))
            {
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
