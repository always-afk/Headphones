using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IDesignRepository
    {
        IEnumerable<Design> GetAllDesigns();
        bool Add(Design design);
        void Delete(Design design);
    }
}
