using System.ComponentModel.DataAnnotations;

namespace PizzeriaApi.ViewModels.Address;
public class EditorAddressViewModel 
{
    [Required(ErrorMessage = "Informe o nome da rua")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Informe o número da casa")]
    public int Number { get; set; }
    public string ComplementOrReference { get; set; } = "";
}

