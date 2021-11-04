using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.DataAccess.Models.LogicModels
{
    public partial class HeadphonesModel
    {
        public string Name { get; set; }
        public double? MinFrequency { get; set; }
        public double? MaxFrequency { get; set; }
        public string Picture { get; set; }

        public CompanyModel Company { get; set; }
        public DesignModel Design { get; set; }
    }
}
