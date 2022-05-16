using Exercise1.Application.MasterData.Interfaces.Services;
using Exercise1.Application.TaskManagement.Dtos;
using Exercise1.Application.TaskManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Exercise1.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute][Required] long Id)
    {
        var result  = await _projectService.GetAsync(Id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string filter)
    {
        var result = await _projectService.GetAll(filter);
        return Ok(result);
    }
}
