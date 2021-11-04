using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebMVC.Models.ViewModel;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    [Authorize(Roles ="common user")]
    public class CommonUserController : Controller
    {
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
                Headphones = _headphonesService.GetAllHeadphones().Select(h => _mapper.Map<Headphones>(h)).ToList()
            };
            return View(indexViewModel);
        }

        public IActionResult InfoHeadphones([FromQuery(Name = "name")] string name)
        {
            var headphonesViewModel = new CommonUserHeadphonesInfoViewModel();
            var headphones = _headphonesService.GetHeadphonesByName(name);
            headphonesViewModel.Headphones = _mapper.Map<Headphones>(headphones);
            headphonesViewModel.IsFavorite = _headphonesService.GetFavoriteHeadphones(User.Claims.ElementAt(0).Value)
                .Any(h => h.Name == headphones.Name);
            return View(headphonesViewModel);
        }

        public IActionResult UpdateHeadphones([FromQuery(Name = "name")] string headphonesName, [FromQuery(Name = "IsFavorite")] bool isFavorite)
        {
            _headphonesService.UpdateHeadphonesStatus(User.Claims.ElementAt(0).Value, headphonesName, isFavorite);
            return RedirectToAction("Index");
        }
    }
}
