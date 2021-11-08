using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.BusinessLogic.Models.LogicModels;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public User SignIn(User user)
        {
            var userModel = _mapper.Map<User, DataAccess.Models.LogicModels.UserModel>(user);
            var existUser = _unitOfWork.UsersRepository.GetUser(userModel);

            if (existUser is null)
            {
                return null;
            }

            user = _mapper.Map<DataAccess.Models.LogicModels.UserModel, User>(existUser);
            return user;
        }

        public User SignInGoogle(User user)
        {
            var userModel = _mapper.Map<User, DataAccess.Models.LogicModels.UserModel>(user);
            var existUser = _unitOfWork.UsersRepository.GetGoogleUser(userModel);

            if (existUser is not null)
            {
                user = _mapper.Map<DataAccess.Models.LogicModels.UserModel, User>(existUser);
                return user;
            }

            if (_unitOfWork.UsersRepository.TryAdd(userModel))
            {
                existUser = _unitOfWork.UsersRepository.GetGoogleUser(userModel);
                _unitOfWork.Save();

                user = _mapper.Map<DataAccess.Models.LogicModels.UserModel, User>(existUser);
                return user;
            }

            return null;
        }

        public bool SignUp(User user)
        {
            var u = _mapper.Map<User, DataAccess.Models.LogicModels.UserModel>(user);

            if (_unitOfWork.UsersRepository.TryAdd(u))
            {
                _unitOfWork.Save();
                return true;
            }

            return false;
        }
    }
}
