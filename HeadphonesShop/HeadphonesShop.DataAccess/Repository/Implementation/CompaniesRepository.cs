using HeadphonesShop.DataAccess.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Context;


namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class CompaniesRepository : Interfaces.ICompaniesRepository
    {
        private readonly HeadphonesDBContext _context;

        public CompaniesRepository(HeadphonesDBContext context)
        {
            _context = context;
        }

        public bool TryAdd(Company company)
        {
            if(!_context.Companies.Any(c => c.Name == company.Name))
            {
                var comp = new Models.DataModels.Company()
                {
                    Name = company.Name
                };
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
            var companies = _context.Companies.Select(c => new Company()
            {
                Name = c.Name
            });
            return companies;
        }

        public void Update(IEnumerable<Company> companies)
        {
            var comp = _context.Companies.Where(c => !companies.Any(x => x.Name == c.Name));
            _context.RemoveRange(comp);
        }
    }
}
