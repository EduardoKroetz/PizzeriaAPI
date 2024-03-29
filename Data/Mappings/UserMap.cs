using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings;
public class UserMap : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) 
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Fullname)
            .IsRequired()
            .HasColumnName("Fullname")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Number")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(160);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnName("PasswordHash")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(150);

        builder.Property(x => x.Image)
            .IsRequired()
            .HasColumnName("Image")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);


        builder.Property(x => x.IsAdmin)
            .IsRequired()
            .HasColumnName("IsAdmin")
            .HasColumnType("BIT");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME2")
            .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnType("DATETIME2")
            .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


        builder.Property(x => x.CartId)
            .HasColumnName("CartId")
            .HasColumnType("UNIQUEIDENTIFIER");

        //RELAÇÕES

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("FK_Users_Orders")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Payments)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("FK_Users_Payaments")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Cart)
            .WithOne(x => x.User)
            .HasForeignKey<Cart>(x => x.UserId)
            .HasConstraintName("FK_Users_Carts");

    }
}

