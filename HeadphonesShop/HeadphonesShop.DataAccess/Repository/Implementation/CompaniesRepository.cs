using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Services.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;


namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class CompaniesRepository : Interfaces.ICompaniesRepository
    {
        private readonly HeadphonesDBContext _context;
        private readonly ICommonMapper _commonMapper;
        private readonly IDataMapper _dataMapper;

        public CompaniesRepository()
        {
            _context = new HeadphonesDBContext();
            _commonMapper = new CommonMapper();
            _dataMapper = new DataMapper();
        }

        public CompaniesRepository(HeadphonesDBContext context, ICommonMapper commonMapper, IDataMapper dataMapper)
        {
            _context = context;
            _commonMapper = commonMapper;
            _dataMapper = dataMapper;
        }

        public bool Add(Company company)
        {
            throw new NotImplementedException();
        }

        public void Delete(Company company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var companies = new List<Company>();
            foreach(var c in _context.Companies)
            {
                companies.Add(_commonMapper.ToCompany(c));
            }
            return companies;
        }
    }
}
