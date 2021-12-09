using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.PresentationWebAPI.Models.LogicModels;

namespace HeadphonesShop.PresentationWebAPI.Models.DTO
{
    public class CommonUserInfoHeadphonesDTO
    {
        public Headphones Headphones { get; set; }
        public bool IsFavorite { get; set; }
    }
}
