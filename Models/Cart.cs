namespace PizzeriaApi.Models;
public class Cart {
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int ProductQtd { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public List<CartItem> Products { get; set; }


}

