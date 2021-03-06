using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using FluentValidation;
using HeadphonesShop.PresentationWebMVC.Models.LogicModels;
using HeadphonesShop.PresentationWebMVC.Models.ViewModels;

namespace HeadphonesShop.PresentationWebMVC.Controllers
{
    [Authorize(Roles = Constants.Roles.Admin)]
    public class AdminController : Controller
    {
        private const string Image = "image";
        private const string Images = "images";
        private const string IndexStr = "Index";
        private const string AllUsersStr = "AllUsers";

        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IHeadphonesService _headphonesService;
        private readonly IUsersService _usersService;
        private readonly IFileWorker _fileWorker;
        private readonly IMapper _mapper;

        public AdminController(IHeadphonesService headphonesService, IUsersService usersService, IFileWorker fileWorker, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _headphonesService = headphonesService;
            _usersService = usersService;
            _fileWorker = fileWorker;
            _mapper = mapper;
            _appEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var indexViewModel = new AdminIndexViewModel();
            var heads = _headphonesService.GetAllHeadphones();
            indexViewModel.Headphones = heads.Select(h => _mapper.Map<Models.LogicModels.Headphones>(h)).ToList();
            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult AddHeadphones()
        {
            var headphonesViewModel = new AddHeadphonesViewModel();
            //headphonesViewModel.Headphones = new Models.ViewModels.Headphones();
            headphonesViewModel.Companies = _headphonesService.GetAllCompanies()
                .Select(h => _mapper.Map<Models.LogicModels.Company>(h)).ToList();
            headphonesViewModel.Designs = _headphonesService.GetAllDesigns()
                .Select(h => _mapper.Map<Models.LogicModels.Design>(h)).ToList();
            return View(headphonesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddHeadphones(AddHeadphonesViewModel headphonesViewModel)
        {
            if (ModelState.IsValid)
            {
                var heads = _mapper.Map<BusinessLogic.Models.LogicModels.Headphones>(headphonesViewModel.Headphones);
                var path = String.Empty;
                var folder = headphonesViewModel.Headphones.Name;

                if (headphonesViewModel.File is not null && headphonesViewModel.File.ContentType.StartsWith(Image))
                {
                    path = Path.Combine(_appEnvironment.WebRootPath, Images);
                    heads.Picture = Path.Combine(Images, headphonesViewModel.Headphones.Name, headphonesViewModel.File.FileName);
                }

                if (_headphonesService.TryAdd(heads) && headphonesViewModel.File is not null 
                                                     && headphonesViewModel.File.ContentType.StartsWith(Image))
                {
                    await using var memoryStream = new MemoryStream();
                    await headphonesViewModel.File.CopyToAsync(memoryStream);
                    _fileWorker.SaveToDiscInFolder(memoryStream, path, folder, headphonesViewModel.File.FileName);
                }
            }

            return RedirectToAction(IndexStr);
        }

        [HttpGet()]
        public IActionResult InfoHeadphones([FromQuery(Name = "name")] string name)
        {
            var headphonesViewModel = new InfoHeadphonesViewModel();
            var headphones = _headphonesService.GetHeadphonesByName(name);
            headphonesViewModel.Headphones = _mapper.Map<Models.LogicModels.Headphones>(headphones);
            headphonesViewModel.Companies = _headphonesService.GetAllCompanies()
                .Select(c => _mapper.Map<Models.LogicModels.Company>(c)).ToList();
            headphonesViewModel.Designs = _headphonesService.GetAllDesigns()
                .Select(d => _mapper.Map<Models.LogicModels.Design>(d)).ToList();
            return View(headphonesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHeadphones(InfoHeadphonesViewModel headphonesViewModel)
        {
            var head = _mapper.Map<BusinessLogic.Models.LogicModels.Headphones>(headphonesViewModel.Headphones);
            var folder = headphonesViewModel.Headphones.Name;

            if (headphonesViewModel.File is null)
            {
                _headphonesService.Update(head);
            }
            else
            {
                if (headphonesViewModel.File.ContentType.StartsWith(Image))
                {
                    var path = Path.Combine(_appEnvironment.WebRootPath, Images);
                    head.Picture = Path.Combine(Images, head.Name, headphonesViewModel.File.FileName);
                    await using (var memoryStream = new MemoryStream())
                    {
                        await headphonesViewModel.File.CopyToAsync(memoryStream);
                        _fileWorker.SaveToDiscInFolder(memoryStream, path, folder, headphonesViewModel.File.FileName);
                    }
                    _headphonesService.Update(head);
                }
            }

            return RedirectToAction(IndexStr);
        }

        [HttpGet]
        public IActionResult DeleteHeadphones([FromQuery(Name = "name")] string name)
        {
            _headphonesService.DeleteHeadphonesByName(name);

            return RedirectToAction(IndexStr);
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = new AllUsersViewModel()
            {
                Users = _usersService.GetOtherUsers(User.Claims.ElementAt(0).Value).Select(u => _mapper.Map<SmallUser>(u)).ToList(),
                Roles = _usersService.GetAllRoles().Select(r => _mapper.Map<Role>(r))
            };
            return View(users);
        }

        public IActionResult UpdateAllUsers(AllUsersViewModel allUsersViewModel)
        {
            var usersToUpdate = allUsersViewModel.Users
                .Select(u => _mapper.Map<BusinessLogic.Models.LogicModels.SmallUser>(u));
            _usersService.Update(usersToUpdate);
            return RedirectToAction(IndexStr);
        }

        public IActionResult DeleteUser([FromQuery(Name = "name")] string userEmail)
        {
            _usersService.DeleteUser(userEmail);
            return RedirectToAction(AllUsersStr);
        }
    }
}
