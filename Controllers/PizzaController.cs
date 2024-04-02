using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PizzeriaApi.Data;
using PizzeriaApi.Extensions;
using PizzeriaApi.Models;
using PizzeriaApi.ViewModels;
using PizzeriaApi.ViewModels.Pizzas;

namespace PizzeriaApi.Controllers;

[ApiController]
[Authorize]
public class PizzaController(PizzeriaDataContext context) : ControllerBase
{
    private readonly PizzeriaDataContext _context = context;

    [HttpGet("v1/pizzas")]
    public async Task<IActionResult> GetAsync(
        [FromServices]IMemoryCache cache,
        [FromQuery] int skip = 0,
        [FromQuery] int take = 25)
    {
        try
        {
            var pizzas = await cache.GetOrCreateAsync("PizzasCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(8);
                var pizzas = _context
                    .Pizzas
                    .AsNoTracking()
                    .Select(x =>
                        new GetPizzaViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Price = x.Price,
                            Flavors = x.Flavors,
                            Size = x.Size
                        })
                    .Skip(skip)
                    .Take(take)
                    .OrderBy(x => x.Price)
                    .ToListAsync();
                return pizzas;
            });

            return Ok(new ResultViewModel<List<GetPizzaViewModel>>(pizzas));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("01X02 - Ocorreu um erro no servidor."));
        }

    }



    [HttpGet("v1/pizzas/{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute]Guid id,
        [FromServices]IMemoryCache cache)
    {
        try
        {
            var pizza = await cache.GetOrCreateAsync("PizzaCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(8);
                var pizza = _context
                    .Pizzas
                    .AsNoTracking()
                    .Select(x =>
                        new GetPizzaViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Price = x.Price,
                            Flavors = x.Flavors,
                            Size = x.Size
                        })
                    .FirstOrDefaultAsync(x => x.Id == id);
                return pizza;
            });

            if (pizza == null)
                return NotFound(new ResultViewModel<string>("Pizza não encontrada."));

            return Ok(new ResultViewModel<GetPizzaViewModel>(pizza));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("01X02 - Ocorreu um erro no servidor."));
        }

    }



    [Authorize(Roles = "Admin")]
    [HttpPost("v1/pizzas")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorPizzaViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        try
        {
            var pizza = new Pizza()
            {
                Name = model.Name,
                Flavors = model.Flavors,
                Category = model.Category,
                Price = model.Price,
                Size = model.Size,
                Description = model.Description,
                Id = Guid.NewGuid(),
                InStock = model.InStock,
                CreatedAt = DateTime.UtcNow.ToUniversalTime(),
                UpdatedAt = DateTime.UtcNow.ToUniversalTime(),
                IsFrozen = model.IsFrozen,
                Rating = 0
            };

            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(
                new
                {
                    id = pizza.Id
                }, []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500,
                new ResultViewModel<string>("01X03 - Não foi possível inserir os dados no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("01X04 - Ocorreu um erro no servidor."));
        }

    }



    [Authorize(Roles = "Admin")]
    [HttpPut("v1/pizzas/{id:guid}")]
    public async Task<IActionResult> PutAsync(
        [FromBody] EditorPizzaViewModel model,
        [FromRoute]Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        try
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == id);

            if (pizza == null)
                return NotFound(new ResultViewModel<string>("Pizza não encontrada."));

            pizza.Name = model.Name;
            pizza.Flavors = model.Flavors;
            pizza.Category = model.Category;
            pizza.Price = model.Price;
            pizza.Size = model.Size;
            pizza.Description = model.Description;
            pizza.InStock = model.InStock;
            pizza.UpdatedAt = DateTime.UtcNow.ToUniversalTime();
            pizza.IsFrozen = model.IsFrozen;


            _context.Pizzas.Update(pizza);
            await _context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(
                new
                {
                    id = pizza.Id
                }, []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500,
                new ResultViewModel<string>("01X03 - Não foi possível inserir os dados no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("01X04 - Ocorreu um erro no servidor."));
        }


    }



    [Authorize(Roles = "Admin")]

    [HttpDelete("v1/pizzas/{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute]Guid id) {
        try
        {
            var pizza = await _context
                .Pizzas
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (pizza == null)
                return NotFound(new ResultViewModel<string>("Pizza não encontrada."));

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(new { id = pizza.Id }, []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500,
                new ResultViewModel<string>("01X04 - Não foi possível deletar a pizza do banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("01X02 - Ocorreu um erro no servidor."));
        }
    }


}

