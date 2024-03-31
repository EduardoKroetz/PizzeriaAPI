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
using PizzeriaApi.ViewModels.Account;
using PizzeriaApi.ViewModels.Address;

namespace PizzeriaApi.Controllers;

[ApiController]
[Authorize]
public class OrderController(PizzeriaDataContext context) : ControllerBase {
    private readonly PizzeriaDataContext _context = context;


    [HttpGet("v1/orders")]
    public async Task<IActionResult> GetAsync(){
        try
        {
            var orders = await _context
                .Orders
                .AsNoTracking()
                .Select(x => new GetAllOrderViewModel()
                {
                    Price = x.Price,
                    AddressId = x.AddressId,
                    Id = x.Id,
                    Qtd = x.Qtd,
                    UserId = x.UserId,
                    Status = x.Status
                })
                .ToListAsync();

            return Ok(new ResultViewModel<List<GetAllOrderViewModel>>(orders));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("06X09 - Ocorreu um erro no servidor."));
        }
    }



    [HttpGet("v1/orders/{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id) {
        try
        {
            var order = await _context
                .Orders
                .AsNoTracking()
                .Include(x => x.Products)
                .Include(x => x.Address)
                .Include(x => x.User)
                .Select(x => new GetOrderViewModel()
                {
                    Price = x.Price,
                    AddressId = x.AddressId,
                    Id = x.Id,
                    Qtd = x.Qtd,
                    UserId = x.UserId,
                    Status = x.Status,
                    Products = x.Products.Select(y => new GetOrderItemViewModel()
                    {
                        Id = y.Id,
                        PizzaId = y.PizzaId,
                        Price = y.Price,
                        Qtd = y.Qtd
                    }),
                    Address = x.Address,
                    User = new GetAccountViewModel()
                    {
                        Id = x.User.Id,
                        Email = x.User.Email,
                        Fullname = x.User.Fullname,
                    }
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound(new ResultViewModel<string>("06X08 - Não foi possível encontrar a ordem."));

            return Ok(new ResultViewModel<GetOrderViewModel>(order));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("06X09 - Ocorreu um erro no servidor."));
        }
    }



    [HttpPost("v1/orders")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorOrderViewModel model) {
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
            address.OrderId = order.Id;
            var products = new List<OrderItem>();
            try
            {
                products = model.Products.ConvertAll((x) =>
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
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("06X10 - Verifique as informações e tente novamente"));

            }

            await _context.Addresses.AddAsync(address);
            await _context.OrderItems.AddRangeAsync(products);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<dynamic>(new { OrderId = order.Id }));
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



    [HttpDelete("v1/orders/{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute]Guid id) 
    {
        try
        {
            var order = await _context
                .Orders
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound(new ResultViewModel<string>("06X05 Não foi possível encontrar a ordem."));

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<string>("Ordem deletada.", []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("06X06 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("06X07 - Ocorreu um erro no servidor."));
        }
    }
}

