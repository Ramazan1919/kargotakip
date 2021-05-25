using DataEntity;
using DataEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IBaseService<T> where T : IEntity
    {
        T Get(int id);
         T GetFilter(Expression<Func<T, bool>> filter, string include = "");

        List<T> GetAll();

        List<T> Search(Expression<Func<T, bool>> filter);

        Result Add(T entity);

        Result Update(T entity);

        Result Delete(int id);
    }
}
