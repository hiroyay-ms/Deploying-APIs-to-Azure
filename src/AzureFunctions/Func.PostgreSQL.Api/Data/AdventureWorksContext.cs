using Microsoft.EntityFrameworkCore;
using Func.PostgreSQL.Api.Models;

namespace Func.PostgreSQL.Api.Data
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options)
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
            modelBuilder.HasDefaultSchema("saleslt");
            
            modelBuilder.Entity<ProductCategory>().ToTable("productcategory");
            modelBuilder.Entity<ProductModel>().ToTable("productmodel");
            modelBuilder.Entity<ProductDescription>().ToTable("productdescription");
            modelBuilder.Entity<ProductModelProductDescription>().ToTable("productmodelproductdescription").HasKey(p => new { p.ProductModelID, p.ProductDescriptionID });
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<Address>().ToTable("address");
            modelBuilder.Entity<Customer>().ToTable("customer");
            modelBuilder.Entity<SalesOrderHeader>().ToTable("salesorderheader");
            modelBuilder.Entity<SalesOrderDetail>().ToTable("salesorderdetail");
        }
    }
}