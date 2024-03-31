using System.ComponentModel.DataAnnotations;
using PizzeriaApi.Enums;
using PizzeriaApi.ViewModels.Address;

namespace PizzeriaApi.ViewModels.Order;
public class EditorOrderViewModel 
{
    [Required(ErrorMessage = "Informe o endereço")]
    public EditorAddressViewModel Address{ get; set; }

    public PayamentMethodEnum Method { get; set; }

    [Required(ErrorMessage = "Informe os produtos")]
    public List<EditorOrderItemViewModel> Products { get; set; }
}

