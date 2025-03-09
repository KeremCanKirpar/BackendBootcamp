using System;
using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Interfaces;

public interface IProductService
{
    Task<ResponseModel<List<ProductModel>>> GetAllActivesAsync(bool isActive = true);
    Task<ResponseModel<List<ProductModel>>> GetAllAsync();
    Task<ResponseModel<List<ProductModel>>> GetAllDeletedAsync();
    Task<ResponseModel<ProductModel>> GetByIdAsync(int id);
    Task<ResponseModel<ProductModel>> CreateAsync(ProductCreateModel productCreateModel);
    Task<ResponseModel<ProductModel>> UpdateAsync(ProductUpdateModel productUpdateModel);
    Task<ResponseModel<NoContent>> HardDeleteAsync(int id);
    Task<ResponseModel<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseModel<NoContent>> UpdateIsActiveAsync(int id);


}
