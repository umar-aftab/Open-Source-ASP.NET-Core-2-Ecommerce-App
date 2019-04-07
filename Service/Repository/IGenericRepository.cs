using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        bool Any(Expression<Func<T, bool>> filter = null);
        int Count(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> All();
        //Task<IEnumerable<T>> AllAsync();
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null/*, string includeProperties = ""*/);
        //IEnumerable<T> Take(Expression<Func<T, bool>> filter = null, int take = 10, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T First(Expression<Func<T, bool>> filter);
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
        void MarkDeleted(T entity);

    }
}
