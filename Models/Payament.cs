using PizzeriaApi.Enums;

namespace PizzeriaApi.Models;
public class Payament {
    public Guid Id { get; set; }
    public PayamentMethodEnum Method { get; set; }
    public bool Finish { get; set; } = false;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}

