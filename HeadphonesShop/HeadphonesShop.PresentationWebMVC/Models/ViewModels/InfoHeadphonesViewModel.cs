using System.Collections.Generic;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Http;

namespace HeadphonesShop.PresentationWebMVC.Models.ViewModels
{
    public class InfoHeadphonesViewModel
    {
        public Headphones Headphones { get; set; }
        public IFormFile File { get; set; }
        public List<Company> Companies { get; set; }
        public List<Design> Designs { get; set; }
    }
}
