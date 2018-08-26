using System;
using System.Linq;
using System.Linq.Expressions;

namespace EducaRank.Application.Interface
{
    public interface IAppServiceBase<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T FindSingleBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
