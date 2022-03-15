using CinemaScreening.Infra.RepositoryInterfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CinemaScreening.Infra.Data.Repositories
{
    /// <summary>
    /// UnitOfWork is sealed class
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        public IDbConnection Connection { get; private set; }

        public IDbTransaction Transaction { get; private set; }

        private ISubscribeUnitOfWork[] Subscribers { get; set; }

        private bool _disposed = false;

        public UnitOfWork(string connectionString, ISubscribeUnitOfWork[] subscribers)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
            Subscribers = subscribers;

            SetSubscribersUow(this);
        }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
            finally
            {
                Transaction.Dispose();
                Transaction = Connection.BeginTransaction();
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                SetSubscribersUow(null);
                Transaction?.Dispose();
                Connection?.Dispose();

                Subscribers = null;
                Transaction = null;
                Connection = null;
                _disposed = true;
            }
        }

        private void SetSubscribersUow(UnitOfWork uow)
        {
            if(Subscribers == null)
            {
                return;
            }
            else
            {
                foreach(var subscriber in Subscribers)
                {
                    subscriber.SetUnitOfWork(uow);
                }
            }
        }
    }
}
