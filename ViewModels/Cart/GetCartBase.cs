namespace PizzeriaApi.ViewModels.Cart;
public class GetCartBase 
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int ProductQtd { get; set; }
}

