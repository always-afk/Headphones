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
    public class CompanyService : Interfaces.ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool TryAdd(Company company)
        {
            var comp = _mapper.Map<Company, DataAccess.Models.LogicModels.Company>(company);

            if (_unitOfWork.CompaniesRepository.TryAdd(comp))
            {
                _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _unitOfWork.CompaniesRepository.GetAllCompanies()
                .Select(c => _mapper.Map<DataAccess.Models.LogicModels.Company, Company>(c));
        }

        public void Save(IEnumerable<Company> companies)
        {
            var comp = companies.Select(c => _mapper.Map<Company, DataAccess.Models.LogicModels.Company>(c));
            _unitOfWork.CompaniesRepository.Update(comp);
            _unitOfWork.Save();
        }
    }
}
