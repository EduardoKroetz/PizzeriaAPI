using PizzeriaApi.Models;

namespace PizzeriaApi.ViewModels.Cart;
public class GetCartViewModel 
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int ProductQtd { get; set; }
    public Guid UserId { get; set; }
    public List<Models.CartItem> Products { get; set; } = [];
}

