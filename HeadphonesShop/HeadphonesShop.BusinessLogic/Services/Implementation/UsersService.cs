using HeadphonesShop.BusinessLogic.Models.LogicModels;
using HeadphonesShop.DataAccess.Repository.Implementation;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class UsersService : Interfaces.IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public User FillUser(User user)
        {
            var us = _mapper.Map<User, DataAccess.Models.LogicModels.UserModel>(user);
            user.FavHeadphones = _unitOfWork.UsersRepository.FillUser(us).FavHeadphones
                .Select(h => _mapper.Map<DataAccess.Models.LogicModels.HeadphonesModel, Headphones>(h)).ToList();

            return user;
        }

        public IEnumerable<SmallUser> GetOtherUsers(User user)
        {
            var res = _unitOfWork.UsersRepository.GetSmallOtherUsers(user.Login)
                .Select(u => _mapper.Map<DataAccess.Models.LogicModels.SmallUserModel, SmallUser>(u));
            return res;
        }

        public void Update(IEnumerable<SmallUser> users)
        {
            var smallUserModels = users.Select(u => _mapper.Map<SmallUser, DataAccess.Models.LogicModels.SmallUserModel>(u));

            _unitOfWork.UsersRepository.Update(smallUserModels);
            _unitOfWork.Save();
        }

        public void Update(User user)
        {
            var us = _mapper.Map<User, DataAccess.Models.LogicModels.UserModel>(user);
            _unitOfWork.Save();
        }

        public IEnumerable<SmallUser> GetOtherUsers(string login)
        {
            var users = _unitOfWork.UsersRepository.GetSmallOtherUsers(login)
                .Select(u => _mapper.Map<DataAccess.Models.LogicModels.SmallUserModel, SmallUser>(u));
            return users;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            var roles = _unitOfWork.RolesRepository.GetRoles().Select(r => _mapper.Map<Role>(r));
            return roles;
        }

        public void DeleteUser(string userEmail)
        {
            _unitOfWork.UsersRepository.DeleteUser(userEmail);
            _unitOfWork.Save();
        }
    }
}
