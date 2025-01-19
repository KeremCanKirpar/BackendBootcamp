using System;
using AutoMapper;
using EShop.Entity.Concrete;
using EShop.Shared.Dtos;

namespace EShop.Services.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region Category
                CreateMap<Category, CategoryDto>().ReverseMap();
                CreateMap<Category, CategoryCreateDto>().ReverseMap();
                CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            #endregion
        }
    }
}
