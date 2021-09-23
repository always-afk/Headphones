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
        private readonly IUnitOfWorkHeadphones _unitOfWork;
        public CompanyService(IUnitOfWorkHeadphones unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Add(Company company)
        {
            return _unitOfWork.CompaniesRepository.Add(company);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _unitOfWork.CompaniesRepository.GetAllCompanies();
        }

        public void Save(IEnumerable<Company> companies)
        {
            _unitOfWork.CompaniesRepository.Update(companies);
        }
    }
}
