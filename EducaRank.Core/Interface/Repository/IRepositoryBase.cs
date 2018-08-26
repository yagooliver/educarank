using System;
using System.Linq;
using System.Linq.Expressions;

namespace EducaRank.Core.Interface.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindSingleBy(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
