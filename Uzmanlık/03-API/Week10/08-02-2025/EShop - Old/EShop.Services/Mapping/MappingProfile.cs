using System;
using AutoMapper;
using EShop.Entity.Concrete;
using EShop.Shared.Dtos;

namespace EShop.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ProductDto>()
                .ForMember(
                    dest => dest.Categories,
                    opt => opt
                        .MapFrom(src => src.ProductCategories.Select(pc => pc.Category))).ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            #endregion

            #region Cart
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems)).ReverseMap();
            CreateMap<Cart, CartCreateDto>().ReverseMap();
            CreateMap<Cart, CartUpdateDto>().ReverseMap();
            #endregion

            #region CartItem
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product)).ReverseMap();
            CreateMap<CartItem, CartItemCreateDto>().ReverseMap();
            CreateMap<CartItem, CartItemUpdateDto>().ReverseMap();
            #endregion

            #region Order
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems)).ReverseMap();
            CreateMap<Order, OrderCreateDto>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();
            #endregion

            #region OrderItem
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore());
            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion
        }
    }
}
