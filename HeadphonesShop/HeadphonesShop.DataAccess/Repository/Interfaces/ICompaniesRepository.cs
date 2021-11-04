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
        public bool TryAdd(CompanyModel company);

        public void Delete(CompanyModel company);

        public IEnumerable<CompanyModel> GetAllCompanies();

        public void Update(IEnumerable<CompanyModel> companies);
    }
}
