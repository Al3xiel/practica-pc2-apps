using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using practica_pc2.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using practica_pc2.Work.Domain.Model.Aggregates;

namespace practica_pc2.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //TODO: Add database configuration modeling here

        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Product>().Property(p => p.Status).IsRequired();
        
        builder.Entity<ProductReview>().HasKey(pr => pr.Id);
        builder.Entity<ProductReview>().Property(pr => pr.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ProductReview>().Property(pr => pr.UserEmail).IsRequired().HasMaxLength(50);
        builder.Entity<ProductReview>().Property(pr => pr.Rating).IsRequired();
        builder.Entity<ProductReview>().Property(pr => pr.ReviewCriterion).IsRequired();
        builder.Entity<ProductReview>().Property(pr => pr.Comment).IsRequired().HasMaxLength(200);
        
        builder.Entity<Product>()
            .HasMany(p => p.Reviews)
            .WithOne(pr => pr.Product)
            .HasForeignKey(pr => pr.ProductId)
            .HasPrincipalKey(p => p.Id);
        
        builder.UseSnakeCaseNamingConvention();
    }
}