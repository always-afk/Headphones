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
            var us = _mapper.Map<User, DataAccess.Models.LogicModels.User>(user);
            user.FavHeadphones = _unitOfWork.UsersRepository.FillUser(us).FavHeadphones
                .Select(h => _mapper.Map<DataAccess.Models.LogicModels.Headphones, Headphones>(h)).ToList();

            return user;
        }

        public IEnumerable<SmallUser> GetOtherUsers(User user)
        {
            var res = _unitOfWork.UsersRepository.GetSmallOtherUsers(user.Login)
                .Select(u => _mapper.Map<DataAccess.Models.LogicModels.SmallUser, SmallUser>(u));
            return res;
        }

        public void Update(IEnumerable<SmallUser> users)
        {
            var us = users.Select(u => _mapper.Map<SmallUser, DataAccess.Models.LogicModels.SmallUser>(u));

            _unitOfWork.UsersRepository.Update(us);
            _unitOfWork.Save();
        }

        public void Update(User user)
        {
            var us = _mapper.Map<User, DataAccess.Models.LogicModels.User>(user);
            _unitOfWork.Save();
        }
    }
}
