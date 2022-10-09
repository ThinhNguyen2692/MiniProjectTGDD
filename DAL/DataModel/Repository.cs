using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelProject.Models;

namespace DAL.DataModel
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MiniProjectTGDDContext _context;

        public Repository(MiniProjectTGDDContext _context)
        {
            this._context = _context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T entity2)
        {

            _context.Entry(entity).CurrentValues.SetValues(entity2);

        }

        public T GetById(Func<T, bool> predicate)
        {
            var entity = _context.Set<T>().Where(predicate).FirstOrDefault();
            if (entity == null) return null;
            return entity;
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public IQueryable<T> ListIncludes(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            return includes.Aggregate(query, (q, w) => q.Include(w));
        }
      

    }
}
