using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Services.Implementation
{
    public class DataMapper : Interfaces.IDataMapper
    {
        public Models.Company ToCompany(Common.Entities.Company company)
        {
            return new Models.Company()
            {
                Name = company.Name
            };
        }

        public Models.Design ToDesign(Common.Entities.Design design)
        {
            return new Models.Design()
            {
                Name = design.Name
            };
        }

        public Headphone ToHeadphones(Headphones headphones)
        {
            return new Headphone()
            {
                Name = headphones.Name,
                MaxFrequency = headphones.MaxFrequency,
                MinFrequency = headphones.MinFrequency,
                Picture = headphones.Picture,
                Design = ToDesign(headphones.Design),
                Company = ToCompany(headphones.Company)
            };
        }

        public Models.User ToUser(Common.Entities.User user)
        {
            return new Models.User()
            {
                Login = user.Login,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
