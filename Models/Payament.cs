using PizzeriaApi.Enums;

namespace PizzeriaApi.Models;
public class Payament {
    public Guid Id { get; set; }
    public PayamentMethodEnum Method { get; set; }
    public decimal Price { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}

