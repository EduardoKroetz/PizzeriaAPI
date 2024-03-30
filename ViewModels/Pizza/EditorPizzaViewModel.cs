using System.ComponentModel.DataAnnotations;
using PizzeriaApi.Enums;

namespace PizzeriaApi.ViewModels.Pizzas;

public class EditorPizzaViewModel {
    [Required(ErrorMessage = "Informe o nome da pizza")]
    public string Name { get; set; }

    public FlavorEnum Flavors { get; set; }

    public PizzaCategoryEnum Category { get; set; }

    public decimal Price { get; set; }

    public bool IsFrozen { get; set; }


    [Required(ErrorMessage = "Informe o tamanho")]
    public string Size { get; set; }

    [Required(ErrorMessage = "Informe a descrição")]
    public string Description { get; set; }

    public int InStock { get; set; }
}