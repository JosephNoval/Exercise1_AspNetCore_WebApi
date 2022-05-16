using Exercise1.Application.MasterData.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Exercise1.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute][Required] long Id)
    {
        var result  = await _taskService.GetAsync(Id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string filter)
    {
        var result = await _taskService.GetAll(filter);
        return Ok(result);
    }

    [HttpGet("get-by-project")]
    public async Task<IActionResult> GetByProject([Required] long projectId)
    {
        var result = await _taskService.GetByProjectAsync(projectId);
        return Ok(result);
    }

}
