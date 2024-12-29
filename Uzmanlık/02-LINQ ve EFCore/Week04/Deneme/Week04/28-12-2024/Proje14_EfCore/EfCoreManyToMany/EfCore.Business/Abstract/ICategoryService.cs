using System;
using EfCore.Shared.Dtos;


namespace EfCore.Business.Abstract;

public interface ICategoryService
{
    Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto);
    Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool isDeleted);
    Task<CategoryDto> GetByIdAsync(int id);

}
