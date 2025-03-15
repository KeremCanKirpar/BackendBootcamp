using AutoMapper;
using EShop.Entity.Concrete;
using EShop.Shared.Dtos.AuthDtos;
using EShop.Shared.Dtos.CartDtos;
using EShop.Shared.Dtos.CategoryDtos;
using EShop.Shared.Dtos.OrderDtos;
using EShop.Shared.Dtos.ProductDtos;

namespace EShop.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            #region Category

            CreateMap<Category, CategoryDto>()
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone)))
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.UpdatedAt.UtcDateTime, turkeyTimeZone)))
                .ForMember(
                    dest => dest.DeletedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.DeletedAt.UtcDateTime, turkeyTimeZone)))
                .ReverseMap();


            CreateMap<IEnumerable<Category>, IEnumerable<CategoryDto>>()
                .ConvertUsing((src, dest, context) => src.Select(c => context.Mapper.Map<CategoryDto>(c)).ToList());

            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ProductDto>()
                .ForMember(
                    dest => dest.Categories,
                    opt => opt
                        .MapFrom(src => src.ProductCategories.Select(pc => pc.Category)))
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone)))
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.UpdatedAt.UtcDateTime, turkeyTimeZone)))
                .ForMember(
                    dest => dest.DeletedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.DeletedAt.UtcDateTime, turkeyTimeZone)))
            .ReverseMap();
            CreateMap<IEnumerable<Product>, IEnumerable<ProductDto>>()
                .ConvertUsing((src, dest, context) => src.Select(p => context.Mapper.Map<ProductDto>(p)).ToList());
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            #endregion

            #region Cart
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems))
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone)))
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.UpdatedAt.UtcDateTime, turkeyTimeZone)))
                .ForMember(
                    dest => dest.DeletedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.DeletedAt.UtcDateTime, turkeyTimeZone)))
            .ReverseMap();
            CreateMap<Cart, CartCreateDto>().ReverseMap();
            CreateMap<Cart, CartUpdateDto>().ReverseMap();
            #endregion

            #region CartItem
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ReverseMap();
            CreateMap<CartItem, ChangeQuantityDto>().ReverseMap();
            CreateMap<CartItem, ChangeQuantityDto>().ReverseMap();
            #endregion

            #region Order
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.CreatedAt.UtcDateTime, turkeyTimeZone)))
                .ForMember(
                    dest => dest.DeletedAt,
                    opt => opt.MapFrom(src => TimeZoneInfo.ConvertTime(src.DeletedAt.UtcDateTime, turkeyTimeZone)))
                .ReverseMap();
            CreateMap<IEnumerable<Order>, IEnumerable<OrderDto>>()
                .ConvertUsing((src, dest, context) => src.Select(o => context.Mapper.Map<OrderDto>(o)).ToList());
            CreateMap<OrderNowDto, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            #endregion

            #region OrderItem
            CreateMap<OrderItem, OrderItemDto>()
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name));
            CreateMap<IEnumerable<OrderItem>, IEnumerable<OrderItemDto>>()
                .ConvertUsing((src, dest, context) => src.Select(oi => context.Mapper.Map<OrderItemDto>(oi)).ToList());
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<OrderItemCreateDto, OrderItem>();
            #endregion

            #region ApplicationUserRole
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            #endregion
        }
    }
}
