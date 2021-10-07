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
            //var us = from u in _context.Users
            //         join con in _context.UserHeadphones on u.Id equals con.UserId
            //         join head in _context.Headphones on con.HeadphonesId equals head.Id
            //         select u;
            var us = _context.Users.Include(u => u.Role).ToList().Select(u => new User
            {
                Login = u.Login,
                Password = u.Password,
                Role = new Role(){
                   Name = u.Role.Name
                },
                FavHeadphones = _context.Headphones.Where(h => _context.UserHeadphones
                                                        .Where(con => con.UserId == u.Id)
                                                        .Any(con => con.HeadphonesId == h.Id))
                                                   .Include(h => h.Design)
                                                   .Include(h => h.Company)
                                                   .ToList()
                                                   .Select(h => new Headphones()
                                                   {
                                                       Name = h.Name,
                                                       MinFrequency = h.MinFrequency,
                                                       MaxFrequency = h.MaxFrequency,
                                                       Picture  = h.Picture,
                                                       Company = new Company()
                                                       {
                                                           Name = h.Company.Name
                                                       },
                                                       Design = new Design()
                                                       {
                                                           Name = h.Design.Name
                                                       }
                                                   })
                                                   .ToList()
            }).ToList();
            

            //foreach(var user in _context.Users.Include(u => u.Role))
            //{
                
            //    users.Add(_mapper.ToUser(user));
            //}
            return us;
        }

        public IEnumerable<User> GetOtherUsers(User user)
        {
            //var users = new List<User>();
            //foreach(var us in _context.Users.Where(u => u.Login != user.Login))
            //{
            //    users.Add(_mapper.ToUser(us));
            //}
            var param = new Microsoft.Data.SqlClient.SqlParameter("@login", user.Login);
            var users = _context.Users.FromSqlRaw("GetOtherUsersProc @login", param).ToList().Select(u => new User()
            {
                Login = u.Login
            });
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

        public void Update(User user)
        {
            var userId = _context.Users.Where(u => u.Login == user.Login).FirstOrDefault().Id;

            //foreach(var headphones in user.FavHeadphones)
            //{
            //    var headId = _context.Headphones.Where(h => h.Name == headphones.Name).FirstOrDefault().Id;
            //    if(!_context.UserHeadphones.Any(x => x.UserId == userId && x.HeadphonesId == headId))
            //    {
            //        var elem = new Models.UserHeadphone()
            //        {
            //            HeadphonesId = headId,
            //            UserId = userId
            //        };
            //    }
            //}

            var heads = _context.Headphones.ToList();
            var hu = _context.UserHeadphones.ToList();

            foreach (var headphones in heads)
            {
                if(user.FavHeadphones.Any(h => h.Name == headphones.Name) && 
                    !hu.Any(x => x.UserId == userId && x.HeadphonesId == headphones.Id))
                {
                    
                    var elem = new Models.UserHeadphone()
                    {
                        HeadphonesId = headphones.Id,
                        UserId = userId
                    };
                    _context.UserHeadphones.Add(elem);
                    
                }
                else if (!user.FavHeadphones.Any(h => h.Name == headphones.Name) &&
                    hu.Any(x => x.UserId == userId && x.HeadphonesId == headphones.Id))
                {
                    var elem = hu.Where(x => x.UserId == userId && x.HeadphonesId == headphones.Id).FirstOrDefault();
                    _context.UserHeadphones.Remove(elem);
                }
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
