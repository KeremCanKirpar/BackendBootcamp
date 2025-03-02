using System;
using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Interfaces;

public interface IProductService
{
    Task<ResponseModel<List<ProductModel>>> GetAllAsync();
    Task<ResponseModel<List<ProductModel>>> GetAllActivesAsync();
    Task<ResponseModel<List<ProductModel>>> GetAllPassivesAsync();
    Task<ResponseModel<ProductModel>> GetAsync();
    Task<ResponseModel<int>> CountAsync();
    Task<ResponseModel<int>> CountAsync(bool isActive);

    Task<ResponseModel<ProductModel>> CreateProductAsync(ProductCreateModel productCreateModel);
    Task<ResponseModel<ProductModel>> UpdateProductAsync(ProductUpdateModel productUpdateModel);
    Task<ResponseModel<NoContent>> HardDeleteAsync(int id);
    Task<ResponseModel<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseModel<bool>> UpdateIsActive(int id);

}
