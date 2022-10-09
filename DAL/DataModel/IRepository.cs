using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataModel
{
    public interface IRepository<T> where T : class
    {
        T GetById(Func<T, bool> predicate);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity, T entity2);
        void Attach(T entity);

        public IQueryable<T> ListIncludes(params Expression<Func<T, object>>[] includes);
    }
}
