using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.DataAccess.Models.LogicModels
{
    public partial class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public RoleModel Role { get; set; }
        public List<HeadphonesModel> FavHeadphones { get; set; }
    }
}
