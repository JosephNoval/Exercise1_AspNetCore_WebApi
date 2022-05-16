using Exercise1.Application.MasterData.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Exercise1.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute][Required] long Id)
    {
        var result  = await _employeeService.GetAsync(Id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string filter)
    {
        var result = await _employeeService.GetAll(filter);
        return Ok(result);
    }
}
