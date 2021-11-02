using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebMVC.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using FluentValidation;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IWebHostEnvironment _appEnvironment;
        private readonly IHeadphonesService _headphonesService;
        private readonly IFileWorker _fileWorker;
        private readonly IMapper _mapper;
        private AdminIndexDTO _indexDTO;
        //private readonly IAccountService _accountService;
        public AdminController(IHeadphonesService headphonesService, IFileWorker fileWorker, 
            IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _headphonesService = headphonesService;
            _fileWorker = fileWorker;
            _mapper = mapper;
            _appEnvironment = hostEnvironment;
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
            //headphonesDTO.Headphones = new Models.ViewModels.Headphones();
            headphonesDTO.Companies = _headphonesService.GetAllCompanies()
                .Select(h => _mapper.Map<Models.LogicModels.Company>(h)).ToList();
            headphonesDTO.Designs = _headphonesService.GetAllDesigns()
                .Select(h => _mapper.Map<Models.LogicModels.Design>(h)).ToList();
            return View(headphonesDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddHeadphones(AddHeadphonesDTO headphonesDTO)
        {
            if (ModelState.IsValid)
            {
                var heads = _mapper.Map<BusinessLogic.Models.LogicModels.Headphones>(headphonesDTO.Headphones);
                var path = "";
                var folder = headphonesDTO.Headphones.Name;
                if (headphonesDTO.File is not null && headphonesDTO.File.ContentType.StartsWith("image"))
                {
                    var partpath = "/images/";
                    path = _appEnvironment.WebRootPath + partpath;
                    heads.Picture = "~" + partpath;
                }

                if (_headphonesService.TryAdd(heads))
                {
                    if (headphonesDTO.File is not null && headphonesDTO.File.ContentType.StartsWith("image"))
                    {
                        using (var mem = new MemoryStream())
                        {
                            await headphonesDTO.File.CopyToAsync(mem);
                            _fileWorker.SaveToDiscInFolder(mem, path, folder);
                        }
                    }
                }
            }
                        
            
            return Redirect("~/Admin/Index");
        }
        [HttpGet()]
        public IActionResult InfoHeadphones([FromQuery(Name = "name")] string name)
        {
            var dto = new InfoHeadphonesDTO();
            var h = _headphonesService.GetHeadphonesByName(name);
            dto.Headphones = _mapper.Map<Models.LogicModels.Headphones>(h);
            return View(dto);
        }
    }
}
