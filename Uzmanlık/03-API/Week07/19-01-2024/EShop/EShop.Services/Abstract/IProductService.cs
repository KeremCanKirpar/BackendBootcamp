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

    
}
