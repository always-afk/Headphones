using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebMVC.Models.DTO;
using AutoMapper;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly IHeadphonesService _headphonesService;
        private readonly IMapper _mapper;
        private AdminIndexDTO _indexDTO;
        //private readonly IAccountService _accountService;
        public AdminController(IHeadphonesService headphonesService, IMapper mapper)
        {
            _headphonesService = headphonesService;
            _mapper = mapper;
            _indexDTO = new AdminIndexDTO();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var heads = _headphonesService.GetAllHeadphones();
            _indexDTO.Headphones = heads.Select(h => _mapper.Map<Models.LogicModels.Headphones>(h)).ToList();
            return View(_indexDTO);
        }
        [HttpGet]
        public IActionResult AddHeadphones()
        {
            var headphonesDTO = new AddHeadphonesDTO();
            headphonesDTO.Headphones = new Models.LogicModels.Headphones();
            headphonesDTO.Companies = _headphonesService.GetAllCompanies().Select(h => _mapper.Map<Models.LogicModels.Company>(h)).ToList();
            headphonesDTO.Designs = _headphonesService.GetAllDesigns().Select(h => _mapper.Map<Models.LogicModels.Design>(h)).ToList();
            return View(headphonesDTO);
        }
        [HttpPost]
        public IActionResult AddHeadphones(AddHeadphonesDTO headphonesDTO)
        {
            return Ok();
        }
    }
}
