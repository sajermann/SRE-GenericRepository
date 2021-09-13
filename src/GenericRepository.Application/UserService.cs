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
  public class UserService: IUserService
  {
    private readonly IGenericRepository<User> _genericRepository;
    private readonly IMapper _mapper;

    public UserService(IGenericRepository<User> genericRepository, IMapper mapper)
    {
      _genericRepository = genericRepository;
      _mapper = mapper;
    }

    public async Task<List<UserDto>> GetAll()
    {
      var results = _mapper.Map<List<UserDto>>(await _genericRepository.Find());
      return results;
    }

    public async Task<UserDto> GetById(int id)
    {
      var results = _mapper.Map<List<UserDto>>(await _genericRepository.Find(where: b=>b.Id == id));
      return results.FirstOrDefault();
    }

    public async Task<UserDto> Add(UserDto entity)
    {
      var result = await _genericRepository.AddOrUpdate(_mapper.Map<User>(entity));
      return _mapper.Map<UserDto>(result);
    }

    public async Task<UserDto> Update(UserDto entity)
    {
      var result = await _genericRepository.AddOrUpdate(_mapper.Map<User>(entity));
      return _mapper.Map<UserDto>(result);
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
