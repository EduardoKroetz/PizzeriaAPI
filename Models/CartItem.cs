namespace PizzeriaApi.Models;
public class CartItem {
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Qtd { get; set; }
    public Guid CartId { get; set; }
    public Guid PizzaId { get; set; }
    public Pizza Pizza { get; set; }

}

