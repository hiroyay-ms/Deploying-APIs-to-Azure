using Microsoft.EntityFrameworkCore;
using Aspnet.Backend.Api.Models;

namespace Aspnet.Backend.Api.Data;

public class AdventureWorksContext : DbContext
{
    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : base(options)
    {
    }

    public DbSet<ProductCategory> ProductCategory => Set<ProductCategory>();
    public DbSet<ProductModel> ProductModel => Set<ProductModel>();
    public DbSet<ProductDescription> ProductDescription => Set<ProductDescription>();
    public DbSet<ProductModelProductDescription> ProductModelProductDescription => Set<ProductModelProductDescription>();
    public DbSet<Product> Product => Set<Product>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<Customer> Customer => Set<Customer>();
    public DbSet<SalesOrderHeader> SalesOrderHeader => Set<SalesOrderHeader>();
    public DbSet<SalesOrderDetail> SalesOrderDetail => Set<SalesOrderDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SalesLT");
        
        modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
        modelBuilder.Entity<ProductModel>().ToTable("ProductModel");
        modelBuilder.Entity<ProductDescription>().ToTable("ProductDescription");
        modelBuilder.Entity<ProductModelProductDescription>().ToTable("ProductModelProductDescription").HasKey(p => new { p.ProductModelID, p.ProductDescriptionID });
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Address>().ToTable("Address");
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<SalesOrderHeader>().ToTable("SalesOrderHeader");
        modelBuilder.Entity<SalesOrderDetail>().ToTable("SalesOrderDetail");
    }
}