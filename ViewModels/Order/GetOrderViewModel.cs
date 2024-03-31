using PizzeriaApi.Enums;
using PizzeriaApi.Models;
using PizzeriaApi.ViewModels.Account;
using PizzeriaApi.ViewModels.Address;

namespace PizzeriaApi.ViewModels.Order;
public class GetOrderViewModel 
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public OrderStatusEnum Status { get; set; }
    public int Qtd { get; set; }
    public Guid AddressId { get; set; }
    public Models.Address Address { get; set; }
    public Guid UserId { get; set; }
    public GetAccountViewModel User { get; set; }
    public IEnumerable<GetOrderItemViewModel> Products { get; set; }
}

