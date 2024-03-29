﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings;
public class CartMap : IEntityTypeConfiguration<Cart> {
    public void Configure(EntityTypeBuilder<Cart> builder) {
        builder.ToTable("Carts");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL(8,2)");


        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.HasOne(x => x.User)
            .WithOne(x => x.Cart)
            .HasForeignKey<User>(x => x.CartId)
            .HasConstraintName("FK_Carts_Users");

        builder.HasMany(x => x.Products)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>
            (
                "CartCartItems",
                cart => cart.HasOne<CartItem>()
                    .WithMany()
                    .HasForeignKey("CartItemId")
                    .HasConstraintName("FK_CartCartItems_CartItem")
                    .OnDelete(DeleteBehavior.Cascade),
                cartItem => cartItem.HasOne<Cart>()
                    .WithMany()
                    .HasForeignKey("CartId")
                    .HasConstraintName("FK_CartCartItems_Cart")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}

