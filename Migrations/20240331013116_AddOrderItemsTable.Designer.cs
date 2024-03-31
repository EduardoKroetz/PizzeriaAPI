﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzeriaApi.Data;

#nullable disable

namespace PizzeriaApi.Migrations
{
    [DbContext(typeof(PizzeriaDataContext))]
    [Migration("20240331013116_AddOrderItemsTable")]
    partial class AddOrderItemsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MenuPizzas", b =>
                {
                    b.Property<Guid>("MenuId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("MenuId", "PizzaId");

                    b.HasIndex("PizzaId");

                    b.ToTable("MenuPizzas");
                });

            modelBuilder.Entity("PizzeriaApi.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<string>("ComplementOrReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("INT")
                        .HasColumnName("Number");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Street");

                    b.HasKey("Id");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnName("Price");

                    b.Property<int>("ProductQtd")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<Guid>("CartId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("PizzaId");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Qtd")
                        .HasColumnType("INT")
                        .HasColumnName("Qtd");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("PizzaId");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(3796))
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(4167))
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("AddressId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(6053))
                        .HasColumnName("CreatedAt");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnName("Price");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Status");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(6808))
                        .HasColumnName("UpdatedAt");

                    b.Property<Guid>("UserId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("PizzaId");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Qtd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(1)
                        .HasColumnName("Qtd");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.Payament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(3029))
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Method");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnName("Price");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(3755))
                        .HasColumnName("UpdatedAt");

                    b.Property<Guid>("UserId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payaments", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.Pizza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Category");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(2270))
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Description");

                    b.Property<string>("Flavors")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Flavors");

                    b.Property<int>("InStock")
                        .HasColumnType("INT")
                        .HasColumnName("InStock");

                    b.Property<bool>("IsFrozen")
                        .HasColumnType("BIT")
                        .HasColumnName("IsFrozen");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(0)
                        .HasColumnName("Rating");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Size");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(2666))
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pizzas", (string)null);
                });

            modelBuilder.Entity("PizzeriaApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("Id");

                    b.Property<Guid>("CartId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("CartId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 56, DateTimeKind.Utc).AddTicks(2454))
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Fullname");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Image");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("BIT")
                        .HasColumnName("IsAdmin");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("PasswordHash");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 3, 31, 1, 31, 16, 56, DateTimeKind.Utc).AddTicks(2911))
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MenuPizzas", b =>
                {
                    b.HasOne("PizzeriaApi.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MenuPizzas_MenuId");

                    b.HasOne("PizzeriaApi.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MenuPizzas_PizzasId");
                });

            modelBuilder.Entity("PizzeriaApi.Models.CartItem", b =>
                {
                    b.HasOne("PizzeriaApi.Models.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Carts_CartItems");

                    b.HasOne("PizzeriaApi.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_CartItems_Pizzas");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzeriaApi.Models.Order", b =>
                {
                    b.HasOne("PizzeriaApi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Addresses");

                    b.HasOne("PizzeriaApi.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Users_Orders");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzeriaApi.Models.OrderItem", b =>
                {
                    b.HasOne("PizzeriaApi.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Orders_OrderItems");

                    b.HasOne("PizzeriaApi.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_OrderItems_Pizzas");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzeriaApi.Models.Payament", b =>
                {
                    b.HasOne("PizzeriaApi.Models.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Users_Payaments");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzeriaApi.Models.User", b =>
                {
                    b.HasOne("PizzeriaApi.Models.Cart", "Cart")
                        .WithOne("User")
                        .HasForeignKey("PizzeriaApi.Models.User", "CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Carts_Users");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("PizzeriaApi.Models.Cart", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("PizzeriaApi.Models.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PizzeriaApi.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
