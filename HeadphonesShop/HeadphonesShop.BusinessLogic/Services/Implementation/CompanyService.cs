using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class CompanyService : Interfaces.ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Add(Company company)
        {
            var res = _unitOfWork.CompaniesRepository.Add(company);
            if (res)
            {
                _unitOfWork.Save();
            }
            return res;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _unitOfWork.CompaniesRepository.GetAllCompanies();
        }

        public void Save(IEnumerable<Company> companies)
        {
            _unitOfWork.CompaniesRepository.Update(companies);
            _unitOfWork.Save();
        }
    }
}
