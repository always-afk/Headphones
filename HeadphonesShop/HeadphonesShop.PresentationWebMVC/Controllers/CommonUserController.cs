using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebMVC.Models.DTO;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var dto = new CommonUserIndexDTO();
            dto.Headphones = _headphonesService.GetAllHeadphones().Select(h => _mapper.Map<Headphones>(h)).ToList();
            return View(dto);
        }
        public IActionResult InfoHeadphones([FromQuery(Name = "name")] string name)
        {
            return Ok();
        }
    }
}
