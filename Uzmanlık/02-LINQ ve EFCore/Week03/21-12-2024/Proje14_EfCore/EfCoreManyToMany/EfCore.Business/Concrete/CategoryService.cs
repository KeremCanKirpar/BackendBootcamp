using System;
using EfCore.Business.Abstract;
using EfCore.Data.Abstract;
using EfCore.Entity.Concrete;
using EfCore.Shared.Dtos;

namespace EfCore.Business.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto)
    {
      if(categoryCreateDto == null)
      {
        
        return null;
      }
      var category= new Category{
        Name = categoryCreateDto.Name,
        Description = categoryCreateDto.Description,
        IsDeleted = false,
      };
      await _categoryRepository.AddAsync(category);
      var categoryDto = new CategoryDto
      {
        Id = category.Id,
        Name = category.Name,
        Description = category.Description
      };
      return categoryDto;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool isDeleted)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> UpdateAsyc(CategoryUpdateDto categoryUpdateDto)
    {
        throw new NotImplementedException();
    }
}
