using PizzeriaApi.Enums;

namespace PizzeriaApi.Models;
public class Order {
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public OrderStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public List<OrderItem> Products { get; set; } 
  
}

