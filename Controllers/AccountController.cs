using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Data;
using PizzeriaApi.Extensions;
using PizzeriaApi.ViewModels;
using PizzeriaApi.ViewModels.Account;
using PizzeriaApi.Models;
using PizzeriaApi.Services;
using SecureIdentity.Password;

namespace PizzeriaApi.Controllers;
public class AccountController(PizzeriaDataContext context) : ControllerBase
{
    private readonly PizzeriaDataContext _context = context;
    
    [HttpPost("v1/accounts")]
    public async Task<IActionResult> Register(
        [FromBody]EditorAccountViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        try
        {
            var user = new User()
            {
                Email = model.Email,
                CreatedAt = DateTime.UtcNow.ToUniversalTime(),
                UpdatedAt = DateTime.UtcNow.ToUniversalTime(),
                Fullname = model.Fullname,
                Id = Guid.NewGuid(),
                Image = model.Image,
                PasswordHash = PasswordHasher.Hash(model.Password),
                IsAdmin = false
            };
            user.Cart = new Cart()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                User = user
            };
            user.CartId = user.Cart.Id;

            await _context.Carts.AddAsync(user.Cart);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<string>("O usuário foi registrado no banco de dados.", []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("04X01 - Esse email já está cadastrado."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("04X02 - Ocorreu um erro no servidor."));
        }
    }



    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(
        [FromBody]LoginViewModel model,
        [FromServices] TokenService tokenService) 
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        try
        {
            var user = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null || !PasswordHasher.Verify(user.PasswordHash, model.Password))
                return NotFound(new ResultViewModel<string>("Email ou senha não coincidem."));

            var token = tokenService.GenerateToken(user);

            return Ok(new ResultViewModel<string>(token, []));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("04X04 - Ocorreu um erro no servidor."));
        }
    }



    [Authorize(Roles = "Admin")]
    [HttpPost("v1/accounts/admin")]
    public async Task<IActionResult> RegisterAdmin(
        [FromBody] EditorAccountViewModel model) {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        try
        {
            var user = new User()
            {
                Email = model.Email,
                CreatedAt = DateTime.UtcNow.ToUniversalTime(),
                UpdatedAt = DateTime.UtcNow.ToUniversalTime(),
                Fullname = model.Fullname,
                Id = Guid.NewGuid(),
                Image = model.Image,
                PasswordHash = PasswordHasher.Hash(model.Password),
                IsAdmin = true
            };
            user.Cart = new Cart()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                User = user
            };
            user.CartId = user.Cart.Id;

            await _context.Carts.AddAsync(user.Cart);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<string>("O Administrador foi registrado no banco de dados.", []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("04X01 - Esse email já está cadastrado."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("04X02 - Ocorreu um erro no servidor."));
        }
    }



}


