using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.PresentationWebAPI.Models.LogicModels;

namespace HeadphonesShop.PresentationWebAPI.Models.DTO
{
    public class AdminInfoHeadphonesDTO
    {
        public Headphones Headphones { get; set; }
        public List<Company> Companies { get; set; }
        public List<Design> Designs { get; set; }
    }
}
