using System;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Interfaces;

public interface IProductService
{
    Task<ResponseModel<List<ProductModel>>> GetAllActivesAsync();
    Task<ResponseModel<List<ProductModel>>> GetAllAsync();
    Task<ResponseModel<List<ProductModel>>> GetAllDeletedAsync();
    Task<ResponseModel<ProductModel>> GetByIdAsync(int id);
    Task<ResponseModel<ProductModel>> CreateAsync(ProductModel productCreateModel);
    Task<ResponseModel<ProductModel>> UpdateAsync(ProductModel  productUpdateModel);
    Task<ResponseModel<NoContent>> HardDeleteAsync(int id);
    Task<ResponseModel<NoContent>> SoftDeleteAsync(int id);
    Task<ResponseModel<NoContent>> UpdateIsActiveAsync(int id);
    
}
    

