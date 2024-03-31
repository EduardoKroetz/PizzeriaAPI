using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings;
public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
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

        builder.Property(x => x.PizzaId)
            .IsRequired()
            .HasColumnName("PizzaId")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.HasOne(x => x.Pizza)
            .WithMany()
            .HasForeignKey(x => x.PizzaId)
            .HasConstraintName("FK_OrderItems_Pizzas")
            .OnDelete(DeleteBehavior.NoAction);
    }
}

