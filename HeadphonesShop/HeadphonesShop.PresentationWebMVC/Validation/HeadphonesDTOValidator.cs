using FluentValidation;
using HeadphonesShop.PresentationWebMVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebMVC.Validation
{
    public class HeadphonesDTOValidator : AbstractValidator<AddHeadphonesDTO>
    {
        public HeadphonesDTOValidator()
        {
            RuleFor(x => x.Headphones).NotNull().SetValidator(new HeadphonesValidator());
            //RuleFor(x => x.File).Null().SetValidator(new ImageValidator());
        }
    }
}
