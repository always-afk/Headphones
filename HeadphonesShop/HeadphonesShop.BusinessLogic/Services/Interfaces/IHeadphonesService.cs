using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface IHeadphonesService
    {
        List<Headphones> GetAllHeadphones();
        List<Company> GetAllCompanies();
        List<Design> GetAllDesigns();
        bool Add(Headphones headphones);
        bool Update(Headphones headphones);
        void Save(List<Headphones> headphones);
    }
}
