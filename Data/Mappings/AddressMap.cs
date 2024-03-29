﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data.Mappings;
public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Street)
            .IsRequired()
            .HasColumnName("Street")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(150);

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnName("Number")
            .HasColumnType("INT");

    }
}

