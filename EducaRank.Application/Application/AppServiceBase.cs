using EducaRank.Application.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Objeto do tipo " + typeof(T).Name + " está nulo");
            _serviceBase.Create(entity);
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não pode ser zero");
            _serviceBase.Delete(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate", "Predicato não pode ser nulo");
            return _serviceBase.FindBy(predicate);
        }

        public T FindSingleBy(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate", "Predicato não pode ser nulo");
            return _serviceBase.FindSingleBy(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public T GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "O objeto não pode ser nulo");
            _serviceBase.Update(entity);
        }
    }
}
