using PizzeriaApi.Enums;

namespace PizzeriaApi.Models;
public class Pizza {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public FlavorEnum Flavors { get; set; }
    public PizzaCategoryEnum Category { get; set; }
    public decimal Price { get; set; }
    public bool IsFrozen { get; set; }
    public string Size { get; set; }
    public string Description { get; set; }
    public int InStock { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid MenuId { get; set; }

}