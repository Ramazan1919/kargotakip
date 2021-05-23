using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataEntity;
using DataEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public abstract class BaseManager<T> : IBaseService<T> where T : class, IEntity
    {
        private IRepository<T> _repository;
        public BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public Result Add(T entity)
        {
            try
            {
                if (entity != null)
                {
                    var success = _repository.Add(entity);
                    if (success)
                    {
                        return Result.Success();
                    }
                }
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
            return Result.Error("Ekleme işlemi başarız");
        }

        public Result Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var entity = Get(id);
                    var success = _repository.Delete(entity);
                    if (success)
                    {
                        return Result.Success();
                    }
                }
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
            return Result.Error("Silme işlemi başarız");
        }

        public T Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _repository.Get(i => i.Id == id);
                }
            }
            catch (Exception ex)
            {
                //hata logla
            }
            return null;
        }

        public List<T> GetAll()
        {
            try
            {
                return _repository.GetList(null);
            }
            catch (Exception ex)
            {
                //hata logla
            }
            return new List<T>();
        }

        public List<T> Search(Expression<Func<T, bool>> filter)
        {
            try
            {
                return _repository.GetList(filter);
            }
            catch (Exception ex)
            {
                //hata logla
            }
            return new List<T>();
        }

        public Result Update(T entity)
        {
            try
            {
                if (entity != null)
                {
                    var success = _repository.Update(entity);
                    if (success)
                    {
                        return Result.Success();
                    }
                }
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
            return Result.Error("Gücnelleme işlemi başarız");
        }
    }
}
