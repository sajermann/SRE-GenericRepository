using System;
using System.Collections.Generic;

namespace GenericRepository.Domain
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Role> Roles { get; set; }
  }
}
