using PizzeriaApi.Enums;

namespace PizzeriaApi.ViewModels.Payament;
public class GetPayamentViewModel 
{
    public Guid Id { get; set; }
    public PayamentMethodEnum Method { get; set; }
    public bool Finish { get; set; } = false;
    public decimal Price { get; set; }
}


