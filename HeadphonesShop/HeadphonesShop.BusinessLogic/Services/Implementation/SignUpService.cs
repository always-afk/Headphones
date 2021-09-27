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
        private readonly IUnitOfWork _unitOfWork;
        //public SignUpService()
        //{
        //    _usersRepository = new UsersRepository();
        //}
        public SignUpService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
