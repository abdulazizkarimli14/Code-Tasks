using AllupProjectMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllupProjectMVC.Data.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(b => b.Slug)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasIndex(b => b.Slug)
            .IsUnique();

        builder.Property(b => b.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(b => b.ShortDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(b => b.Content)
            .IsRequired();

        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.CreatedAt)
            .IsRequired();
    }
}
