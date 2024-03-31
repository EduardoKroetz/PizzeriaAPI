using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings;
public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL(8,2)");

        builder.Property(x => x.Qtd)
            .HasColumnName("Qtd")
            .HasColumnType("INT")
            .HasDefaultValue(1);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnName("Status")
            .HasConversion<string>();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME2")
            .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());

        builder.Property(x => x.AddressId)
            .HasColumnName("AddressId")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.HasIndex(x => x.AddressId);
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.HasIndex(x => x.UserId);

        builder.HasMany(x => x.Products)
            .WithOne()
            .HasForeignKey(x => x.OrderId)
            .HasConstraintName("FK_Orders_OrderItems")
            .OnDelete(DeleteBehavior.Cascade);

    }
}
