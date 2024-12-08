using System;
using System.Data;
using Dapper;
using LearnifyStockApp.Models.Entities;

namespace LearnifyStockApp.Models.Repositories;

public class SupplierRepository
{
    private readonly IDbConnection _dbConnection;

    public SupplierRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync(bool isDeleted)
    {
        string query = "SELECT * FROM Suppliers WHERE IsDeleted=@IsDeleted";
        return await _dbConnection.QueryAsync<Supplier>(query, new { IsDeleted = isDeleted });
    }

}
