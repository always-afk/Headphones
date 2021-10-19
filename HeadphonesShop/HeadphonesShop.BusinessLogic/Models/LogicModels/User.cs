using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.BusinessLogic.Models.LogicModels
{
    public partial class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
        public List<Headphones> FavHeadphones { get; set; }
    }
}
