using PizzeriaApi.Enums;
using PizzeriaApi.Models;
using PizzeriaApi.ViewModels.Account;
using PizzeriaApi.ViewModels.Address;
using PizzeriaApi.ViewModels.Payament;

namespace PizzeriaApi.ViewModels.Order;
public class GetOrderViewModel : GetOrderBase
{
    public Models.Address Address { get; set; }
    public GetAccountBase User { get; set; }
    public GetPayamentViewModel Payament { get; set; }
    public IEnumerable<GetOrderItemViewModel> Products { get; set; }
}

