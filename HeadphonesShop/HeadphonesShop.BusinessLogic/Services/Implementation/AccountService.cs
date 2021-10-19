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
            var u = _mapper.Map<User, DataAccess.Models.LogicModels.User>(user);
            var res = _unitOfWork.UsersRepository.CheckUser(u);
            if(res is not null)
            {
                var us = _mapper.Map<DataAccess.Models.LogicModels.User, User>(res);
                return us;
            }
            return null;
        }

        public User SignInGoogle(User user)
        {
            var u = _mapper.Map<User, DataAccess.Models.LogicModels.User>(user);
            var res = _unitOfWork.UsersRepository.CheckGoogleUser(u);

            if (res is not null)
            {
                var us = _mapper.Map<DataAccess.Models.LogicModels.User, User>(res);
                return us;
            }

            if (_unitOfWork.UsersRepository.TryAdd(u))
            {
                res = _unitOfWork.UsersRepository.CheckGoogleUser(u);
                _unitOfWork.Save();

                var us = _mapper.Map<DataAccess.Models.LogicModels.User, User>(res);
                return us;
            }

            return null;
        }

        public bool SignUp(User user)
        {
            var u = _mapper.Map<User, DataAccess.Models.LogicModels.User>(user);

            if (_unitOfWork.UsersRepository.TryAdd(u))
            {
                _unitOfWork.Save();
                return true;
            }

            return false;
        }
    }
}
