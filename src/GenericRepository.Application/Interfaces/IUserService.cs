using GenericRepository.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepository.Application.Interfaces
{
  public interface IUserService
  {
    public Task<List<UserDto>> GetAll();
    public Task<UserDto> GetById(int id);
    public Task<UserDto> Add(UserDto entity);
    public Task<UserDto> Update(UserDto entity);
    public Task Delete(int id);
  }
}
