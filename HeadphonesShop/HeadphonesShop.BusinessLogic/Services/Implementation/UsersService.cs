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
        private readonly IUnitOfWork _unitOfWork;
        //public UsersService()
        //{
        //    _usersRepository = new UsersRepository();
        //}
        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetOtherUsers(User user)
        {
            return _unitOfWork.UsersRepository.GetOtherUsers(user);
        }

        public void Update(IEnumerable<User> users)
        {
            _unitOfWork.UsersRepository.Update(users);
            _unitOfWork.Save();
        }

        public void Update(User user)
        {
            _unitOfWork.UsersRepository.Update(user);
            _unitOfWork.Save();
        }
    }
}
