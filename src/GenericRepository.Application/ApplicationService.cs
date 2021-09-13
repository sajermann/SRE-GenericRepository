using AutoMapper;
using GenericRepository.Application.Dto;
using GenericRepository.Application.Interfaces;
using GenericRepository.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Application
{
  public class ApplicationService : IApplicationService
  {
    private readonly IGenericRepository<Domain.Application> _genericRepository;
    private readonly IMapper _mapper;

    public ApplicationService(IGenericRepository<Domain.Application> genericRepository, IMapper mapper)
    {
      _genericRepository = genericRepository;
      _mapper = mapper;
    }

    public async Task<List<ApplicationDto>> GetAll()
    {
      var results = _mapper.Map<List<ApplicationDto>>(await _genericRepository.Find());
      return results;
    }

    public async Task<ApplicationDto> GetById(int id)
    {
      var results = _mapper.Map<List<ApplicationDto>>(await _genericRepository.Find(where: b=>b.Id == id));
      return results.FirstOrDefault();
    }

    public async Task<ApplicationDto> Add(ApplicationDto entity)
    {
      var result = await _genericRepository.AddOrUpdate(_mapper.Map<Domain.Application>(entity));
      return _mapper.Map<ApplicationDto>(result);
    }

    public async Task<ApplicationDto> Update(ApplicationDto entity)
    {
      var result = await _genericRepository.AddOrUpdate(_mapper.Map<Domain.Application>(entity));
      return _mapper.Map<ApplicationDto>(result);
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
