using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common;

namespace HeadphonesShop.DataAccess.Services.Interfaces
{
    public interface ICommonMapper
    {
        Common.Entities.User ToUser(Models.User user);
        Common.Entities.Company ToCompany(Models.Company company);
        Common.Entities.Design ToDesign(Models.Design design);
        Common.Entities.Headphones ToHeadphones(Models.Headphone headphones);
    }
}
