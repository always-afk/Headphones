using FluentValidation;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Validation
{
    public class HeadphonesValidator : AbstractValidator<Headphones>
    {
        public HeadphonesValidator()
        {
            RuleFor(h => h.Name).NotNull().Length(3, 127);
            RuleFor(h => h.MinFrequency).LessThan(h => h.MaxFrequency).GreaterThan(0);
            RuleFor(h => h.MaxFrequency).GreaterThan(0);
            RuleFor(h => h.Picture).Null().Length(5, 255);
            RuleFor(h => h.Design).SetValidator(new DesignValidator());
            RuleFor(h => h.Company).SetValidator(new CompanyValidator());
        }
    }
}
