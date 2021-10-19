using HeadphonesShop.BusinessLogic.Models.LogicModels;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class DesignService : Interfaces.IDesignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DesignService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool TryAdd(Design design)
        {
            var des = _mapper.Map<Design, DataAccess.Models.LogicModels.Design>(design);
            if (_unitOfWork.DesignRepository.TryAdd(des))
            {
                _unitOfWork.Save();
                return true;
            }
            
            return false;            
        }

        public IEnumerable<Design> GetAllDesigns()
        {
            return _unitOfWork.DesignRepository.GetAllDesigns()
                .Select(d => _mapper.Map<DataAccess.Models.LogicModels.Design, Design>(d));
        }

        public void Save(IEnumerable<Design> designs)
        {
            var des = designs.Select(d => _mapper.Map<Design, DataAccess.Models.LogicModels.Design>(d));
            _unitOfWork.DesignRepository.Update(des);
            _unitOfWork.Save();
        }
    }
}
