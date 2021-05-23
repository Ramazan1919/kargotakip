using DataEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Get(Expression<Func<T, bool>> filter = null);
        
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        bool Add(T entity);

        bool Delete(T entity);

        bool Update(T entity);
    }
}
