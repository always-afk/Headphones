using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using SmallUser = HeadphonesShop.BusinessLogic.Models.LogicModels.SmallUser;

namespace HeadphonesShop.PresentationWebMVC.Models.ViewModels
{
    public class AllUsersViewModel
    {
        public List<SmallUser> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
