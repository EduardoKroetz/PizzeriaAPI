using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.Data;
using PizzeriaApi.ViewModels;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Extensions;
using PizzeriaApi.Models;
using PizzeriaApi.ViewModels.Menu;
using PizzeriaApi.ViewModels.Pizzas;

namespace PizzeriaApi.Controllers;

[ApiController]
public class MenuController(PizzeriaDataContext context) : ControllerBase
{
    private readonly PizzeriaDataContext _context = context;

    [HttpGet("v1/menus")]
    public async Task<IActionResult> GetAsync(
        ) 
    {
        try
        {
            var menus = await context 
                .Menus
                .AsNoTracking()
                .Include(x => x.Pizzas)
                .Select(x => new GetMenuViewModel()
                {
                
                    Id = x.Id,
                    Name = x.Name,
                    Pizzas = x.Pizzas.Select(y => new GetPizzaViewModel()
                    {
                        Category = y.Category,
                        Flavors = y.Flavors,
                        Id = y.Id,
                        Name = y.Name,
                        Price = y.Price,
                        Size = y.Size
                    })
                })
                .ToListAsync();
            
            return Ok(new ResultViewModel<List<GetMenuViewModel>>(menus));
        }
        catch (DbException)
        {
            return StatusCode(500, new ResultViewModel<string>("02X01 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("02X02 - Ocorreu um erro no servidor."));
        }

    }



    [HttpGet("v1/menus/{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute]Guid id) {
        try
        {
            var menu = await _context
                .Menus
                .AsNoTracking()
                .Include(x => x.Pizzas)
                .Select(x => new GetMenuViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Pizzas = x.Pizzas.Select(y => new GetPizzaViewModel()
                    {
                        Category = y.Category,
                        Flavors = y.Flavors,
                        Id = y.Id,
                        Name = y.Name,
                        Price = y.Price,
                        Size = y.Size
                    })
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (menu == null)
                return NotFound(new ResultViewModel<string>("02X03 - Não foi possível encontrar o menu"));

            return Ok(new ResultViewModel<GetMenuViewModel>(menu));
        }
        catch (DbException)
        {
            return StatusCode(500, new ResultViewModel<string>("02X04 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("02X05 - Ocorreu um erro no servidor."));
        }

    }





    [HttpPost("v1/menus")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorMenuViewModel model) {
        try
        {
            var menu = new Menu()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow.ToUniversalTime(),
                UpdatedAt = DateTime.UtcNow.ToUniversalTime(),
                Name = model.Name
            };
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<dynamic>(new { id = menu.Id }, []));
        }
        catch (DbException)
        {
            return StatusCode(500, new ResultViewModel<string>("02X06 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("02X07 - Ocorreu um erro no servidor."));
        }

    }



    [HttpPut("v1/menus/{id:guid}")]
    public async Task<IActionResult> PutAsync(
        [FromBody] EditorMenuViewModel model,
        [FromRoute]Guid id) {
        try
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

            if (menu == null)
                return NotFound(new ResultViewModel<string>("02X08 - Não foi possível encontrar o menu"));

            menu.Name = model.Name;

            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<dynamic>(new { id = menu.Id }, []));
        }
        catch (DbException)
        {
            return StatusCode(500, new ResultViewModel<string>("02X09 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("02X10 - Ocorreu um erro no servidor."));
        }

    }


    [HttpDelete("v1/menus/{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] Guid id) {
        try
        {
            var menu = await _context
                .Menus
                .FirstOrDefaultAsync(x => x.Id == id);

            if (menu == null)
                return NotFound(new ResultViewModel<string>("02X11 - Não foi possível encontrar o menu"));

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<dynamic>(new { id = menu.Id }, []));
        }
        catch (DbException)
        {
            return StatusCode(500, new ResultViewModel<string>("02X12 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("02X13 - Ocorreu um erro no servidor."));
        }

    }




}
