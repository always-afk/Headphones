using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HeadphonesShop.PresentationWebMVC.Models.LogicModels
{
    public partial class Headphones
    {
        [Required]
        [MaxLength(127)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [Range(0, 999999)]
        public double? MinFrequency { get; set; }
        [Required]
        [Range(0, 999999)]
        public double? MaxFrequency { get; set; }
        public string Picture { get; set; }

        [Required]
        public Company Company { get; set; }
        [Required]
        public Design Design { get; set; }
    }
}
