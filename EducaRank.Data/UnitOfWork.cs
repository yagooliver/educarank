using EducaRank.Core.Interface;
using EducaRank.Data.Config;
using NHibernate;
using System;

namespace EducaRank.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISession Session { get; private set; }
        
        private ITransaction _transaction;

        public UnitOfWork()
        {
            var sessionFactory = new SessionFactory();

            if (Session == null)
            {
                Session = sessionFactory.CreateSessionFactory().OpenSession();
            }
        }

        public void BeginTransaction()
        {
            if (Session != null)
                _transaction = Session.BeginTransaction();
        }

        public void RollBack()
        {
            if (_transaction.IsActive)
                _transaction.Rollback();
        }

        public void Commit()
        {
            if (!_transaction.IsActive)
                throw new InvalidOperationException("Não há transação ativa.");

            _transaction.Commit();
        }

        public void Dispose()
        {
            if (Session.IsOpen)
                Session.Close();
        }
    }
}
