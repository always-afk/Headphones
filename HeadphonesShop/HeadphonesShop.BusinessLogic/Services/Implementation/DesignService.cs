using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class DesignService : Interfaces.IDesignService
    {
        private readonly IUnitOfWorkHeadphones _unitOfWork;
        public DesignService(IUnitOfWorkHeadphones unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Add(Design designy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Design> GetAllDesigns()
        {
            return _unitOfWork.DesignRepository.GetAllDesigns().ToList();
        }

        public void Save(IEnumerable<Design> designs)
        {
            throw new NotImplementedException();
        }
    }
}
