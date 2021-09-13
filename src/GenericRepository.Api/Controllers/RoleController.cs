using GenericRepository.Application.Dto;
using GenericRepository.Application.Interfaces;
using GenericRepository.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RoleController : ControllerBase
  {
    private readonly IRoleService _applicationService;
    
    public RoleController(IRoleService roleService)
    {
      _applicationService = roleService;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> Get()
    {
      var results = await _applicationService.GetAll();
      return Ok(results);
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _applicationService.GetById(id);
      return Ok(result);
    }

    [HttpPost("insert")]
    public async Task<IActionResult> Insert(RoleDto entity)
    {
      var result = await _applicationService.Add(entity);
      return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(RoleDto entity)
    {
      var result = await _applicationService.Update(entity);
      return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
      await _applicationService.Delete(id);
      return Ok();
    }
  }
}
