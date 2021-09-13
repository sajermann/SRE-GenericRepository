using GenericRepository.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepository.Application.Interfaces
{
  public interface IRoleService
  {
    public Task<List<RoleDto>> GetAll();
    public Task<RoleDto> GetById(int id);
    public Task<RoleDto> Add(RoleDto entity);
    public Task<RoleDto> Update(RoleDto entity);
    public Task Delete(int id);
  }
}
