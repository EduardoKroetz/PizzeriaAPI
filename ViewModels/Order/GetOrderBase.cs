using PizzeriaApi.Enums;
using PizzeriaApi.Models;

namespace PizzeriaApi.ViewModels.Order;
public class GetOrderBase 
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public OrderStatusEnum Status { get; set; }
    public int Qtd { get; set; }
    public Guid AddressId { get; set; }
    public Guid UserId { get; set; }
}

