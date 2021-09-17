using AutoMapper;
using GenericRepository.Application.Dto;
using GenericRepository.Application.Interfaces;
using GenericRepository.Data.Helpers;
using GenericRepository.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

      // TODO: Verificar se está async com o firstorDefaultr
    public async Task<ApplicationDto> GetById(int id)
    {

      var includes = new List<Expression<Func<Domain.Application, object>>>();
      Expression<Func<Domain.Application, object>> include = b => b.Roles;
      includes.Add(include);

      //Expression<Func<Domain.Application, Domain.Application>> select = b => new Domain.Application { Id = b.Id };
            
      var t = _genericRepository.Find(
        where: b => b.Id == id,
        includes: includes
        //selects: select
        )
        .FirstOrDefault<Domain.Application>();
      var results = _mapper.Map<ApplicationDto>(t);
      return results;
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
