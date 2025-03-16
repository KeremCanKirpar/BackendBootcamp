using EShop.Shared.Dtos.ProductDtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract
{
    public interface IProductService
    {
        Task<ResponseDto<ProductDto>> GetAsync(int id, bool? includeCategories);
        Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync(bool? isActive = null, bool includeCategories = false, int? categoryId = null, bool? isDeleted = null);
        Task<ResponseDto<ProductDto>> AddAsync(ProductCreateDto productCreateDto);
        Task<ResponseDto<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<ResponseDto<NoContent>> SoftDeleteAsync(int id);
        Task<ResponseDto<NoContent>> HardDeleteAsync(int id);
        Task<ResponseDto<int>> CountAsync(bool? isActive = null);
        Task<ResponseDto<bool>> UpdateIsActiveAsync(int id);
        Task<ResponseDto<bool>> UpdateIsHomeAsync(int id);
        Task<ResponseDto<bool>> UpdateIsActiveByCategoryAsync(int categoryId);
    }
}
