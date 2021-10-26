using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Models.DTO
{
    public class AddHeadphonesDTO
    {
        public Headphones Headphones { get; set; }
        public SelectList Companies { get; set; }
        public SelectList Designs { get; set; }
    }
}
