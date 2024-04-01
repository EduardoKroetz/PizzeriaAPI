using System.Net;
using System.Net.Mail;
using PizzeriaApi.Models;
using PizzeriaApi.ViewModels;


namespace PizzeriaApi.Services;
public class EmailService 
{
    public async void SendEmailAsync(Email email)
    {
        var client = new SmtpClient("smtp-mail.outlook.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(Configurations.Email,Configurations.EmailPassword)
        };

        var mailMassage = new MailMessage(from: Configurations.Email, to: email.email)
        {
            Subject = email.subject,
            Body = email.message,
            IsBodyHtml = true
        };

        await client.SendMailAsync(mailMassage);
    }

    public string ShowProductsInEmail(List<Pizza> pizzas) {
        var html = "<ul>";
        foreach (var pizza in pizzas)
        {
            html += $"<li>{pizza.Category} - {pizza.Name} - {pizza.Size}</li>";
        }
        html += "</ul>";
        return html;
    }
}

