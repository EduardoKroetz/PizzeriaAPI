namespace PizzeriaApi.Models;
public class Address 
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string ComplementOrReference { get; set; }
}

