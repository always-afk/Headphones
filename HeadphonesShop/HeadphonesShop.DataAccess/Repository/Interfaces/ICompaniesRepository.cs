using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Models.LogicModels;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface ICompaniesRepository
    {
        public bool TryAdd(Company company);

        public void Delete(Company company);

        public IEnumerable<Company> GetAllCompanies();

        public void Update(IEnumerable<Company> companies);
    }
}
