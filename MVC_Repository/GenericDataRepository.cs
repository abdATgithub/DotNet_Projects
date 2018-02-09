using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Generic_Repository
{
    public class GenericDataRepository<TEntity, TContext> : IGenericRepository<TEntity>, IDisposable
        where TEntity : class
        where TContext : DbContext, new()
    {
        private TContext _context;

        public GenericDataRepository()
        {
            _context = new TContext();
        }

        public GenericDataRepository(TContext Context)
        {
            this._context = Context;
        }
        public virtual void Add(params TEntity[] items)
        {
            using (var context = _context)
            {
                foreach (TEntity item in items)
                {
                    context.Entry(item).State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;
            using (var context = _context)
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                if (navigationProperties != null)
                {
                    //Apply eager loading
                    foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);
                }
                list = dbQuery
                    .AsNoTracking()
                    .ToList<TEntity>();
            }
            return list;
        }

        public virtual IList<TEntity> GetList(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;
            using (var context = _context)
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                if (navigationProperties != null)
                {
                    //Apply eager loading
                    foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);
                }
                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<TEntity>();
            }
            return list;
        }

        public virtual TEntity GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity item = null;
            using (var context = _context)
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                if (navigationProperties != null)
                {
                    //Apply eager loading
                    foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);
                }
                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public virtual void Remove(params TEntity[] items)
        {
            using (var context = _context)
            {
                foreach (TEntity item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public virtual void Update(params TEntity[] items)
        {
            using (var context = _context)
            {
                foreach (TEntity item in items)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
    }
}
