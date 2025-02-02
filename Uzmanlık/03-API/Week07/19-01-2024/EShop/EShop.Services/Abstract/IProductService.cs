using System;
using System.Linq.Expressions;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface IProductService
{
    Task<ResponseDto<ProductDto>> GetAsync(int id);
    Task<ResponseDto<ProductDto>> AddAsync(ProductCreateDto productCreateDto);
    Task<ResponseDto<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto);
    Task<ResponseDto<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseDto<NoContent>> HardDeleteAsync(int id);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync();
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync(bool? isActive);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync(Expression<Func<ProductDto, bool>> filter);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(int categoryId);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(int categoryId, Expression<Func<ProductDto, bool>> filter);
}
