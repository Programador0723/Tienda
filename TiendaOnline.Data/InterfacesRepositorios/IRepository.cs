using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace TiendaOnline.Data.InterfacesRepositorios
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Todo();
        T Get(int id);
        IEnumerable<T> GetTAll(
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T> > ordeBy = null,
            string includeProperty = null

            );
        T GetFirtOrDefault(

               Expression<Func<T, bool>> filtro = null,
            string includeProperty = null

            );
        void add(T entity);
        void Remove(int id);
        void Remove(T entity);
    }
}
