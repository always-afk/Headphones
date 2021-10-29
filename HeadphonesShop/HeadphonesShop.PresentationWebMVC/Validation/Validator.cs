using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Validation
{
    public class Validator
    {
        public CompanyValidator companyValidator { get; set; }
        public DesignValidator designValidator { get; set; }
        public HeadphonesValidator headphonesValidator { get; set; }
    }
}
