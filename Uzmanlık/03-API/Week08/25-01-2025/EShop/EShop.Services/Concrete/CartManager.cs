using System;
using AutoMapper;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Concrete;

public class CartManager : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Cart> _cartRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<CartItem> _cartItemRepository;

    public CartManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cartRepository = _unitOfWork.GetRepository<Cart>();
        _productRepository = _unitOfWork.GetRepository<Product>();
        _cartItemRepository = _unitOfWork.GetRepository<CartItem>();
    }

    public async Task<ResponseDto<CartItemDto>> AddToCartAsync(CartItemCreateDto cartItemCreateDto)
    {
        try
        {
            var product = await _productRepository.GetAsync(cartItemCreateDto.ProductId);
            if (product == null)
            {
                return ResponseDto<CartItemDto>.Fail("Ürün Bulunamadı", 404);
            }
            if (!product.IsActive)
            {
                return ResponseDto<CartItemDto>.Fail("Ürün aktif değil", 400);
            }
            var cartItem = new CartItem(
             cartItemCreateDto.CartId,
             cartItemCreateDto.ProductId,
             cartItemCreateDto.Quantity

            );
            await _cartItemRepository.AddAsync(cartItem);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<CartItemDto>.Fail("Ürün sepete eklenirken bir hata oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDto<CartItemDto>.Success(StatusCodes.Status204NoContent);

        }
        catch (Exception ex)
        {

            return ResponseDto<CartItemDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<CartItemDto>> ChangeQuantityAsync(CartItemUpdateDto cartItemUpdateDto)
    {
        try
        {
            var cartItem = await _cartItemRepository.GetAsync(
                x => x.Id == cartItemUpdateDto.Id,
                query => query.Include(x => x.Product)
            );
            if (cartItem == null)
            {
                return ResponseDto<CartItemDto>.Fail("Sepet Öğesi bulunamadı.", StatusCodes.Status404NotFound);
            }
            cartItem.Quantity = cartItemUpdateDto.Quantity;
            _cartItemRepository.Update(cartItem);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<CartItemDto>.Fail("Ürün miktarı güncellenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
            }
            var cartItemDto = _mapper.Map<CartItemDto>(cartItem);
            return ResponseDto<CartItemDto>.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {

            return ResponseDto<CartItemDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<NoContent>> ClearCartAsync(string applicationUserId)
    {
        try
        {
            var cart = await _cartRepository.GetAsync(
                x => x.ApplicationUserId == applicationUserId,
                query => query.Include(x => x.CartItems)
            );
            if (cart == null)
            {
                return ResponseDto<NoContent>.Fail("Sepet Bulunamadı", StatusCodes.Status404NotFound);
            }
            cart.CartItems?.Clear();
            _cartRepository.Update(cart);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<NoContent>.Fail("Sepet temizlenirken hata oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
        }
        catch (Exception ex)
        {

            return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<CartDto>> CreateCartAsync(string applicationUserId)
    {
        try
        {
              if(string.IsNullOrEmpty(applicationUserId))
              {
                return ResponseDto<CartDto>.Fail("Kullanıcı bilgisi bulunamadı.", StatusCodes.Status404NotFound);
              }
              var cart = await _cartRepository.GetAsync(
                    x=>x.ApplicationUserId==applicationUserId
              );
              if(cart!=null)
              {
                var cartDto = _mapper.Map<CartDto>(cart);
                return ResponseDto<CartDto>.Success(cartDto,StatusCodes.Status200OK);
              }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public Task<ResponseDto<CartDto>> GetCartAsync(string applicationUserId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<NoContent>> RemoveFromCartAsync(int cartItemId)
    {
        throw new NotImplementedException();
    }
}
