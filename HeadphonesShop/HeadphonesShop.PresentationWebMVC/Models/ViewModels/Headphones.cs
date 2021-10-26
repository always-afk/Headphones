using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.PresentationWebMVC.Models.ViewModels
{
    public partial class Headphones
    {
        public string Name { get; set; }
        public double? MinFrequency { get; set; }
        public double? MaxFrequency { get; set; }
        public string Picture { get; set; }

        public string Company { get; set; }
        public string Design { get; set; }
    }
}
