using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Models.LogicModels;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IHeadphonesRepository
    {
        public bool TryAdd(HeadphonesModel headphones);

        public void Delete(HeadphonesModel headphones);

        public IEnumerable<HeadphonesModel> GetAllHeadphones();

        public void Update(HeadphonesModel headphones);
        public HeadphonesModel GetHeadphonesByName(string name);
        public void DeleteByName(string name);

    }
}
