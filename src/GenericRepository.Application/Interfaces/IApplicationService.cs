using GenericRepository.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepository.Application.Interfaces
{
  public interface IApplicationService
  {
    public Task<List<ApplicationDto>> GetAll();
    public Task<ApplicationDto> GetById(int id);
    public Task<ApplicationDto> Add(ApplicationDto entity);
    public Task<ApplicationDto> Update(ApplicationDto entity);
    public Task Delete(int id);
  }
}
