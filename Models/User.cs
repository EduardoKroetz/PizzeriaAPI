namespace PizzeriaApi.Models;
public class User {
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Image { get; set; }
    public bool IsAdmin { get; set; }
    public List<Order> Orders { get; set; } = [];
}

