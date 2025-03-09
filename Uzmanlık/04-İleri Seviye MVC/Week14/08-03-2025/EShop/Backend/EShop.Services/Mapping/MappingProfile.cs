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
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();

            CreateMap<OrderCreateDto, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            #endregion

            #region OrderItem
            CreateMap<OrderItem, OrderItemDto>()
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name));
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<OrderItemCreateDto, OrderItem>();
            #endregion

            #region ApplicationUserRole
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            #endregion
        }
    }
}
