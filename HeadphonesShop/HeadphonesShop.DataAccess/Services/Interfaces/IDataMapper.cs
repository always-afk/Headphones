using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common;

namespace HeadphonesShop.DataAccess.Services.Interfaces
{
    public interface IDataMapper
    {
        Models.User ToUser(Common.Entities.User user);
        Models.Company ToCompany(Common.Entities.Company company);
        Models.Design ToDesign(Common.Entities.Design design);
        Models.Headphone ToHeadphones(Common.Entities.Headphones headphones);
    }
}
