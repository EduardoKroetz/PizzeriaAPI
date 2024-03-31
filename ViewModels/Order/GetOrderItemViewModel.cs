namespace PizzeriaApi.ViewModels.Order;
public class GetOrderItemViewModel 
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Qtd { get; set; }
    public Guid PizzaId { get; set; }
}

