using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.Common.Entities
{
    public class Headphones
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Design Design { get; set; }
        public double? MinFrequency { get; set; }
        public double? MaxFrequency { get; set; }
        public string Picture { get; set; }
    }
}
