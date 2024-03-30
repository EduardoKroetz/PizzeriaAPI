using System.ComponentModel.DataAnnotations;

namespace PizzeriaApi.ViewModels.Account;
public class EditorAccountViewModel {
    [Required(ErrorMessage = "Informe o nome completo")]
    public string Fullname { get; set; }
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "Informe o email no formato correto")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    [MinLength(4,ErrorMessage = "Informe a senha com no mínimo 4 caracteres")]
    public string Password { get; set; }
    public string Image { get; set; }
}

