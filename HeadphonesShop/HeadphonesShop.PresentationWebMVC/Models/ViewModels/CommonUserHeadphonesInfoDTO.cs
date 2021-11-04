using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Models.DTO
{
    public class CommonUserHeadphonesInfoDTO
    {
        public Headphones Headphones { get; set; }
        public bool IsFavourite { get; set; }
    }
}
