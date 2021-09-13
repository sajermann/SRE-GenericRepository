using AutoMapper;
using GenericRepository.Application.Dto;
using GenericRepository.Domain;

namespace SajermannDashboard.Application.Helpers
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<User, UserDto>().ReverseMap();
      CreateMap<User, RoleDto.ThisUserDto>().ReverseMap();

      CreateMap<Role, RoleDto>().ReverseMap();
      CreateMap<Role, UserDto.ThisRole>().ReverseMap();
      CreateMap<Role, ApplicationDto.ThisRoleDto>().ReverseMap();

      CreateMap<GenericRepository.Domain.Application, ApplicationDto>().ReverseMap();
      CreateMap<GenericRepository.Domain.Application, RoleDto.ThisApplicationDto>().ReverseMap();
     
    }
  }
}
