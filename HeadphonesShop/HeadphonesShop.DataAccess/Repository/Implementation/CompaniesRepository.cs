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

        //public CompaniesRepository()
        //{
        //    _context = new HeadphonesDBContext();
        //    _commonMapper = new CommonMapper();
        //    _dataMapper = new DataMapper();
        //}
        public CompaniesRepository(HeadphonesDBContext context, ICommonMapper commonMapper, IDataMapper dataMapper)
        {
            _context = context;
            _commonMapper = commonMapper;
            _dataMapper = dataMapper;
        }

        public bool Add(Company company)
        {
            if(!_context.Companies.Any(c => c.Name == company.Name))
            {
                var comp = _dataMapper.ToCompany(company);
                _context.Companies.Add(comp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(Company company)
        {
            var comp = _context.Companies.Where(c => c.Name == company.Name).FirstOrDefault();
            _context.Companies.Remove(comp);
            _context.SaveChanges();
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

        public void Update(IEnumerable<Company> companies)
        {
            foreach(var company in _context.Companies)
            {
                var comp = companies.Where(c => c.Name == company.Name).FirstOrDefault();
                if(comp is null)
                {
                    _context.Remove(company);
                }
            }
            _context.SaveChanges();
        }
    }
}
