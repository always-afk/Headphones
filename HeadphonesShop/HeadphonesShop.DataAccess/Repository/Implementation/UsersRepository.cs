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

        public User CheckUser(User user)
        {
            user = _context.Users.Where(u => u.Login == user.Login && u.Password == user.Password).Select(u => new User()
            {
                Login = u.Login,
                Password = u.Password,
                Role = new Role()
                {
                    Name = u.Role.Name
                }
            }).SingleOrDefault();
            return user;
        }

        public User CheckGoogleUser(User user)
        {
            user = _context.Users.Where(u => u.Login == user.Login && u.Password == "0").Select(u => new User()
            {
                Login = u.Login,
                Password = u.Password,
                Role = new Role()
                {
                    Name = u.Role.Name
                }
            }).SingleOrDefault();
            return user;
        }

        public User FillUser(User user)
        {
            user.FavHeadphones = _context.UserHeadphones.Where(u => u.User.Login == user.Login).Select(h => new Headphones()
            {
                Name = h.Headphones.Name,
                MinFrequency = h.Headphones.MinFrequency,
                MaxFrequency = h.Headphones.MaxFrequency,
                Picture = h.Headphones.Picture,
                Company = new Company()
                {
                    Name = h.Headphones.Company.Name
                },
                Design = new Design()
                {
                    Name = h.Headphones.Design.Name
                }
            }).ToList();
            return user;
        }

        public IEnumerable<SmallUser> GetSmallOtherUsers(string login) 
        {
            var users = _context.Users.Where(u => u.Login != login).Select(u => new SmallUser()
            {
                Login = u.Login,
                Role = new Role()
                {
                    Name = u.Role.Name
                }
            });
            return users;
        }

        public bool TryAdd(User user)
        {
            if(!_context.Users.Any(u => u.Login == user.Login))
            {
                try
                {
                    var dbuser = new Models.DataModels.User()
                    {
                        Login = user.Login,
                        Password = user.Password,
                        RoleId = _context.Roles.Where(r => r.Name == user.Role.Name).SingleOrDefault().Id
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

        public void Update(User user)
        {
            var heads = _context.UserHeadphones.Where(h => h.User.Login == user.Login && !user.FavHeadphones.Any(f => f.Name == h.Headphones.Name));
            _context.RemoveRange(heads);
        }

        public void Update(IEnumerable<SmallUser> users)
        {
            var us = _context.Users.Where(u => !users.Any(x => x.Login == u.Login));

            _context.RemoveRange(us);

            foreach(var u in users)
            {
                var duser = _context.Users.Where(x => x.Login == u.Login && x.Role.Name != u.Role.Name).Single();
                duser.Role = null;
                duser.RoleId = _context.Roles.Where(x => x.Name == u.Role.Name).Single().Id;
            }
            
        }        
    }
}
