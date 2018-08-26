using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EducaRank.Core.Service
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Create(T entity)
        {
            try
            {
                _repositoryBase.BeginTransaction();
                _repositoryBase.Create(entity);
                _repositoryBase.Commit();
            }catch(Exception e)
            {
                _repositoryBase.RollBack();
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repositoryBase.BeginTransaction();
                _repositoryBase.Delete(id);
                _repositoryBase.Commit();
            }
            catch (Exception e)
            {
                _repositoryBase.RollBack();
                throw e;
            }
        }

        public T GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public void Update(T entity)
        {
            try
            {
                _repositoryBase.BeginTransaction();
                _repositoryBase.Update(entity);
                _repositoryBase.Commit();
            }
            catch (Exception e)
            {
                _repositoryBase.RollBack();
                throw e;
            }
        }

        public IQueryable<T> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repositoryBase.FindBy(predicate);
        }

        public T FindSingleBy(Expression<Func<T, bool>> predicate)
        {
            return _repositoryBase.FindSingleBy(predicate);
        }
    }
}
