using EShop.MVC.Models;

namespace EShop.MVC.Services.Abstract;

public interface IProductService
{
    Task<ResponseModel<List<ProductModel>>> GetAllAdminAsync(bool? isActive = null, bool? includeCategories = null, int? categoryId = null, bool? isDeleted = null);
    Task<ResponseModel<List<ProductModel>>> GetAllAsync();
    Task<ResponseModel<ProductModel>> GetByIdAsync(int id);
    Task<ResponseModel<ProductModel>> CreateAsync(ProductCreateModel model);
    Task<ResponseModel<ProductModel>> UpdateAsync(ProductUpdateModel model);
    Task<ResponseModel<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseModel<NoContent>> HardDeleteAsync(int id);
    Task<ResponseModel<NoContent>> UpdateIsActiveAsync(int id);
    Task<ResponseModel<NoContent>> UpdateIsHomeAsync(int id);
}