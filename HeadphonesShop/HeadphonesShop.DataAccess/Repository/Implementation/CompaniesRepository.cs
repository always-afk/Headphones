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
        private readonly IMapper _mapper;

        //public CompaniesRepository()
        //{
        //    _context = new HeadphonesDBContext();
        //    _commonMapper = new CommonMapper();
        //    _dataMapper = new DataMapper();
        //}
        public CompaniesRepository(HeadphonesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Add(Company company)
        {
            if(!_context.Companies.Any(c => c.Name == company.Name))
            {
                var comp = _mapper.ToCompany(company);
                _context.Companies.Add(comp);                
                return true;
            }
            return false;
        }

        public void Delete(Company company)
        {
            var comp = _context.Companies.Where(c => c.Name == company.Name).FirstOrDefault();
            _context.Companies.Remove(comp);            
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var companies = new List<Company>();
            foreach(var c in _context.Companies)
            {
                companies.Add(_mapper.ToCompany(c));
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
        }
    }
}
