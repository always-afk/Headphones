using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HeadphonesShop.PresentationWebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    [Authorize(Roles = Constants.Roles.CommonUser)]
    public class CommonUserController : Controller
    {
        private const string IndexStr = "Index";

        private readonly IHeadphonesService _headphonesService;
        private readonly IMapper _mapper;

        public CommonUserController(IHeadphonesService headphonesService, IMapper mapper)
        {
            _headphonesService = headphonesService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var indexViewModel = new CommonUserIndexViewModel
            {
                Headphones = _headphonesService.GetAllHeadphones().Select(h => _mapper.Map<BusinessLogic.Models.LogicModels.Headphones, Headphones>(h)).ToList()
            };

            return View(indexViewModel);
        }

        public IActionResult InfoHeadphones([FromQuery(Name = "name")] string name)
        {
            var headphonesViewModel = new CommonUserHeadphonesInfoViewModel();
            var headphones = _headphonesService.GetHeadphonesByName(name);
            headphonesViewModel.Headphones = _mapper.Map<Headphones>(headphones);
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (userEmail is null)
            {
                return RedirectToAction(IndexStr);
            }

            headphonesViewModel.IsFavorite = _headphonesService.IsFavorite(userEmail, headphones.Name);
            return View(headphonesViewModel);
        }

        public IActionResult UpdateHeadphones([FromQuery(Name = "name")] string headphonesName, [FromQuery(Name = "IsFavorite")] bool isFavorite)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (userEmail is null)
            {
                return RedirectToAction(IndexStr);
            }

            _headphonesService.UpdateHeadphonesStatus(userEmail, headphonesName, isFavorite);
            return RedirectToAction(IndexStr);
        }
    }
}
