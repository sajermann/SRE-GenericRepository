using System;
using System.Collections.Generic;

namespace GenericRepository.Domain
{
  public class Role
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<User> Users { get; set; }
    public IList<Application> Applications { get; set; }
  }
}
