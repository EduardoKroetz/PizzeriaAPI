using PizzeriaApi.Enums;

namespace PizzeriaApi.ViewModels.Pizzas;
public class GetPizzaViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public FlavorEnum Flavors { get; set; }
    public PizzaCategoryEnum Category { get; set; }
    public decimal Price { get; set; }
    public string Size { get; set; }

}

