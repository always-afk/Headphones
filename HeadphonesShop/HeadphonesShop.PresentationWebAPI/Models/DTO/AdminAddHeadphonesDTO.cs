using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.PresentationWebAPI.Models.LogicModels;

namespace HeadphonesShop.PresentationWebAPI.Models.DTO
{
    public class AdminAddHeadphonesDTO
    {
        public List<Company> Companies { get; set; }
        public List<Design> Designs { get; set; }
    }
}
