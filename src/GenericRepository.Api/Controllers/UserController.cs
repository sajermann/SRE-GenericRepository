using GenericRepository.Application.Dto;
using GenericRepository.Application.Interfaces;
using GenericRepository.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> Get()
    {
      var results = await _userService.GetAll();
      return Ok(results);
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _userService.GetById(id);
      return Ok(result);
    }

    [HttpPost("insert")]
    public async Task<IActionResult> Insert(UserDto entity)
    {
      var result = await _userService.Add(entity);
      return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UserDto entity)
    {
      var result = await _userService.Update(entity);
      return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
      await _userService.Delete(id);
      return Ok();
    }
  }
}
