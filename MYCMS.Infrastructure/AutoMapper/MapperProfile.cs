using AutoMapper;
using MYCMS.Core.Dtos;
using MYCMS.Core.ViewModels;
using MYCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // User
            CreateMap<User, UserViewModel>();
            CreateMap<UpdateUserDto, User>().ForMember(x=> x.ImageUrl , x=> x.Ignore());
            CreateMap<User, UpdateUserDto>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<CreateUserDto, User>().ForMember(x=> x.ImageUrl , x=> x.Ignore());
            CreateMap<User, CreateUserDto>().ForMember(x => x.ImageUrl, x => x.Ignore());

            //Category
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();

            // Advertisement
            CreateMap<Advertisement, AdvertisementViewModel>()
                .ForMember(x => x.StartDate, x => x.MapFrom(x => x.StartDate.ToString("yyyy:MM:dd")))
                .ForMember(x => x.EndDate, x => x.MapFrom(x => x.EndDate.ToString("yyyy:MM:dd")));
            CreateMap<CreateAdvertisementDto, Advertisement>().ForMember(x => x.ImageUrl, x => x.Ignore()).ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<UpdateAdvertisementDto, Advertisement>().ForMember(x => x.ImageUrl, x => x.Ignore()).ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<Advertisement, UpdateAdvertisementDto>().ForMember(x => x.Image, x => x.Ignore());

        }
    }
}
