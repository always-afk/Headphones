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
        public User CheckUser(User user);

        public User CheckGoogleUser(User user);

        public User FillUser(User user);

        public IEnumerable<SmallUser> GetSmallOtherUsers(string login);

        public bool TryAdd(User user);

        public void Update(User user);

        public void Update(IEnumerable<SmallUser> users);
    }
}
