using FluentValidation;
using HeadphonesShop.PresentationWebMVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Validation
{
    public class HeadphonesViewModelValidator : AbstractValidator<AddHeadphonesViewModel>
    {
        public HeadphonesViewModelValidator()
        {
            RuleFor(x => x.Headphones).NotNull().SetValidator(new HeadphonesValidator());
            //RuleFor(x => x.File).Null().SetValidator(new ImageValidator());
        }
    }
}
