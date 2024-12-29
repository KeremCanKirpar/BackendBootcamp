using System;
using EfCore.Shared.Dtos;

namespace EfCore.Business.Abstract;

public interface IProductService
{
    Task<ProductDto> CreateAsync(ProductCreateDto productCreateDto);
    Task<ProductDto> UpdateAsync(ProductUpdateDto productUpdateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<IEnumerable<ProductDto>> GetProductsAsync(bool isDeleted);
    Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    Task<ProductDto> GetByIdAsync(int id);
}
