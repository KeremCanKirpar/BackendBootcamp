using System;
using EfCore.Business.Abstract;
using EfCore.Data.Abstract;
using EfCore.Entity.Concrete;
using EfCore.Shared.Dtos;

namespace EfCore.Business.Concrete;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> CreateAsync(ProductCreateDto productCreateDto)
    {
        var product = new Product
        {
            Name = productCreateDto.Name,
            Price = productCreateDto.Price,
            Properties = productCreateDto.Properties
        };
        await _productRepository.AddAsync(product);
        product.ProductCategories = productCreateDto
                            .CategoryIds.Select(x => new ProductCategory
                            {
                                ProductId = product.Id,
                                CategoryId = x
                            }).ToList();
        await _productRepository.UpdateAsync(product);
        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Properties = product.Properties
        };
        return productDto;
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        await _productRepository.DeleteAsync(product);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetProductWithCategoriesAsync(id);
        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            IsDeleted = product.IsDeleted,
            Price = product.Price,
            Properties = product.Properties,
            Categories = product
                    .ProductCategories
                    .Select(x => new CategoryDto
                    {
                        Id = x.CategoryId,
                        Name = x.Category.Name,
                        Description = x.Category.Description
                    })
                    .ToList()
        };
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsWithCategoriesAsync();
        var productDtos = products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Properties = x.Properties,
                    Price = x.Price,
                    IsDeleted = x.IsDeleted,
                    Categories = x
                        .ProductCategories
                        .Select(x => new CategoryDto
                        {
                            Id = x.CategoryId,
                            Name = x.Category.Name,
                            Description = x.Category.Description
                        })
                        .ToList()
                }).ToList();
        return productDtos;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync(bool isDeleted)
    {
        var products = await _productRepository.GetAllDeletedProductsAsync(isDeleted);
        var productDtos = products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Properties = x.Properties,
                    Price = x.Price,
                    IsDeleted = x.IsDeleted,
                    Categories = x
                        .ProductCategories
                        .Select(x => new CategoryDto
                        {
                            Id = x.CategoryId,
                            Name = x.Category.Name,
                            Description = x.Category.Description
                        })
                        .ToList()
                }).ToList();
        return productDtos;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
        var productDtos = products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Properties = x.Properties,
                    Price = x.Price,
                    IsDeleted = x.IsDeleted,
                    Categories = x
                        .ProductCategories
                        .Select(x => new CategoryDto
                        {
                            Id = x.CategoryId,
                            Name = x.Category.Name,
                            Description = x.Category.Description
                        })
                        .ToList()
                }).ToList();
        return productDtos;
    }

    public async Task<ProductDto> UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        var product = await _productRepository.GetProductWithCategoriesAsync(productUpdateDto.Id);
        product.ProductCategories.Clear();
        await _productRepository.UpdateAsync(product);

        product.Name = productUpdateDto.Name;
        product.Properties = productUpdateDto.Properties;
        product.Price = productUpdateDto.Price;
        product.ProductCategories = productUpdateDto
            .CategoryIds
            .Select(x => new ProductCategory
            {
                ProductId = product.Id,
                CategoryId = x
            }).ToList();
        await _productRepository.UpdateAsync(product);
        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Properties = product.Properties,
            Price = product.Price,
            IsDeleted = product.IsDeleted,
            Categories = product
                .ProductCategories
                .Select(x => new CategoryDto
                {
                    Id = x.CategoryId,
                    Name = x.Category.Name,
                    Description = x.Category.Description
                }).ToList()
        };
        return productDto;
    }
}
