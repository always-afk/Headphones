using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.PresentationWebAPI.Models.DTO;
using HeadphonesShop.PresentationWebAPI.Models.LogicModels;
using HeadphonesShop.PresentationWebAPI.Services.Interface;
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
        private readonly INavigationService _navigationService;
        private readonly IMapper _mapper;
        public AdminController(IHeadphonesService headphonesService, INavigationService navigationService, IMapper mapper)
        {
            _headphonesService = headphonesService;
            _navigationService = navigationService;
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
            var headphonesName = HttpUtility.UrlDecode(name);
            var adminInfoHeadphonesDTO = new AdminInfoHeadphonesDTO()
            {
                Headphones = _mapper.Map<Headphones>(_headphonesService.GetHeadphonesByName(headphonesName)),
                Companies = _headphonesService.GetAllCompanies().Select(c => _mapper.Map<Company>(c)).ToList(),
                Designs = _headphonesService.GetAllDesigns().Select(d => _mapper.Map<Design>(d)).ToList()
            };

            return Ok(adminInfoHeadphonesDTO);
        }

        [HttpGet]
        public IActionResult GetAddHeadphones()
        {
            var addHeadphonesDTO = new AdminAddHeadphonesDTO()
            {
                Companies = _headphonesService.GetAllCompanies().Select(c => _mapper.Map<Company>(c)).ToList(),
                Designs = _headphonesService.GetAllDesigns().Select(d => _mapper.Map<Design>(d)).ToList()
            };

            return Ok(addHeadphonesDTO);
        }

        [HttpPost]
        public IActionResult AddHeadphones([FromBody] Headphones headphones)
        {
            var headphonesModel = _mapper.Map<BusinessLogic.Models.LogicModels.Headphones>(headphones);
            if (!_headphonesService.TryAdd(headphonesModel))
            {
                return BadRequest();
            }
            var redirect = _navigationService.NavigateByRole(User.FindFirst(ClaimTypes.Role)?.Value);
            return Ok(redirect);
        }

        [HttpPut]
        public IActionResult UpdateHeadphones([FromBody] Headphones headphones)
        {
            var headphonesModel = _mapper.Map<BusinessLogic.Models.LogicModels.Headphones>(headphones);
            _headphonesService.Update(headphonesModel);
            var redirect = _navigationService.NavigateByRole(User.FindFirst(ClaimTypes.Role)?.Value);
            return Ok(redirect);
        }

        [HttpDelete]
        public IActionResult DeleteHeadphones([FromBody] string headphonesName)
        {
            _headphonesService.DeleteHeadphonesByName(headphonesName);
            var redirect = _navigationService.NavigateByRole(User.FindFirst(ClaimTypes.Role)?.Value);
            return Ok(redirect);
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
