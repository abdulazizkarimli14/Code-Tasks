using FruitesProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitesProject.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.ImageUrl)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Fresh Tomato",
                Description = "Fresh and organic tomato",
                Price = 2.50m,
                ImageUrl = "vegetable-item-1.jpg",
                IsActive = true,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Green Pepper",
                Description = "Green pepper full of vitamins",
                Price = 3.20m,
                ImageUrl = "vegetable-item-2.jpg",
                IsActive = true,
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Broccoli",
                Description = "Healthy green broccoli",
                Price = 4.10m,
                ImageUrl = "vegetable-item-3.png",
                IsActive = true,
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Name = "Red Onion",
                Description = "Fresh red onion",
                Price = 1.90m,
                ImageUrl = "vegetable-item-4.jpg",
                IsActive = true,
                CategoryId = 1
            },
            new Product
            {
                Id = 5,
                Name = "Carrot",
                Description = "Organic orange carrot",
                Price = 2.00m,
                ImageUrl = "vegetable-item-5.jpg",
                IsActive = true,
                CategoryId = 1
            },
            new Product
            {
                Id = 6,
                Name = "Cucumber",
                Description = "Fresh cucumber",
                Price = 1.75m,
                ImageUrl = "vegetable-item-6.jpg",
                IsActive = true,
                CategoryId = 1
            }
        );
    }
}
