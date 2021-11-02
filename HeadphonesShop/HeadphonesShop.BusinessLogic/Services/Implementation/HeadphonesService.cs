using HeadphonesShop.BusinessLogic.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Repository.Implementation;
using AutoMapper;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class HeadphonesService : Interfaces.IHeadphonesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HeadphonesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool TryAdd(Headphones headphones)
        {
            var head = _mapper.Map<Headphones, DataAccess.Models.LogicModels.Headphones>(headphones);
            if(_unitOfWork.HeadphonesRepository.TryAdd(head))
            {
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(Headphones headphones)
        {
            var head = _mapper.Map<Headphones, DataAccess.Models.LogicModels.Headphones>(headphones);
            _unitOfWork.HeadphonesRepository.Delete(head);
            _unitOfWork.Save();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _unitOfWork.CompaniesRepository.GetAllCompanies()
                .Select(c => _mapper.Map<DataAccess.Models.LogicModels.Company, Company>(c));
        }

        public IEnumerable<Design> GetAllDesigns()
        {
            return _unitOfWork.DesignRepository.GetAllDesigns()
                .Select(d => _mapper.Map<DataAccess.Models.LogicModels.Design, Design>(d));
        }

        public IEnumerable<Headphones> GetAllHeadphones()
        {
            return _unitOfWork.HeadphonesRepository.GetAllHeadphones()
                .Select(h => _mapper.Map<DataAccess.Models.LogicModels.Headphones, Headphones>(h));
        }

        public void Save(List<Headphones> headphones)
        {
            throw new NotImplementedException();
        }

        public void Update(Headphones headphones)
        {
            var head = _mapper.Map<Headphones, DataAccess.Models.LogicModels.Headphones>(headphones);
            _unitOfWork.HeadphonesRepository.Update(head);
            _unitOfWork.Save();
        }

        public Headphones GetHeadphonesByName(string name)
        {
            var res = _mapper.Map<Headphones>(_unitOfWork.HeadphonesRepository.GetHeadphonesByName(name));
            return res;
        }
    }
}
