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
                return ResponseDto<CartItemDto>.Fail("Ürün bulunamadı.", 404);
            }
            if (!product.IsActive)
            {
                return ResponseDto<CartItemDto>.Fail("Ürün aktif değil.", 400);
            }

            var cart = await _cartRepository.GetAsync(
                x => x.Id == cartItemCreateDto.CartId,
                query => query.Include(c => c.CartItems).ThenInclude(ci => ci.Product)
            );
            if (cart == null || cart.CartItems == null)
            {
                return ResponseDto<CartItemDto>.Fail("Sepet bulunamadı", StatusCodes.Status404NotFound);
            }
            var existsCartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == cartItemCreateDto.ProductId);

            if (existsCartItem != null)
            {
                existsCartItem.Quantity += cartItemCreateDto.Quantity;
                _cartItemRepository.Update(existsCartItem);
                var existsResult = await _unitOfWork.SaveAsync();
                if (existsResult < 1)
                {
                    return ResponseDto<CartItemDto>.Fail("Bir sorun oluştu", StatusCodes.Status400BadRequest);
                }
                var exitstCartItemDto = _mapper.Map<CartItemDto>(existsCartItem);
                return ResponseDto<CartItemDto>.Success(exitstCartItemDto, StatusCodes.Status200OK);
            }

            var cartItem = new CartItem(
                cartItemCreateDto.CartId,
                cartItemCreateDto.ProductId,
                cartItemCreateDto.Quantity
            );
            // await _cartItemRepository.AddAsync(cartItem);
            cart.CartItems.Add(cartItem);
            _cartRepository.Update(cart);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<CartItemDto>.Fail("Ürün sepete eklenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
            }
            var cartItemDto = _mapper.Map<CartItemDto>(cartItem);
            return ResponseDto<CartItemDto>.Success(cartItemDto, StatusCodes.Status204NoContent);
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
                return ResponseDto<CartItemDto>.Fail("Sepet öğesi bulunamadı.", StatusCodes.Status404NotFound);
            }
            cartItem.Quantity = cartItemUpdateDto.Quantity;
            _cartItemRepository.Update(cartItem);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<CartItemDto>.Fail("Ürün miktarı güncellenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
            }
            var cartItemDto = _mapper.Map<CartItemDto>(cartItem);
            return ResponseDto<CartItemDto>.Success(cartItemDto, StatusCodes.Status200OK);
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
                return ResponseDto<NoContent>.Fail("Sepet bulunamadı.", StatusCodes.Status404NotFound);
            }
            cart.CartItems?.Clear();
            _cartRepository.Update(cart);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<NoContent>.Fail("Sepet temizlenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
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
            if (string.IsNullOrEmpty(applicationUserId))
            {
                return ResponseDto<CartDto>.Fail("Kullanıcı bilgisi bulunamadı.", StatusCodes.Status404NotFound);
            }
            var existsCart = await _cartRepository.GetAsync(x => x.ApplicationUserId == applicationUserId);
            if (existsCart != null)
            {
                var existsCartDto = _mapper.Map<CartDto>(existsCart);
                return ResponseDto<CartDto>.Success(existsCartDto, StatusCodes.Status200OK);
            }
            var cart = new Cart(applicationUserId);
            await _cartRepository.AddAsync(cart);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<CartDto>.Fail("Sepet oluşturulurken bir hata oluştu", StatusCodes.Status500InternalServerError);
            }
            var cartDto = _mapper.Map<CartDto>(cart);
            return ResponseDto<CartDto>.Success(cartDto, StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return ResponseDto<CartDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<CartDto>> GetCartAsync(string applicationUserId)
    {
        try
        {
            if (string.IsNullOrEmpty(applicationUserId))
            {
                return ResponseDto<CartDto>.Fail("Kullanıcı bilgisi bulunamadı.", StatusCodes.Status404NotFound);
            }
            var cart = await _cartRepository.GetAsync(
                x => x.ApplicationUserId == applicationUserId,
                query => query.Include(x => x.CartItems).ThenInclude(y => y.Product)
            );
            if (cart == null)
            {
                return ResponseDto<CartDto>.Fail("Kullanıcıya ait sepet bulunamadı", StatusCodes.Status404NotFound);
            }
            var cartDto = _mapper.Map<CartDto>(cart);
            return ResponseDto<CartDto>.Success(cartDto, StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<CartDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<NoContent>> RemoveFromCartAsync(int cartItemId)
    {
        try
        {
            var cartItem = await _cartItemRepository.GetAsync(cartItemId);
            if (cartItem == null)
            {
                return ResponseDto<NoContent>.Fail("İlgili ürün sepette bulunamadığı için silinemedi'", StatusCodes.Status404NotFound);
            }
            _cartItemRepository.Delete(cartItem);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDto<NoContent>.Fail("Bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
