using System;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface IProductService
{
    Task<ResponseDto<ProductDto>> GetAsync(int id);
    Task<ResponseDto<ProductDto>> GetWithCategoriesAsync(int id);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync();
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync(bool isActive);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllWithCategoriesAsync();
    Task<ResponseDto<IEnumerable<ProductDto>>> GetByCategoryAsync(int categoryId);
    Task<ResponseDto<ProductDto>> AddAsync(ProductCreateDto productCreateDto);
    Task<ResponseDto<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto);
    Task<ResponseDto<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseDto<NoContent>> HardDeleteAsync(int id);
    Task<ResponseDto<int>> CountAsync();
    Task<ResponseDto<int>> CountAsync(bool isActive);
    Task<ResponseDto<bool>> UpdateIsActiveAsync(int id);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllDeletedAsync();
}
