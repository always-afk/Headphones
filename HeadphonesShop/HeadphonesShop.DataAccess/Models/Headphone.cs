using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.DataAccess.Models
{
    public partial class Headphone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? MinFrequency { get; set; }
        public double? MaxFrequency { get; set; }
        public string Picture { get; set; }
        public int? CompanyId { get; set; }
        public int? DesignId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Design Design { get; set; }
    }
}
