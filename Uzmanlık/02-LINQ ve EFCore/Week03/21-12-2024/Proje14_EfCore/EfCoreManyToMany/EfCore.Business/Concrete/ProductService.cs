using System;
using EfCore.Business.Abstract;
using EfCore.Shared.Dtos;

namespace EfCore.Business.Concrete;

public class ProductService : IProductService
{
    public Task<ProductDto> CreateAsync(ProductCreateDto productCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetProductsAsync(bool isDeleted)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        throw new NotImplementedException();
    }
}
