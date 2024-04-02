using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Models;
using System.Security.Claims;using System.Security.Claims;
using PizzeriaApi.ViewModels;
using PizzeriaApi.ViewModels.Order;
using PizzeriaApi.Data;
using PizzeriaApi.ViewModels.Payament;

namespace PizzeriaApi.Controllers;
[ApiController]
[Authorize]
public class PayamentController(PizzeriaDataContext context) : ControllerBase {
    private readonly PizzeriaDataContext _context = context;

    [HttpGet("v1/payaments")]
    public async Task<IActionResult> Get()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        try
        {
            var payaments = await _context
                .Payaments
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => new GetPayamentViewModel()
                {
                    Price = x.Price,
                    Finish = x.Finish,
                    Id = x.Id,
                    Method = x.Method
                })
                .ToListAsync();

            return Ok(new ResultViewModel<List<GetPayamentViewModel>>(payaments));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("07X01 - Ocorreu um erro no servidor."));
        }
    }



    [HttpGet("v1/pendings-payaments")]
    public async Task<IActionResult> GetPendings() {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        try
        {
            var payaments = await _context
                .Payaments
                .AsNoTracking()
                .Where(x => x.UserId == userId && x.Finish == false)
                .Select(x => new GetPayamentViewModel()
                {
                    Price = x.Price,
                    Finish = x.Finish,
                    Id = x.Id,
                    Method = x.Method
                })
                .ToListAsync();

            return Ok(new ResultViewModel<List<GetPayamentViewModel>>(payaments));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("07X02 - Ocorreu um erro no servidor."));
        }
    }



    [HttpGet("v1/payaments/{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute]Guid id) {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        try
        {
            var payament = await _context
                .Payaments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new GetPayamentViewModel()
                {
                    Price = x.Price,
                    Finish = x.Finish,
                    Id = x.Id,
                    Method = x.Method
                })
                .FirstOrDefaultAsync();

            if (payament == null)
                NotFound(new ResultViewModel<string>("Pagamento não encontrado"));

            return Ok(new ResultViewModel<GetPayamentViewModel>(payament));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("07X03 - Ocorreu um erro no servidor."));
        }
    }

    [HttpPatch("v1/payaments/pay/{id:guid}")]
    public async Task<IActionResult> Pay(
        [FromRoute] Guid id) {
        try
        {
            var payament = await _context
                .Payaments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (payament == null)
                NotFound(new ResultViewModel<string>("Não foi possível encontrar o pagamento"));

            if (payament.Finish)
                NotFound(new ResultViewModel<string>("Esse pagamento já foi finalizado."));

            payament.Finish = true;

            _context.Payaments.Update(payament);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<string>("Pagamento realizado!", []));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("07X03 - Ocorreu um erro no servidor."));
        }
    }
}