using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;
using NHibernate;
using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace EducaRank.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private UnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Create(T entity)
        {
            if (!Session.IsConnected)
                throw new InvalidOperationException("Erro ao conectar a sessão");
            Session.Save(entity);
        }

        public void Delete(int id)
        {
            if (!Session.IsConnected)
                throw new InvalidOperationException("Erro ao conectar a sessão");
            Session.Delete(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            if (!Session.IsConnected)
                throw new InvalidOperationException("Erro ao conectar a sessão");

            return GetAll().Where(predicate).AsQueryable();

        }

        public T FindSingleBy(Expression<Func<T, bool>> predicate)
        {
            if (!Session.IsConnected)
                throw new InvalidOperationException("Erro ao conectar a sessão");

            return GetAll().Where(predicate).Single();
        }

        public IQueryable<T> GetAll()
        {
            if (!Session.IsConnected)
                throw new InvalidOperationException("Erro ao conectar a sessão");

            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            if (!Session.IsConnected)
                throw new InvalidOperationException("Erro ao conectar a sessão");
            return Session.Get<T>(id);
        }

        public void RollBack()
        {
            _unitOfWork.RollBack();
        }

        public void Update(T entity)
        {
            if (!Session.IsConnected)
                throw new InvalidOperationException("Erro ao conectar a sessão");
            Session.Update(entity);
        }
    }
}
