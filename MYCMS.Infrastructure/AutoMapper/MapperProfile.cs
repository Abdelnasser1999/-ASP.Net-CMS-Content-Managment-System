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
        }
    }
}
