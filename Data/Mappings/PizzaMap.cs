using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings;
public class PizzaMap : IEntityTypeConfiguration<Pizza> {
    public void Configure(EntityTypeBuilder<Pizza> builder) 
    {
        builder.ToTable("Pizzas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Flavors)
            .IsRequired()
            .HasColumnName("Flavors")
            .HasMaxLength(80)
            .HasConversion<string>();
      

        builder.Property(x => x.Category)
            .IsRequired()
            .HasColumnName("Category")
            .HasMaxLength(20)
            .HasConversion<string>();

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL(8,2)");


        builder.Property(x => x.IsFrozen)
            .IsRequired()
            .HasColumnName("IsFrozen")
            .HasColumnType("BIT");

        builder.Property(x => x.Size)
            .IsRequired()
            .HasColumnName("Size")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250);

        builder.Property(x => x.InStock)
            .IsRequired()
            .HasColumnName("InStock")
            .HasColumnType("INT");

        builder.Property(x => x.Rating)
            .HasColumnName("Rating")
            .HasColumnType("INT")
            .HasDefaultValue(0);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME2")
            .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnType("DATETIME2")
            .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


    }
}

