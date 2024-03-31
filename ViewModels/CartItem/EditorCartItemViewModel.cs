using System.ComponentModel.DataAnnotations;
using PizzeriaApi.Models;

namespace PizzeriaApi.ViewModels.CartItem;
public class EditorCartItemViewModel 
{
    public int Qtd { get; set; } = 1;
    [Required(ErrorMessage = "Informe o ID da pizza")]
    public Guid PizzaId { get; set; }
}

