using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Models.LogicModels;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IDesignRepository
    {
        public bool TryAdd(Design design);

        public IEnumerable<Design> GetAllDesigns();

        public void Update(IEnumerable<Design> designs);
    }
}
