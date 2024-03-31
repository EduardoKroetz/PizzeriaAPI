using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Data;
using PizzeriaApi.ViewModels;
using PizzeriaApi.ViewModels.Order;
using System.Data.Common;
using System.Security.Claims;
using PizzeriaApi.Enums;
using PizzeriaApi.Extensions;
using PizzeriaApi.Models;
using PizzeriaApi.ViewModels.Address;

namespace PizzeriaApi.Controllers;

[ApiController]
[Authorize]
public class OrderController(PizzeriaDataContext context) : ControllerBase
{
    private readonly PizzeriaDataContext _context = context;

    [HttpPost("v1/orders")]
    public async Task<IActionResult> PostAsync(
        [FromBody]EditorOrderViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        try
        {
            var address = new Address()
            {
                Id = Guid.NewGuid(),
                ComplementOrReference = model.Address.ComplementOrReference,
                Number = model.Address.Number,
                Street = model.Address.Street
            };

            var order = new Order()
            {
                AddressId = address.Id,
                Address = address,
                CreatedAt = DateTime.UtcNow.ToUniversalTime(),
                UpdatedAt = DateTime.UtcNow.ToUniversalTime(),
                Id = Guid.NewGuid(),
                Status = OrderStatusEnum.Pending,
                UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)),
            };

            var products = model.Products.ConvertAll((x) =>
                {
                    var pizza = _context
                        .Pizzas
                        .AsNoTracking()
                        .Select(y => new { y.Id, y.Price })
                        .FirstOrDefault(y => y.Id == x.PizzaId);

                    order.Price += x.Qtd * pizza.Price;
                    order.Qtd += x.Qtd;

                    return new OrderItem()
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order.Id,
                        Qtd = x.Qtd,
                        PizzaId = x.PizzaId,
                        Price = x.Qtd * pizza.Price
                    };
                }
            );


            await _context.Addresses.AddAsync(address);
            await _context.OrderItems.AddRangeAsync(products);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<Order>(order));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("06X03 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("06X04 - Ocorreu um erro no servidor."));
        }
    }
}

