using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings {
    public class PayamentMap : IEntityTypeConfiguration<Payament> {
        public void Configure(EntityTypeBuilder<Payament> builder) 
        {
            builder.ToTable("Payaments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(x => x.Method)
                .HasColumnName("Method")
                .HasMaxLength(30)
                .HasConversion<string>();

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("DECIMAL(8,2)");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());


            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.UtcNow.ToUniversalTime());

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.HasIndex(x => x.UserId);


        }
    }
}
