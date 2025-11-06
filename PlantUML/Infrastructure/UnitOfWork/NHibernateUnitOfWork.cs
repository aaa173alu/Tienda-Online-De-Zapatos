using ApplicationCore.Domain.Repositories;
using Infrastructure.NHibernate;
using NHibernate;

namespace Infrastructure.UnitOfWork;

public class NHibernateUnitOfWork : IUnitOfWork
{
    private readonly ISession _session;
    private ITransaction? _transaction;

    public NHibernateUnitOfWork()
    {
        _session = NHibernateHelper.OpenSession();
    }

    public ISession Session => _session;

    public void BeginTransaction() => _transaction = _session.BeginTransaction();

    public void Commit() 
    { 
        if (_transaction != null && _transaction.IsActive)
        {
            _transaction.Commit(); 
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public void Rollback() 
    { 
        if (_transaction != null && _transaction.IsActive)
        {
            _transaction.Rollback(); 
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public void SaveChanges()
    {
        // Solo hacer flush, NO commit aquí
        // El commit lo controla explícitamente quien inició la transacción
        _session.Flush();
    }
}
