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
        if (categoryCreateDto == null)
        {
            return null;
        }
        var category = new Category
        {
            Name = categoryCreateDto.Name,
            Description = categoryCreateDto.Description,
            IsDeleted = false
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

    public async Task DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category != null)
        {
            await _categoryRepository.DeleteAsync(category);
        }
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        var categoryDto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
        return categoryDto;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();
        var categoryDtos = categories
                            .Select(x => new CategoryDto
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description
                            }).ToList();
        return categoryDtos;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool isDeleted)
    {
        IEnumerable<Category> categories = await _categoryRepository.GetAllDeletedCategoriesAsync(isDeleted);
        var categoryDtos = categories
                            .Select(x => new CategoryDto
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description
                            }).ToList();
        return categoryDtos;
    }

    public async Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryUpdateDto.Id);
        if (category == null)
        {
            return null;
        }
        category.Name = categoryUpdateDto.Name;
        category.Description = categoryUpdateDto.Description;
        await _categoryRepository.UpdateAsync(category);
        var categoryDto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
        return categoryDto;
    }
}







// foreach (Category category in categories)
// {
//     categoryDtos.Add(new CategoryDto{
//         Id=category.Id,
//         Name=category.Name,
//         Description=category.Description
//     });
// }