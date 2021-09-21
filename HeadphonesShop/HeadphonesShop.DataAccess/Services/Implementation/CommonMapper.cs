using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Services.Implementation
{
    public class CommonMapper : Interfaces.ICommonMapper
    {
        public Common.Entities.Company ToCompany(Models.Company company)
        {
            return new Common.Entities.Company()
            {
                Name = company.Name
            };
        }

        public Common.Entities.Design ToDesign(Models.Design design)
        {
            return new Common.Entities.Design()
            {
                Name = design.Name
            };
        }

        public Headphones ToHeadphones(Headphone headphones)
        {
            return new Headphones()
            {
                Name = headphones.Name,
                MaxFrequency = headphones.MaxFrequency,
                MinFrequency = headphones.MinFrequency,
                Picture = headphones.Picture,
                Design = ToDesign(headphones.Design),
                Company = ToCompany(headphones.Company)
            };
        }

        public Common.Entities.User ToUser(Models.User user)
        {
            return new Common.Entities.User()
            {
                Login = user.Login,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
