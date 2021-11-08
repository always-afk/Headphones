using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Models.LogicModels;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IUsersRepository
    {
        public UserModel GetUser(UserModel user);

        public UserModel GetGoogleUser(UserModel user);

        public UserModel FillUser(UserModel user);

        public IEnumerable<SmallUserModel> GetSmallOtherUsers(string login);

        public bool TryAdd(UserModel user);

        public void Update(UserModel user);

        public void Update(IEnumerable<SmallUserModel> users);
        public void DeleteUser(string userEmail);

    }
}
