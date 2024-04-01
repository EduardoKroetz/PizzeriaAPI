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

[ApiController]
public class AccountController(PizzeriaDataContext context) : ControllerBase
{
    private readonly PizzeriaDataContext _context = context;
    
    [HttpPost("v1/accounts")]
    public async Task<IActionResult> Register(
        [FromBody]EditorAccountViewModel model,
        [FromServices]EmailService emailService,
        [FromServices]ImageService imageService)
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

            var email = new Email()
            {
                email = model.Email,
                message = "<h1>Olá e bem-vindo à PizzeriaAPI!</h1>",
                subject = "Imagine um mundo de deliciosas possibilidades, onde cada pedido de pizza é uma jornada culinária única e personalizada. Bem, agora você não precisa mais apenas imaginar! Com a PizzeriaAPI, você tem acesso a uma plataforma poderosa que vai revolucionar a forma como você interage com pedidos de pizza online."
            };

            user.Image = await imageService.SaveImageAsync(model.Image);
            emailService.SendEmailAsync(email);

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
                return NotFound(new ResultViewModel<string>("04X03 - Email ou senha não coincidem."));

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
            return StatusCode(500, new ResultViewModel<string>("04X05 -Esse email já está cadastrado."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("04X06 - Ocorreu um erro no servidor."));
        }
    }



    [Authorize]
    [HttpDelete("v1/accounts/{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] Guid id)
    {
        try
        {
            var user = await _context
                .Users
                .Include(x => x.Cart)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound(new ResultViewModel<string>("04X07 -Usuário não encontrado."));

            _context.Carts.Remove(user.Cart);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new ResultViewModel<string>("O usuário foi deletado do banco de dados", []));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<string>("04X08 - Esse email já está cadastrado."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("04X09 - Ocorreu um erro no servidor."));
        }
  
    }
}

 
