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
        public void DeleteHeadphonesByName(string name);
        public List<Headphones> GetFavoriteHeadphones(string userEmail);
        public bool IsFavorite(string userEmail, string headphonesName);

        public void UpdateHeadphonesStatus(string userEmail, string headphonesName, bool isFavorite);

        bool TryAdd(Headphones headphones);
        void Update(Headphones headphones);
        void Save(List<Headphones> headphones);
        void Delete(Headphones headphones);
    }
}
