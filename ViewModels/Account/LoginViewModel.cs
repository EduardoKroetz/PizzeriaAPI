using System.ComponentModel.DataAnnotations;

namespace PizzeriaApi.ViewModels.Account;
public class LoginViewModel {
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "Informe o email no formato correto")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    [MinLength(4, ErrorMessage = "Informe a senha com no mínimo 4 caracteres")]
    public string Password { get; set; }
}

