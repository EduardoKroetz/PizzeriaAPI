using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings;
public class CartItemMap : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");

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
            .IsRequired()
            .HasColumnName("Qtd")
            .HasColumnType("INT");

        builder.Property(x => x.PizzaId)
            .IsRequired()
            .HasColumnName("PizzaId")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.HasIndex(x => x.PizzaId);

        builder.HasOne(x => x.Pizza)
            .WithMany()
            .HasForeignKey(x => x.PizzaId)
            .HasConstraintName("FK_CartItems_Pizzas")
            .OnDelete(DeleteBehavior.NoAction);
    }
}


