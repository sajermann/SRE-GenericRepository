using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Data.Helpers
{
  public static class ExtensionOperation
  {
    public static T FirstOrDefault<T>(this Task<List<T>> results)
    {
      return results.Result.FirstOrDefault();
    }
  }
}
