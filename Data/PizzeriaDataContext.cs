using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Data.Mappings;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data;
public class PizzeriaDataContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Payament> Payaments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Order> OrderItems { get; set; }
    public DbSet<Cart> Carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine(Configurations.ConnectionString);
        //optionsBuilder.UseSqlServer(Configurations.ConnectionString);
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Pizzeria;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfiguration(new AddressMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PizzaMap());
        modelBuilder.ApplyConfiguration(new MenuMap());
        modelBuilder.ApplyConfiguration(new CartItemMap());
        modelBuilder.ApplyConfiguration(new PayamentMap());
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new CartMap());
        modelBuilder.ApplyConfiguration(new OrderItemMap());

    }
}

