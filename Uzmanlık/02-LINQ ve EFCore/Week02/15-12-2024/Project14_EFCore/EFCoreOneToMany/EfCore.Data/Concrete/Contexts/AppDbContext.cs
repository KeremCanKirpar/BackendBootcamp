using System;
using EfCore.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data.Concrete.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1441;Database=EfCoreDb;User=sa;Password=YourStrong@Passw0rd; TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }
}
