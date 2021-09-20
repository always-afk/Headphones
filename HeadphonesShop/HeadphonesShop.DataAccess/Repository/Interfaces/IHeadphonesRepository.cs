using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IHeadphonesRepository
    {
        IEnumerable<Headphones> GetAllHeadphones();
        bool Add(Headphones headphones);
        void Delete(Headphones headphones);
        void Update(Headphones headphones);
    }
}
