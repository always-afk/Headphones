using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebAPI.Models.DTO;
using HeadphonesShop.PresentationWebAPI.Models.LogicModels;
using HeadphonesShop.PresentationWebAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace HeadphonesShop.PresentationWebAPI.Controllers.CommonUser
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "common user")]

    public class CommonUserController : ControllerBase
    {
        private readonly IHeadphonesService _headphonesService;
        private readonly INavigationService _navigationService;
        private readonly IMapper _mapper;
        public CommonUserController(IHeadphonesService headphonesService, INavigationService navigationService, IMapper mapper)
        {
            _headphonesService = headphonesService;
            _navigationService = navigationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllHeadphones()
        {
            var commonUserAllHeadphonesDTO = new CommonUserAllHeadphonesDTO()
            {
                Headphones = _headphonesService.GetAllHeadphones().Select(h => _mapper.Map<Headphones>(h)).ToList()
            };

            return Ok(commonUserAllHeadphonesDTO);
        }

        [HttpGet]
        public IActionResult GetHeadphones([FromQuery(Name = "name")] string name)
        {
            var headphonesName = HttpUtility.UrlDecode(name);
            var commonUserInfoHeadphonesDTO = new CommonUserInfoHeadphonesDTO()
            {
                Headphones = _mapper.Map<Headphones>(_headphonesService.GetHeadphonesByName(headphonesName)),
                IsFavorite = _headphonesService.IsFavorite(User.FindFirst(ClaimTypes.Email)?.Value, headphonesName)
            };

            return Ok(commonUserInfoHeadphonesDTO);
        }

        [HttpPost]
        public IActionResult ChangeFavorite([FromBody] CommonUserChangeFavoriteDTO changeFavoriteDTO)
        {
            _headphonesService.UpdateHeadphonesStatus(User.FindFirst(ClaimTypes.Email)?.Value, changeFavoriteDTO.Name, !changeFavoriteDTO.IsFavorite);
            return Ok();
        }
    }
}
