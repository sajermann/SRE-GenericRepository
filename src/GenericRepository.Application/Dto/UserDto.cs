using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Dto
{
  public class UserDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<ThisRole> Roles { get; set; }

    public class ThisRole {

      public int Id { get; set; }

    }
  }
}
