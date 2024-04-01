using PizzeriaApi.ViewModels.Cart;

namespace PizzeriaApi.ViewModels.Account;
public class GetAccountWithCartViewModel : GetAccountBase
{
    public GetCartBase Cart { get; set; }
}

