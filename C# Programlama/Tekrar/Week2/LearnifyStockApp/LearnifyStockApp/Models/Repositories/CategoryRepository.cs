using System;
using System.Data;
using Dapper;
using LearnifyStockApp.Models.Entities;
using LearnifyStockApp.Models.ViewModels.CategoryViewModels;

namespace LearnifyStockApp.Models.Repositories;

public class CategoryRepository
{
    private readonly IDbConnection _dbConnection;
    public CategoryRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    /// <summary>
    /// Tüm kategorileri döndürür.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        string query = "SELECT * FROM Categories";
        return await _dbConnection.QueryAsync<CategoryViewModel>(query);
    }

    /// <summary>
    /// Silinmiş ya da silinmemiş tüm kategorileri döndürür.
    /// </summary>
    /// <param name="isDeleted">Silinmiş kayıtlar için true, diğerleri için false</param>
    /// <returns></returns>
    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync(bool isDeleted)
    {
        string query = "SELECT * FROM Categories WHERE IsDeleted=@IsDeleted";
        return await _dbConnection.QueryAsync<CategoryViewModel>(query, new { IsDeleted = isDeleted });
    }

    /// <summary>
    /// Id'si verilen kategori bilgisini döndürür.
    /// </summary>
    /// <param name="id">Döndürülmek istenen kategorinin id bilgisi</param>
    /// <returns></returns>
    public async Task<CategoryViewModel?> GetAsync(int id)
    {
        string query = "SELECT * FROM Categories WHERE Id=@Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<CategoryViewModel>(query, new { Id = id });
    }

    /// <summary>
    /// Yeni kategori ekler
    /// </summary>
    /// <param name="category">Eklenecek kategori bilgisi</param>
    /// <returns></returns>
    public async Task AddAsync(AddCategoryViewModel category)
    {
        string query = "INSERT INTO Categories(Name,Description) VALUES (@Name,@Description)";
        await _dbConnection.ExecuteAsync(query, category);
    }

    /// <summary>
    /// Kategoriyi günceller
    /// </summary>
    /// <param name="category">Güncellenecek kategori bilgisi</param>
    /// <returns></returns>
    public async Task UpdateAsync(UpdateCategoryViewModel category)
    {
        string query = "UPDATE Categories SET Name=@Name,Description=@Description WHERE Id=@Id";
        await _dbConnection.ExecuteAsync(query, category);
    }

    /// <summary>
    /// Id'si verilen kategoriyi veritabanından kalıcı olarak siler
    /// </summary>
    /// <param name="id">Silinecek kategorinin Id bilgisi</param>
    /// <returns></returns>
    public async Task HardDeleteAsync(int id)
    {
        string query = "DELETE FROM Categories WHERE Id=@Id";
        await _dbConnection.ExecuteAsync(query, new { Id = id });
    }

    /// <summary>
    /// Id'si verilen kategorinin çöp kutusuna atılmasını sağlar
    /// </summary>
    /// <param name="id">Çöp kutusuna atılacak kategorinin Id bilgisi</param>
    /// <returns></returns>
    public async Task SoftDeleteAsync(int id)
    {
        string queryGet = "SELECT * FROM Categories WHERE Id=@Id";
        var category = await _dbConnection.QueryFirstOrDefaultAsync<Category>(queryGet, new { Id = id });
        var isDeleted = !category.IsDeleted;
        string queryDelete = "UPDATE Categories SET IsDeleted=@IsDeleted WHERE Id=@Id";
        await _dbConnection.ExecuteAsync(queryDelete, new { Id = id, IsDeleted = isDeleted });
    }

    /// <summary>
    /// En çok satış yapılan kategori adını ve satış tutarını döndürür
    /// </summary>
    /// <returns></returns>
    public async Task<(string CategoryName, decimal TotalSales)> GetTopSellingCategoryAsync()
    {
        string query = @"
            SELECT TOP(1)
                c.Name AS CategoryName,
                SUM(s.Quantity*s.UnitPrice) AS TotalSales
            FROM Categories c JOIN Products p ON c.Id=p.CategoryId
                    JOIN Sales s ON p.Id=s.ProductId
            GROUP BY c.Name
            ORDER BY SUM(s.Quantity*s.UnitPrice) DESC
        ";
        return await _dbConnection.QueryFirstOrDefaultAsync<(string CategoryName, decimal TotalSales)>(query);
    }

    #region AlternatifGetAllAsync
    // public async Task<IEnumerable<Category>> GetAllAsync(bool? isDeleted = null)
    // {
    //     string query;
    //     if (isDeleted == null)
    //     {
    //         query = "SELECT * FROM Categories";
    //         return await _dbConnection.QueryAsync<Category>(query);
    //     }
    //     query = "SELECT * FROM Categories WHERE IsDeleted=@IsDeleted";
    //     return await _dbConnection.QueryAsync<Category>(query, new { IsDeleted = isDeleted });
    // }
    #endregion

}
