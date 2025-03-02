using System;
using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Interfaces;

public interface ICategoryService
{
    Task<ResponseModel<List<CategoryModel>>> GetAllAsync();
    Task<ResponseModel<List<CategoryModel>>> GetAllActivesAsync();
    Task<ResponseModel<List<CategoryModel>>> GetAllPassivesAsync();
    Task<ResponseModel<CategoryModel>> GetAsync(int id);
    Task<ResponseModel<int>> CountAsync();
    Task<ResponseModel<int>> CountAsync(bool isActive);

    Task<ResponseModel<CategoryModel>> CreateAsync(CategoryCreateModel categoryCreateModel);
    Task<ResponseModel<NoContent>> UpdateAsync(CategoryUpdateModel categoryUpdateModel);
    Task<ResponseModel<NoContent>> HardDeleteAsync(int id);
    Task<ResponseModel<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseModel<bool>> UpdateIsActive(int id);
}
