using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.DataAccess.Services.Interfaces
{
    public interface IMapper
    {
        //Common to data
        Models.User ToUser(User user);
        Models.Headphone ToHeadphones(Headphones headphones);
        Models.Design ToDesign(Design design);
        Models.Company ToCompany(Company company);

        //Data to common
        User ToUser(Models.User user);
        Headphones ToHeadphones(Models.Headphone headphone);
        Design ToDesign(Models.Design design);
        Company ToCompany(Models.Company company);
    }
}
