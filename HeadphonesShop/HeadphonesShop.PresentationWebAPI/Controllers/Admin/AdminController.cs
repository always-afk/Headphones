using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebAPI.Models.DTO;
using HeadphonesShop.PresentationWebAPI.Models.LogicModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeadphonesShop.PresentationWebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly IHeadphonesService _headphonesService;
        private readonly IMapper _mapper;
        public AdminController(IHeadphonesService headphonesService, IMapper mapper)
        {
            _headphonesService = headphonesService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllHeadphones()
        {
            var adminAllHeadphonesDTO = new AdminAllHeadphonesDTO()
            {
                Headphones = _headphonesService.GetAllHeadphones().Select(h => _mapper.Map<Headphones>(h)).ToList()
            };

            return Ok(adminAllHeadphonesDTO);
        }

        [HttpGet]
        public IActionResult GetHeadphones([FromQuery(Name = "name")]string name)
        {
            var adminInfoHeadphonesDTO = new AdminInfoHeadphonesDTO()
            {
                Headphones = _mapper.Map<Headphones>(_headphonesService.GetHeadphonesByName(name))
            };

            return Ok(adminInfoHeadphonesDTO);
        }

        [HttpGet]
        public IEnumerable<string> GetUsers()
        {
            return new List<string>()
            {
                "123",
                "321"
            };
        }
    }
}
