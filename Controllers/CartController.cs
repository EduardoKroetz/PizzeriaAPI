using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.Data;
using PizzeriaApi.ViewModels;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Models;
using PizzeriaApi.ViewModels.Menu;
using PizzeriaApi.ViewModels.Pizzas;
using Microsoft.AspNetCore.Authorization;
using PizzeriaApi.ViewModels.Cart;
using PizzeriaApi.ViewModels.CartItem;

namespace PizzeriaApi.Controllers;

[ApiController]
[Authorize]
public class CartController(PizzeriaDataContext context) : ControllerBase {
    private readonly PizzeriaDataContext _context = context;

    [HttpGet("v1/carts/{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id) {
        try
        {
            var cart = await _context
                .Carts
                .AsNoTracking()
                .Include(x => x.Products)
                .Select(x => new GetCartViewModel()
                {
                    Id = x.Id,
                    Products = x.Products,
                    Price = x.Price,
                    UserId = x.UserId,
                    ProductQtd = x.ProductQtd
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cart == null)
                return NotFound(new ResultViewModel<string>("05X01 - Não foi possível encontrar o carrinho"));

            return Ok(new ResultViewModel<GetCartViewModel>(cart));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("05X02 - Ocorreu um erro no servidor."));
        }

    }



    [Authorize]
    [HttpPost("v1/carts/{id:guid}")]
    public async Task<IActionResult> AddItemAsync(
        [FromRoute]Guid id,
        [FromBody]EditorCartItemViewModel model)
    {
        try
        {
            var cart = await _context
                .Carts
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cart == null)
                return NotFound(new ResultViewModel<string>("05X03 - Não foi possível encontrar o carrinho"));

            var pizza = await _context.Pizzas
                .AsNoTracking()
                .Select(x => new { x.Id, x.Price, x.InStock })
                .FirstOrDefaultAsync(x => x.Id == model.PizzaId);

            if (pizza == null)
                return NotFound(new ResultViewModel<string>("05X04 - Não foi possível encontrar a pizza"));

            if (pizza.InStock == 0)
                return BadRequest(new ResultViewModel<string>("05X05 - A pizza não possui disponibilidade."));

            var cartItem = new CartItem()
            {
                Id = Guid.NewGuid(),
                PizzaId = model.PizzaId,
                Qtd = model.Qtd,
                Price = pizza.Price * model.Qtd
            };

            await _context.CartItems.AddAsync(cartItem);
            cart.Products.Add(cartItem);
            cart.Price += cartItem.Price;
            cart.ProductQtd += cartItem.Qtd;

            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();


            return Ok(new ResultViewModel<dynamic>(new {cartItem.Id}));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("05X06 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("05X07 - Ocorreu um erro no servidor."));
        }
    }



    [Authorize]
    [HttpDelete("v1/carts/{id:guid}/{itemId:guid}")]
    public async Task<IActionResult> RemoveItemAsync(
        [FromRoute] Guid id,
        [FromRoute]Guid itemId) {
        try
        {
            var cart = await _context
                .Carts
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cart == null)
                return NotFound(new ResultViewModel<string>("05X08 - Não foi possível encontrar o carrinho"));

            var cartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == itemId);

            if (cartItem == null)
                return NotFound(new ResultViewModel<string>("05X09 - Não foi possível encontrar o item do carrinho"));

            cart.Products.Remove(cartItem);
            cart.Price -= cartItem.Price;
            cart.ProductQtd -= cartItem.Qtd;
       
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<string>("Item do carrinho deletado com sucesso.", []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("05X010 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("05X11 - Ocorreu um erro no servidor."));
        }
    }



    [Authorize]
    [HttpPut("v1/carts/{id:guid}/{itemId:guid}")]
    public async Task<IActionResult> PutItemAsync(
        [FromRoute] Guid id,
        [FromRoute]Guid itemId,
        [FromBody] EditorCartItemViewModel model) {
        try
        {
            var cart = await _context
                .Carts
                .Include(x => x.Products)
                    .ThenInclude(y => y.Pizza)
                .Where(x => x.Id == id && x.Products.Any(y => y.Id == itemId))
                .Select(x => new Cart()
                {
                    Id = x.Id,
                    Products = x.Products.Where(y => y.Id == itemId)
                        .Select(y => new CartItem()
                        {
                            Id = y.Id,
                            Pizza = y.Pizza,
                            Qtd = y.Qtd,
                            Price = y.Price
                        }).ToList(),
                    Price = x.Price,
                    ProductQtd = x.ProductQtd,
                })
                .FirstOrDefaultAsync();

            if (cart == null)
                return NotFound(new ResultViewModel<string>("05X12 - Não foi possível encontrar o carrinho"));

            var cartItem = cart.Products[0];

            if (cartItem.Pizza.InStock < model.Qtd)
                return NotFound(new ResultViewModel<string>("05X16 - Sem disponibilidade suficiente para essa quantidade"));

 
            cart.Price = (cart.Price - cartItem.Price) + model.Qtd * cartItem.Pizza.Price; //remove o preço anterior substituindo pelo novo
            cart.ProductQtd = cart.ProductQtd - cartItem.Qtd + model.Qtd; //remove a quantidade anterior substituindo pela nova
            cartItem.Qtd = model.Qtd;
            cartItem.Price = model.Qtd * cartItem.Pizza.Price;

            _context.CartItems.Update(cartItem);
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();


            return Ok(new ResultViewModel<dynamic>(new { itemId }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("05X17 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("05X18 - Ocorreu um erro no servidor."));
        }
    }


}
