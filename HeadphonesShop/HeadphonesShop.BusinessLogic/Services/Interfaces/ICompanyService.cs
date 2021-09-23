using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        bool Add(Company company);
        void Save(IEnumerable<Company> companies);
    }
}
