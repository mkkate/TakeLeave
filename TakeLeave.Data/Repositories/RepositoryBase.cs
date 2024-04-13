using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TakeLeaveDbContext DbContext { get; set; }

        public RepositoryBase(TakeLeaveDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Insert(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
