using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Models.ViewModel
{
    public class InfoHeadphonesViewModel
    {
        public Headphones Headphones { get; set; }
        public IFormFile File { get; set; }
        public List<Company> Companies { get; set; }
        public List<Design> Designs { get; set; }
    }
}
