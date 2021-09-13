using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GenericRepository.Data.Context;
using GenericRepository.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Data
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly GRContext _context;
    private DbSet<T> _entities;


    public GenericRepository(GRContext context)
    {
      _context = context;
      _entities = context.Set<T>();
    }

    public async Task<List<T>> Find(
      Expression<Func<T, bool>> where = null,
      //Expression<Func<T, object>>[] includes = null,
      //Expression<Func<T, object>> select = null,
      Expression<Func<T, object>> orderByDesc = null,
      Expression<Func<T, object>> orderByAsc = null,
      int pageNumber = 0,
      int itemsPerPage = 0
      )
    {
      List<T> results;
      IQueryable<T> query = _entities.AsNoTracking();
      if (where != null) query = query.Where(where);
      //if (includes != null) query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
      //if (select != null) query = query.Select(select);
      if (orderByDesc != null) query = query.OrderByDescending(orderByDesc);
      if (orderByAsc != null) query = query.OrderBy(orderByAsc);
      if (pageNumber > 0) query = query.Skip((pageNumber - 1) * itemsPerPage);
      if (itemsPerPage > 0) query = query.Take(itemsPerPage);
      results = await query.ToListAsync();
      return results;
    }

    public async Task<T> AddOrUpdate(T entity)
    {
      //Insert Funciona bem,
      //Update não funciona pois precisa arrumar um jeito de dar attach nos relacionamentos
            
      if (!_entities.Any(e => e == entity))
      {
        _entities.Attach(entity);
      }
      else
      {
        // _entities.Attach(entity); <== Esse attach deveria ser no relacionamento, do jeito que está, está errado
        _context.Update(entity);
      }
      await _context.SaveChangesAsync();
      return entity;
    }


  }
}