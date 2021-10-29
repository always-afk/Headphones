using FluentValidation;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Validation
{
    public class DesignValidator : AbstractValidator<Design>
    {
        public DesignValidator()
        {
            RuleFor(d => d.Name).NotNull().NotEmpty().Length(3, 31);
        }
    }
}
