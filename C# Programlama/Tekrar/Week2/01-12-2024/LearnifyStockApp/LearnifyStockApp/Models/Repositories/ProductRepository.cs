using System;
using System.Data;
using Dapper;
using LearnifyStockApp.Models.Entities;
using LearnifyStockApp.Models.ViewModels.ProductViewModels;

namespace LearnifyStockApp.Models.Repositories;

public class ProductRepository
{
    private readonly IDbConnection _dbConnection;

    public ProductRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        string query = @"
            SELECT
                p.Id,
                p.Name,
                p.StockQuantity,
                p.MinimumStockLevel,
                p.Price,
                p.IsDeleted,
                c.Name AS CategoryName,
                s.Name AS SupplierName
            FROM Products p JOIN Categories c ON p.CategoryId=c.Id
                    JOIN Suppliers s ON p.SupplierId=s.Id
                    ";
        return await _dbConnection.QueryAsync<ProductViewModel>(query);
    }


    public async Task<IEnumerable<ProductViewModel>> GetAllAsync(bool isDeleted)
    {
        string query = @"
            SELECT
                p.Id,
                p.Name,
                p.StockQuantity,
                p.MinimumStockLevel,
                p.Price,
                p.IsDeleted,
                c.Name AS CategoryName,
                s.Name AS SupplierName
            FROM Products p JOIN Categories c ON p.CategoryId=c.Id
                    JOIN Suppliers s ON p.SupplierId=s.Id
            WHERE p.IsDeleted=@IsDeleted
                    ";
        return await _dbConnection.QueryAsync<ProductViewModel>(query, new { IsDeleted = isDeleted });
    }

    public async Task<ProductViewModel?> GetAsync(int id)
    {
        string query = @"
            SELECT
                p.Id,
                p.Name,
                p.StockQuantity,
                p.MinimumStockLevel,
                p.Price,
                p.IsDeleted,
                c.Name AS CategoryName,
                s.Name AS SupplierName
            FROM Products p JOIN Categories c ON p.CategoryId=c.Id
                    JOIN Suppliers s ON p.SupplierId=s.Id
            WHERE p.Id=@Id
                    ";
        return await _dbConnection.QueryFirstOrDefaultAsync<ProductViewModel?>(query, new { Id = id });
    }

    public async Task AddAsync(AddProductViewModel product)
    {
        string query = "INSERT INTO Products(Name,Description,CategoryId,SupplierId,StockQuantity,MinimumStockLevel,Price) VALUES(@Name,@Description,@CategoryId,@SupplierId,@StockQuantity,@MinimumStockLevel,@Price)";
        await _dbConnection.ExecuteAsync(query, product);
    }

    public async Task UpdateAsync(UpdateProductViewModel product)
    {
        string query = "UPDATE Products SET Name=@Name, Description=@Description, CategoryId=@CategoryId,SupplierId=@SupplierId,StockQuantity=@StockQuantity,MinimumStockLevel=@MinimumStockLevel,Price=@Price WHERE Id=@Id";
        await _dbConnection.ExecuteAsync(query, product);
    }

    public async Task HardDeleteAsync(int id)
    {
        string query = "DELETE FROM Products WHERE Id=@Id";
        await _dbConnection.ExecuteAsync(query, new { Id = id });
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        // string queryGet = "SELECT IsDeleted FROM Products WHERE Id=@Id";
        // var product = await _dbConnection.QueryFirstOrDefaultAsync<ProductViewModel>(queryGet,new {Id=id});
        var product = await GetAsync(id);
        var isDeleted = !product.IsDeleted;
        var query = "UPDATE Products SET IsDeleted=@IsDeleted WHERE Id=@Id";
        await _dbConnection.ExecuteAsync(query, new { Id = id, IsDeleted = isDeleted });
        return !isDeleted;
    }

    // Buraya temel işlemler dışında ihtiyaç duyacağımız Product operasyonları için gerekli metotları yazabiliriz. GetTotalProductsCount, GetProductsByCategory...
}
