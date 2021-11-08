using HeadphonesShop.DataAccess.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private Context.HeadphonesDBContext _context;
        public UsersRepository(Context.HeadphonesDBContext context)
        {
            _context = context;
        }

        public UserModel GetUser(UserModel user)
        {
            user = _context.Users.Where(u => u.Login == user.Login && u.Password == user.Password).Select(u => new UserModel()
            {
                Login = u.Login,
                Password = u.Password,
                Role = new RoleModel()
                {
                    Name = u.Role.Name
                }
            }).SingleOrDefault();
            return user;
        }

        public UserModel GetGoogleUser(UserModel user)
        {
            user = _context.Users.Where(u => u.Login == user.Login && u.Password == "0").Select(u => new UserModel()
            {
                Login = u.Login,
                Password = u.Password,
                Role = new RoleModel()
                {
                    Name = u.Role.Name
                }
            }).SingleOrDefault();
            return user;
        }

        public UserModel FillUser(UserModel user)
        {
            user.FavHeadphones = _context.UserHeadphones.Where(u => u.User.Login == user.Login).Select(h => new HeadphonesModel()
            {
                Name = h.Headphones.Name,
                MinFrequency = h.Headphones.MinFrequency,
                MaxFrequency = h.Headphones.MaxFrequency,
                Picture = h.Headphones.Picture,
                Company = new CompanyModel()
                {
                    Name = h.Headphones.Company.Name
                },
                Design = new DesignModel()
                {
                    Name = h.Headphones.Design.Name
                }
            }).ToList();
            return user;
        }

        public IEnumerable<SmallUserModel> GetSmallOtherUsers(string login) 
        {
            var users = _context.Users.Where(u => u.Login != login).Select(u => new SmallUserModel()
            {
                Login = u.Login,
                Role = new RoleModel()
                {
                    Name = u.Role.Name
                }
            });
            return users;
        }

        public bool TryAdd(UserModel user)
        {
            if(!_context.Users.Any(u => u.Login == user.Login))
            {
                try
                {
                    var dbuser = new Models.DataModels.User()
                    {
                        Login = user.Login,
                        Password = user.Password,
                        RoleId = _context.Roles.First(r => r.Name == user.Role.Name).Id
                    };
                    _context.Users.Add(dbuser);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public void Update(UserModel user)
        {
            var heads = _context.UserHeadphones.Where(h => h.User.Login == user.Login && user.FavHeadphones.All(f => f.Name != h.Headphones.Name));
            _context.RemoveRange(heads);
        }

        public void Update(IEnumerable<SmallUserModel> users)
        {
            foreach (var u in users)
            {
                var userToUpdate = _context.Users.FirstOrDefault(x => x.Login == u.Login && x.Role.Name != u.Role.Name);
                if (userToUpdate is not null)
                {
                    userToUpdate.RoleId = _context.Roles.First(x => x.Name == u.Role.Name).Id;
                }
            }

            //var usersToUpdate =
            //    _context.Users.Where(u => users.Any(x => x.Login == u.Login && x.Role.Name != u.Role.Name)).ToList();
            //var allRoles = _context.Roles.Where(r => users.Any(u => u.Role.Name == r.Name)).ToList();

            //foreach (var user in usersToUpdate)
            //{
            //    user.RoleId = allRoles.First(r => r.Name == users.First(u => u.Login == user.Login).Role.Name).Id;
            //}
        }

        public void DeleteUser(string userEmail)
        {
            var userToDel = _context.Users.First(u => u.Login == userEmail);
            _context.Users.Remove(userToDel);
        }
    }
}
