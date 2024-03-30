using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Data;
using PizzeriaApi.ViewModels;

namespace PizzeriaApi.Controllers;

public class MenuPizzaController(PizzeriaDataContext context) : ControllerBase
{
    private readonly PizzeriaDataContext _context = context;

    [HttpPost("v1/menus-pizzas/{menuId:guid}/{pizzaId:guid}")]
    public async Task<IActionResult> AddPizzaToMenu(
        [FromRoute] Guid menuId,
        [FromRoute] Guid pizzaId) {
        try
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == menuId);

            if (menu == null)
                return NotFound(new ResultViewModel<string>("03X01 - Não foi possível encontrar o menu"));

            var pizza = await _context.Pizzas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == pizzaId);

            if (pizza == null)
                return NotFound(new ResultViewModel<string>("03X02 - Não foi possível encontrar a pizza"));

            menu.Pizzas.Add(pizza);

            await _context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(new { id = menu.Id }, []));
        }
        catch (DbException)
        {
            return StatusCode(500, new ResultViewModel<string>("03X03 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("03X04 - Ocorreu um erro no servidor."));
        }

    }


    [HttpDelete("v1/menus-pizzas/{menuId:guid}/{pizzaId:guid}")]
    public async Task<IActionResult> RemovePizzaFromMenu(
        [FromRoute] Guid menuId,
        [FromRoute] Guid pizzaId) {
        try
        {
            var menu = await _context
                .Menus
                .Include(x => x.Pizzas)
                .FirstOrDefaultAsync(x => x.Id == menuId);

            if (menu == null)
                return NotFound(new ResultViewModel<string>("03X05 - Não foi possível encontrar o menu"));

            var pizza = menu.Pizzas.FirstOrDefault(x => x.Id == pizzaId);

            if (pizza == null)
                return NotFound(new ResultViewModel<string>("03X06 - Não foi possível encontrar a pizza"));

            menu.Pizzas.Remove(pizza);

            await _context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(new { id = menu.Id }, []));
        }
        catch (DbException)
        {
            return StatusCode(500, new ResultViewModel<string>("03X07 - Ocorreu um erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("03X08 - Ocorreu um erro no servidor."));
        }
    }
}




