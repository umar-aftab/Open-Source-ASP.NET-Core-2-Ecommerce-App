using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        internal ContextEntities _context;
        internal DbSet<T> _dbset;
        public IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public T First(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Take(Expression<Func<T, bool>> filter = null, int take = 10, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
