using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.BusinessLogic.Models.LogicModels;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface IHeadphonesService
    {
        IEnumerable<Headphones> GetAllHeadphones();
        IEnumerable<Company> GetAllCompanies();
        IEnumerable<Design> GetAllDesigns();
        public Headphones GetHeadphonesByName(string name);

        bool TryAdd(Headphones headphones);
        void Update(Headphones headphones);
        void Save(List<Headphones> headphones);
        void Delete(Headphones headphones);
    }
}
