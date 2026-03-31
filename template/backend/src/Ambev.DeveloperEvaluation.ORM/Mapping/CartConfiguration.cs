using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        // Table name
        builder.ToTable("Charts");

        // Primary key
        builder.HasKey(c => c.Id);

        // Properties
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.Date)
            .IsRequired()
            .HasMaxLength(20); // YYYY-MM-DD como string

        // Relationship: Chart -> ChartProducts (1:N)
        builder.HasMany(c => c.Products)
            .WithOne()
            .HasForeignKey("ChartId") // chave estrangeira
            .OnDelete(DeleteBehavior.Cascade);

        // Navigation property
        builder.Navigation(c => c.Products).AutoInclude();

    }

}
