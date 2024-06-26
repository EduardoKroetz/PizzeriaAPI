﻿using PizzeriaApi.Enums;

namespace PizzeriaApi.Models;
public class Order {
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public OrderStatusEnum Status { get; set; }
    public int Qtd { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public Payament Payament { get; set; }
    public List<OrderItem> Products { get; set; } 
  
}

