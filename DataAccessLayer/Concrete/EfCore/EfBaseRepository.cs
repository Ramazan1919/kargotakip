using DataAccessLayer.Abstract;
using DataEntity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Concrete.EfCore
{
    public class EfBaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        private readonly StdContext _context;
        public EfBaseRepository(StdContext context)
        {
            _context = context;
        }

        public bool Add(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Added;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(TEntity entity)
        {
            var delentry = _context.Entry(entity);
            delentry.State = EntityState.Deleted;

            _context.SaveChanges();
            return true;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _context.Set<TEntity>().ToList() : _context.Set<TEntity>().Where(filter).ToList();
        }



        public bool Update(TEntity entity)
        {

            //var Updatedentry = _context.Attach(entity);
            var Updatedentry= _context.Entry(entity);
            Updatedentry.State = EntityState.Modified;

            _context.SaveChanges();

            return true;
        }
    }
}
