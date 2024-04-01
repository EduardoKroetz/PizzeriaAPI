using PizzeriaApi.Models;

namespace PizzeriaApi.ViewModels.Cart;
public class GetCartViewModel : GetCartBase
{
    public Guid UserId { get; set; }
    public List<Models.CartItem> Products { get; set; } = [];
}

