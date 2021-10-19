using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.DataAccess.Models.DataModels
{
    public partial class User
    {
        public User()
        {
            UserHeadphones = new HashSet<UserHeadphone>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<UserHeadphone> UserHeadphones { get; set; }
    }
}
