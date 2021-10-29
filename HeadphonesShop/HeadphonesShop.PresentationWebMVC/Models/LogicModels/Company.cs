using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HeadphonesShop.PresentationWebMVC.Models.LogicModels
{
    public partial class Company
    {
        [Required]
        [MaxLength(31)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
