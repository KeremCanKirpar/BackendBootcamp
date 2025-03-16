using EShop.MVC.Models;

namespace EShop.MVC.Services.Abstract;

public interface ICategoryService
{
    Task<ResponseModel<List<CategoryModel>>> GetAllAsync();
    Task<ResponseModel<List<CategoryModel>>> GetAllAdminAsync(bool? isActive = null, bool? isDeleted = null);
    Task<ResponseModel<List<CategoryModel>>> GetMenuItemsAsync();
    Task<ResponseModel<CategoryModel>> GetByIdAsync(int id);
    Task<ResponseModel<CategoryModel>> CreateAsync(CategoryCreateModel model);
    Task<ResponseModel<CategoryModel>> UpdateAsync(CategoryUpdateModel model);
    Task<ResponseModel<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseModel<NoContent>> HardDeleteAsync(int id);
    Task<ResponseModel<bool>> UpdateIsActiveAsync(int id);
    Task<ResponseModel<bool>> UpdateIsMenuItemAsync(int id);
}