using System;
using System.Data;
using Dapper;
using Tekrar.Models.Entities;
using Tekrar.Models.ViewModels.CategoryViewModels;

namespace Tekrar.Models.Repositories;

public class CategoryRepository
{
    private readonly IDbConnection _dbConnetion;
    public CategoryRepository(IDbConnection dbConnection)
    {
        _dbConnetion = dbConnection;
    }
    /// <summary>
    /// Tüm Kategorileri döndürür
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        string query = "SELECT * FROM Categories";

        return await _dbConnetion.QueryAsync<CategoryViewModel>(query);
    }
    /// <summary>
    /// Silinmiş ya da silinmemiş tüm kategorileri döndürür
    /// </summary>
    /// <param name="isDeleted">Silinmiş kayıtlar için true, diğerleri için false</param>
    /// <returns></returns>
    public async Task<IEnumerable<Category>> GetAllAsync(bool isDeleted)
    {
        string query = "SELECT * FROM Categories WHERE IsDeleted=@IsDeleted";
        return await _dbConnetion.QueryAsync<Category>(query, new { IsDeleted = isDeleted });
    }

    /// <summary>
    /// Id'si verilen kategori bilgisini Döndürür
    /// </summary>
    /// <param name="id">Döndürülmek istenen kategori Id'sini Döndürür</param>
    /// <returns></returns>
    public async Task<Category?> GetAsync(int id)
    {
        string query = "SELECT * FROMCategories WHERE Id =@Id";
        return await _dbConnetion.QueryFirstOrDefault(query, new { Id = id });
    }
    /// <summary>
    /// Kategori ekler
    /// </summary>
    /// <param name="category">Eklenecek kategori bilgisi</param>
    /// <returns></returns>
    public async Task AddAsync(AddCategoryViewModel category)
    {
        string query = "INSERT INTO Categories(Name,Description) VALUES(@Name,@Description)";
        var result = await _dbConnetion.ExecuteAsync(query, category);
    }
    /// <summary>
    /// Kategoriyi günceller
    /// </summary>
    /// <param name="category">Güncelleneke Kategori Bilgisi</param>
    /// <returns></returns>
    public async Task UpdateAsync(UpdateCategoryViewModel category)
    {
        string query = "UPDATE Categories SET Name=@Name, Description=@Description, IsDeleted=@IsDeleted Where Id=@Id";
        await _dbConnetion.ExecuteAsync(query, category);
    }
    /// <summary>
    /// Id'si verilen kategoriyi veritabanından kalıcı olarak siler
    /// </summary>
    /// <param name="id">Silinecek kategorinin Id bilgisi</param>
    /// <returns></returns>
    public async Task HardDeleteAsync(int id)
    {
        string query = "DELETE FROM Categories WHERE Id=@Id";
        await _dbConnetion.ExecuteAsync(query, new { Id = id });
    }
    /// <summary>
    /// Id'si Verilen Kategorinin Çöp kutusuna atılmasını sağlar
    /// </summary>
    /// <param name="id">Çöp Kutusuna atılacak kategorinin Id bilgisi</param>
    /// <returns></returns>
    public async Task SoftDeleteAsync(int id)
    {
        var category = await GetAsync(id);
        var isDeleted = !category.IsDeleted;
        string query = "UPDATE Categories SET IsDeleted =@IsDeleted WHERE Id=@Id ";
        await _dbConnetion.ExecuteAsync(query, new { Id = id, IsDeleted = isDeleted });
    }

    public async Task<(string CategoryName, decimal TotalSales)> GetTopSellingCategoryAsync()
    {
        string query = @"
            SELECT TOP(1)
    c.Name AS CategoryName,
    SUM(s.Quantity*s.UnitPrice) AS TotalSales
    FROM 
    Categories c JOIN Products p ON c.Id=p.CategoryId JOIN Sales s ON p.Id = s.ProductId
    GROUP by c.Name
    ORDER BY  SUM(s.Quantity*s.UnitPrice) DESC

        ";
        return await _dbConnetion.QueryFirstOrDefaultAsync<(string CategoryName, decimal TotalSales)>(query);

    }

    #region AllGetAllAsync

    // public async Task<IEnumerable<Category>> GetAllAsync(bool? isDeleted=null)
    // {
    //     string query;
    //     if(isDeleted==null)
    //     {
    //          query = "SELECT * FROM Categories";
    //          return await _dbConnetion.QueryAsync<Category>(query);
    //     }
    //     query="SELECT * FROM Categories WHERE IsDeleted=@IsDeleted";
    //     return await _dbConnetion.QueryAsync<Category>(query,new {IsDeleted=isDeleted});

    // }
    #endregion
}
