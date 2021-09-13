using System.Collections.Generic;

namespace GenericRepository.Application.Dto
{
  public class ApplicationDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<ThisRoleDto> Roles { get; set; }


    public class ThisRoleDto
    {

      public int Id { get; set; }

      public string Name { get; set; }

    }

  }
}
