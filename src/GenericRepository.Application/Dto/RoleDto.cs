using System.Collections.Generic;

namespace GenericRepository.Application.Dto
{
  public class RoleDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<ThisUserDto> Users { get; set; }
    public IList<ThisApplicationDto> Applications { get; set; }

    public class ThisUserDto
    {

      public int Id { get; set; }

      public string Name { get; set; }

    }

    public class ThisApplicationDto
    {

      public int Id { get; set; }

      public string Name { get; set; }

    }
  }
}
