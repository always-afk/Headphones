using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Services.Intedaces
{
    public interface IValidationService
    {
        public bool ValidateHeadphones(Headphones headphones);
        public bool ValidateCompany(Company company);
        public bool ValidateDesign(Design design);
        public bool ValidateUser(User user);
    }
}
