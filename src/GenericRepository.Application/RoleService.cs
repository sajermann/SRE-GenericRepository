using AutoMapper;
using GenericRepository.Application.Dto;
using GenericRepository.Application.Interfaces;
using GenericRepository.Data.Interfaces;
using GenericRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Application
{
  public class RoleService : IRoleService
  {
    private readonly IGenericRepository<Role> _genericRepository;
    private readonly IMapper _mapper;

    public RoleService(IGenericRepository<Role> genericRepository, IMapper mapper)
    {
      _genericRepository = genericRepository;
      _mapper = mapper;
    }

    public async Task<List<RoleDto>> GetAll()
    {
      var results = _mapper.Map<List<RoleDto>>(await _genericRepository.Find());
      return results;
    }

    public async Task<RoleDto> GetById(int id)
    {
      var results = _mapper.Map<List<RoleDto>>(await _genericRepository.Find(where: b=>b.Id == id));
      return results.FirstOrDefault();
    }

    public async Task<RoleDto> Add(RoleDto entity)
    {
      var result = await _genericRepository.AddOrUpdate(_mapper.Map<Role>(entity));
      return _mapper.Map<RoleDto>(result);
    }

    public async Task<RoleDto> Update(RoleDto entity)
    {
      var result = await _genericRepository.AddOrUpdate(_mapper.Map<Role>(entity));
      return _mapper.Map<RoleDto>(result);
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
