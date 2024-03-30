using PizzeriaApi.Models;
using PizzeriaApi.ViewModels.Pizzas;

namespace PizzeriaApi.ViewModels.Menu {
    public class GetMenuViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetPizzaViewModel> Pizzas { get; set; }
    }
}
