using Exercise1.Application.TaskManagement.Dtos;
using Exercise1.Application.TaskManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Exercise1.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeTaskController : ControllerBase
{
    private readonly IEmployeeTaskService _employeeTaskService;
    public EmployeeTaskController(IEmployeeTaskService employeeTaskService)
    {
        _employeeTaskService = employeeTaskService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute][Required] long Id)
    {
        var result  = await _employeeTaskService.GetAsync(Id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string filter)
    {
        var result = await _employeeTaskService.GetAll(filter);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] EmployeeTaskDto model)
    {
        var result = await _employeeTaskService.AddAsync(model);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EmployeeTaskDto model)
    {
        var result = await _employeeTaskService.UpdateAsync(model);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute][Required] long Id)
    {
        var result = await _employeeTaskService.DeleteAsync(Id);
        return Ok(result);
    }
}
