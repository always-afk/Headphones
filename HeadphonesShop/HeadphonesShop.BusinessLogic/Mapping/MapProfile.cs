using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HeadphonesShop.DataAccess.Models.LogicModels;

namespace HeadphonesShop.BusinessLogic.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //BLL to DAL
            CreateMap<CompanyModel, Models.LogicModels.Company>()
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name));

            CreateMap<DesignModel, Models.LogicModels.Design>()
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Name));

            CreateMap<HeadphonesModel, Models.LogicModels.Headphones>()
                .ForMember(x => x.Name, opt => opt.MapFrom(h => h.Name))
                .ForMember(x => x.MinFrequency, opt => opt.MapFrom(h => h.MinFrequency))
                .ForMember(x => x.MaxFrequency, opt => opt.MapFrom(h => h.MaxFrequency))
                .ForMember(x => x.Picture, opt => opt.MapFrom(h => h.Picture))
                .ForMember(x => x.Company, opt => opt.MapFrom(h => h.Company))
                .ForMember(x => x.Design, opt => opt.MapFrom(h => h.Design));

            CreateMap<RoleModel, Models.LogicModels.Role>()
                .ForMember(x => x.Name, opt => opt.MapFrom(r => r.Name));

            CreateMap<SmallUserModel, Models.LogicModels.SmallUser>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role));

            CreateMap<UserModel, Models.LogicModels.User>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role))
                .ForMember(x => x.FavHeadphones, opt => opt.MapFrom(u => u.FavHeadphones));

            //DAL to BLL
            CreateMap<Models.LogicModels.Company, CompanyModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name));

            CreateMap<Models.LogicModels.Design, DesignModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Name));

            CreateMap<Models.LogicModels.Headphones, HeadphonesModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(h => h.Name))
                .ForMember(x => x.MinFrequency, opt => opt.MapFrom(h => h.MinFrequency))
                .ForMember(x => x.MaxFrequency, opt => opt.MapFrom(h => h.MaxFrequency))
                .ForMember(x => x.Picture, opt => opt.MapFrom(h => h.Picture))
                .ForMember(x => x.Company, opt => opt.MapFrom(h => h.Company))
                .ForMember(x => x.Design, opt => opt.MapFrom(h => h.Design));

            CreateMap<Models.LogicModels.Role, RoleModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(r => r.Name));

            CreateMap<Models.LogicModels.SmallUser, SmallUserModel>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role));

            CreateMap<Models.LogicModels.User, UserModel>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role))
                .ForMember(x => x.FavHeadphones, opt => opt.MapFrom(u => u.FavHeadphones));
        }
    }
}
