using EShop.Shared.Dtos.CategoryDtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseDto<CategoryDto>> GetAsync(int id);
        Task<ResponseDto<IEnumerable<CategoryDto>>> GetAllAsync(bool? isActive = null, bool? isDeleted = null);
        Task<ResponseDto<IEnumerable<CategoryDto>>> GetMenuItemsAsync();
        Task<ResponseDto<CategoryDto>> AddAsync(CategoryCreateDto categoryCreateDto);
        Task<ResponseDto<NoContent>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<ResponseDto<NoContent>> SoftDeleteAsync(int id);
        Task<ResponseDto<NoContent>> HardDeleteAsync(int id);
        Task<ResponseDto<int>> CountAsync(bool? isActive = null);
        Task<ResponseDto<bool>> UpdateIsActiveAsync(int id);
        Task<ResponseDto<bool>> UpdateIsMenuItemAsync(int id);

    }
}
