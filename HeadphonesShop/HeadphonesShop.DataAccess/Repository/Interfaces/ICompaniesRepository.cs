using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface ICompaniesRepository
    {
        IEnumerable<Company> GetAllCompanies();
        bool Add(Company company);
        void Delete(Company company);
    }
}
