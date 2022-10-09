using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;

namespace DAL.DataModel
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MiniProjectTGDDContext _context;
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public UnitOfWork()
        {
            _context = new MiniProjectTGDDContext();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Repository<T> Repository<T>() where T : class
        {
            IRepository<T> repository = null;
            if (repositories.ContainsKey(typeof(T)))
            {
                repository = repositories[typeof(T)] as IRepository<T>;
            }
            else
            {
                repository = new Repository<T>(_context);
                repositories.Add(typeof(T), repository);
            }

            return (Repository<T>)repository;
        
    }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
