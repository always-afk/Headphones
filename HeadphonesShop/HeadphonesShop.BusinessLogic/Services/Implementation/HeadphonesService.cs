using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Repository.Implementation;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class HeadphonesService : Interfaces.IHeadphonesService
    {
        private readonly IUnitOfWorkHeadphones _unitOfWork;
        public HeadphonesService()
        {
            _unitOfWork = new UnitOfWorkHeadphones();
        }

        public bool Add(Headphones headphones)
        {
            if(_unitOfWork.HeadphonesRepository.Add(headphones))
            {
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Company> GetAllCompanies()
        {
            return _unitOfWork.CompaniesRepository.GetAllCompanies().ToList();
        }

        public List<Design> GetAllDesigns()
        {
            return _unitOfWork.DesignRepository.GetAllDesigns().ToList();
        }

        public List<Headphones> GetAllHeadphones()
        {
            return _unitOfWork.HeadphonesRepository.GetAllHeadphones().ToList();
        }

        public void Save(List<Headphones> headphones)
        {
            throw new NotImplementedException();
        }

        public bool Update(Headphones headphones)
        {
            throw new NotImplementedException();
        }
    }
}
