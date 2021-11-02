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
        public bool TryAdd(Headphones headphones);

        public void Delete(Headphones headphones);

        public IEnumerable<Headphones> GetAllHeadphones();

        public void Update(Headphones headphones);
        public Headphones GetHeadphonesByName(string name);

    }
}
