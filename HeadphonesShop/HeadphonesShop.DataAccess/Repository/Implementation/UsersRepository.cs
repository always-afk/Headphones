using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Services.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;
using HeadphonesShop.DataAccess.Repository.Interfaces;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class UsersRepository : Interfaces.IUsersRepository
    {
        private Context.HeadphonesDBContext _context;
        private IDataMapper _dataMapper;
        private ICommonMapper _commonMapper;
        public UsersRepository()
        {
            _context = new Context.HeadphonesDBContext();
            _dataMapper = new DataMapper();
            _commonMapper = new CommonMapper();
        }
        public void Add(User user)
        {
            var newUser = _dataMapper.ToUser(user);
            _context.Users.Add(newUser);

        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            foreach(var u in _context.Users)
            {
                users.Add(_commonMapper.ToUser(u));
            }
            return users;
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void Update(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        bool IUsersRepository.Add(User user)
        {
            if (!_context.Users.Any(u => u.Login == user.Login))
            {
                _context.Users.Add(_dataMapper.ToUser(user));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
