using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity;

namespace Service
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        internal ContextEntities _context;
        internal DbSet<T> _dbset;
        //internal Guid _userId;

        public Repository()
        {
            _dbset = _context.Set<T>();
        }

        public Repository(ContextEntities context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        //public Repository(ContextEntities context,Guid user)
        //{
        //    _context = context;
        //    _userId = user;
        //    _dbset = _context.Set<T>();
        //}


        public IEnumerable<T> All()
        {
            return _dbset;
        }

        //public virtual async Task<IEnumerable<T>> AllAsync()
        //{
        //    return await _dbset.ToListAsync<T>();
        //}

        public virtual bool Any(Expression<Func<T, bool>> filter = null)
        {
            return _dbset.Any(filter);
        }

        public virtual int Count(Expression<Func<T, bool>> filter = null)
        {
            return _dbset.Count(filter);
        }

        public virtual IQueryable<T> AsQueryable()
        {
            var query = _dbset.AsQueryable();
            return query;
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }

        public void Delete(object id)
        {
            var d = _dbset.Find(id);
            _dbset.Remove(d);
        }

        public T First(Expression<Func<T, bool>> filter)
        {
            return _dbset.First(filter);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null/*, string includeProperties = ""*/)
        {
            IQueryable<T> query = _dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if(orderBy != null)
            {
                query = orderBy(query);
            }
            return query;
        }

        public T GetById(object id)
        {
            return _dbset.Find(id);
        }

        public virtual void Insert(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void MarkDeleted(T entity)
        {
            ((IFlagged)entity).Flagged = true;
            this.Update(entity);
        }

        //public IEnumerable<T> Take(Expression<Func<T, bool>> filter = null, int take = 10, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity);
        }
    }
}
