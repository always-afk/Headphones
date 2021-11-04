using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Models.LogicModels
{
    public class SmallUserModel
    {
        public string Login { get; set; }

        public RoleModel Role { get; set; }
    }
}
