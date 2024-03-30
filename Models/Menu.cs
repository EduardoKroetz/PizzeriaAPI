﻿namespace PizzeriaApi.Models;
public class Menu 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Pizza> Pizzas { get; set; } = [];
}

