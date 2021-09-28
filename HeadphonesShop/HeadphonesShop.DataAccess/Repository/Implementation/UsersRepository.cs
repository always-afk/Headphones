using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Services.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private Context.HeadphonesDBContext _context;
        private IMapper _mapper;
        //public UsersRepository()
        //{
        //    _context = new Context.HeadphonesDBContext();
        //    _dataMapper = new DataMapper();
        //    _commonMapper = new CommonMapper();
        //}
        public UsersRepository(Context.HeadphonesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            foreach(var u in _context.Users.Include(u => u.Role))
            {
                users.Add(_mapper.ToUser(u));
            }
            return users;
        }

        public IEnumerable<User> GetOtherUsers(User user)
        {
            var users = new List<User>();
            foreach(var us in _context.Users.Where(u => u.Login != user.Login))
            {
                users.Add(_mapper.ToUser(us));
            }
            return users;
        }


        public void Update(IEnumerable<User> users)
        {
            var idAdmin = _context.Roles.Where(r => r.Name == "admin").FirstOrDefault().Id;
            foreach (var user in _context.Users)
            {
                var us = users.Where(u => u.Login == user.Login).FirstOrDefault();
                if(us is null)
                {
                    _context.Remove(user);
                }
                else
                {
                    //user.IsAdmin = us.IsAdmin;
                }
            }
            foreach (var user in users)
            {
                var roleId = _context.Roles.Where(r => r.Name == user.Role.Name).FirstOrDefault().Id;
                var us = _context.Users.Where(u => u.Login == user.Login).FirstOrDefault();
                us.RoleId = roleId;
            }
        }

        bool Add(User user)
        {
            if (!_context.Users.Any(u => u.Login == user.Login))
            {
                var newUser = _mapper.ToUser(user);
                newUser.RoleId = _context.Roles.Where(r => r.Name == user.Role.Name).FirstOrDefault().Id;
                newUser.Role = null;
                _context.Users.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IUsersRepository.Add(User user)
        {
            if (!_context.Users.Any(u => u.Login == user.Login))
            {
                var newUser = _mapper.ToUser(user);
                newUser.RoleId = _context.Roles.Where(r => r.Name == user.Role.Name).FirstOrDefault().Id;
                newUser.Role = null;
                _context.Users.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
