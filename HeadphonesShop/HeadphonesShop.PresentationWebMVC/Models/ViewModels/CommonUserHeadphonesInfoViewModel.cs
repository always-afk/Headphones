using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Models.ViewModel
{
    public class CommonUserHeadphonesInfoViewModel
    {
        public Headphones Headphones { get; set; }
        public bool IsFavorite { get; set; }
    }
}
