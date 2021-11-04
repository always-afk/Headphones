using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HeadphonesShop.BusinessLogic.Models.LogicModels;
using HeadphonesShop.PresentationWebMVC.Models.ViewModel;

namespace HeadphonesShop.PresentationWebMVC.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Pres to BLL
            CreateMap<Company, Models.LogicModels.Company>()
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name));

            CreateMap<Design, Models.LogicModels.Design>()
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Name));

            CreateMap<Headphones, Models.LogicModels.Headphones>()
                .ForMember(x => x.Name, opt => opt.MapFrom(h => h.Name))
                .ForMember(x => x.MinFrequency, opt => opt.MapFrom(h => h.MinFrequency))
                .ForMember(x => x.MaxFrequency, opt => opt.MapFrom(h => h.MaxFrequency))
                .ForMember(x => x.Picture, opt => opt.MapFrom(h => h.Picture))
                .ForMember(x => x.Company, opt => opt.MapFrom(h => h.Company))
                .ForMember(x => x.Design, opt => opt.MapFrom(h => h.Design));

            CreateMap<Role, Models.LogicModels.Role>()
                .ForMember(x => x.Name, opt => opt.MapFrom(r => r.Name));

            CreateMap<SmallUser, Models.LogicModels.SmallUser>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role));

            CreateMap<User, Models.LogicModels.User>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role))
                .ForMember(x => x.FavHeadphones, opt => opt.MapFrom(u => u.FavHeadphones));

            //BLL to Pres
            CreateMap<Models.LogicModels.Company, Company>()
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name));

            CreateMap<Models.LogicModels.Design, Design>()
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Name));

            CreateMap<Models.LogicModels.Headphones, Headphones>()
                .ForMember(x => x.Name, opt => opt.MapFrom(h => h.Name))
                .ForMember(x => x.MinFrequency, opt => opt.MapFrom(h => h.MinFrequency))
                .ForMember(x => x.MaxFrequency, opt => opt.MapFrom(h => h.MaxFrequency))
                .ForMember(x => x.Picture, opt => opt.MapFrom(h => h.Picture))
                .ForMember(x => x.Company, opt => opt.MapFrom(h => h.Company))
                .ForMember(x => x.Design, opt => opt.MapFrom(h => h.Design));

            CreateMap<Models.LogicModels.Role, Role>()
                .ForMember(x => x.Name, opt => opt.MapFrom(r => r.Name));

            CreateMap<Models.LogicModels.SmallUser, SmallUser>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role));

            CreateMap<Models.LogicModels.User, User>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(x => x.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(x => x.Role, opt => opt.MapFrom(u => u.Role))
                .ForMember(x => x.FavHeadphones, opt => opt.MapFrom(u => u.FavHeadphones));

            //ViewModel to BLL
            CreateMap<UserRegistrationViewModel, User>()
                .ForMember(x => x.Login, opt => opt.MapFrom(u => u.Email))
                .ForMember(x => x.Password, opt => opt.MapFrom(u => u.Password));
<<<<<<< HEAD

            ////Pres to View
            //CreateMap<Models.LogicModels.Headphones, Models.ViewModels.Headphones>()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(h => h.Name))
            //    .ForMember(x => x.MinFrequency, opt => opt.MapFrom(h => h.MinFrequency))
            //    .ForMember(x => x.MaxFrequency, opt => opt.MapFrom(h => h.MaxFrequency))
            //    .ForMember(x => x.Picture, opt => opt.MapFrom(h => h.Picture))
            //    .ForMember(x => x.Company, opt => opt.MapFrom(h => h.Company.Name))
            //    .ForMember(x => x.Design, opt => opt.MapFrom(h => h.Design.Name));

            ////View to pres
            //CreateMap<Models.ViewModels.Headphones, Models.LogicModels.Headphones>()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(h => h.Name))
            //    .ForMember(x => x.MinFrequency, opt => opt.MapFrom(h => h.MinFrequency))
            //    .ForMember(x => x.MaxFrequency, opt => opt.MapFrom(h => h.MaxFrequency))
            //    .ForMember(x => x.Picture, opt => opt.MapFrom(h => h.Picture))
            //    .ForMember(x => x.Company, opt => opt.MapFrom(h => new Models.LogicModels.Company()
            //    {
            //        Name = h.Company
            //    }))
            //    .ForMember(x => x.Design, opt => opt.MapFrom(h => new Models.LogicModels.Design()
            //    {
            //        Name = h.Design
            //    }));
=======
>>>>>>> 16f8ea2e63d327eb41aad3bc955a03de54bd3e69
        }
    }
}
