using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TiendaOnline.Data.InterfacesRepositorios;

namespace TiendaOnline.Data.ClasesRepositorios
{
    public class Repositorio<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
       internal DbSet<T> _Db;
        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            this._Db = _context.Set<T>();
        }
        public void add(T entity)
        {
            _Db.Add(entity);
        }

     

        public T Get(int id)
        {
            return _Db.Find(id);
        }

        public T GetFirtOrDefault(Expression<Func<T, bool>> filtro = null, string includeProperty = null)
        {
            IQueryable<T> query = _Db;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (includeProperty != null)
            {
                foreach (var IncludeProperties in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(IncludeProperties);
                }

            }
            
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetTAll(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> ordeBy = null, string includeProperty = null)
        {
            IQueryable<T> query = _Db;
            if (filtro != null) 
            {
                query = query.Where(filtro);
            }
            if (includeProperty != null) {
                foreach (var IncludeProperties in includeProperty.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query.Include(IncludeProperties);
                }
                
            }
            if (ordeBy != null) 
            {
                return ordeBy(query).ToList();
            
            }
            return query.ToList();
        }

        public void Remove(int id)
        {
            var eliminar = _Db.Find(id);
            _Db.Remove(eliminar);
        }

        public void Remove(T entity)
        {
            _Db.Remove(entity);
        }

        public IEnumerable<T> Todo()
        {
              return _Db.ToList();
          
        }
    }
}
