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

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnName("Status")
            .HasConversion<string>();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME2")
            .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnType("DATETIME2")
            .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


        builder.Property(x => x.AddressId)
            .HasColumnName("AddressId")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .HasConstraintName("FK_Orders_Addresses")
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("UNIQUEIDENTIFIER");


        builder.HasMany(x => x.Pizzas)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>
            (
                "OrderPizzas",
                order => order.HasOne<Pizza>()
                    .WithMany()
                    .HasForeignKey("PizzaId")
                    .HasConstraintName("FK_OrderPizzas_Pizzas")
                    .OnDelete(DeleteBehavior.Cascade),
                pizza => pizza.HasOne<Order>()
                    .WithMany()
                    .HasForeignKey("OrderId")
                    .HasConstraintName("FK_OrderPizzas_Orders")
                    .OnDelete(DeleteBehavior.Cascade)
            );

    }
}
