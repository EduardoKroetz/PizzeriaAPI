using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.Attributes;
using PizzeriaApi.ViewModels;

namespace PizzeriaApi.Controllers;

[ApiController]
[ApiKey]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(new ResultViewModel<string>("Bem vindo à PizzeriaAPI!", []));
    }
}

