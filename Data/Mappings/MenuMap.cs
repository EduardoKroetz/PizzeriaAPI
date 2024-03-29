using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings {
    public class MenuMap : IEntityTypeConfiguration<Menu> 
    {
        public void Configure(EntityTypeBuilder<Menu> builder) 
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


            builder.HasMany(x => x.Pizzas)
                .WithOne()
                .HasForeignKey(x => x.MenuId)
                .HasConstraintName("FK_Menus_Pizzas")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
