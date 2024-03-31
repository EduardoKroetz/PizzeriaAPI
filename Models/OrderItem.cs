namespace PizzeriaApi.Models;
public class OrderItem
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Qtd { get; set; }
    public Guid OrderId { get; set; }
    public Guid PizzaId { get; set; }
    public Pizza Pizza { get; set; }
}

