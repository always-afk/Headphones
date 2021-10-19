using HeadphonesShop.BusinessLogic.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface IDesignService
    {
        IEnumerable<Design> GetAllDesigns();
        bool TryAdd(Design design);
        void Save(IEnumerable<Design> designs);
    }
}
