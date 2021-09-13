using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository.Data.Interfaces
{
  public interface IGenericRepository<T> where T : class
  {
    Task<List<T>> Find(
      Expression<Func<T, bool>> where = null,
      //Expression<Func<T, object>>[] includes = null,
      //Expression<Func<T, T>> select = null,
      Expression<Func<T, object>> orderByDesc = null,
      Expression<Func<T, object>> orderByAsc = null,
      int pageNumber = 0,
      int itemsPerPage = 0
      );

    Task<T> AddOrUpdate(T entity);
  }
}
