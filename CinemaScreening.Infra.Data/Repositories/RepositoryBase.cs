using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CinemaScreening.Infra.Data.Repositories
{
    public abstract class RepositoryBase : IRepository
    {
        private IUnitOfWork UnitOfWork { get; set; }

        protected IDbTransaction Transaction => ((UnitOfWork)(UnitOfWork)).Transaction;

        protected IDbConnection Connection => ((UnitOfWork)(UnitOfWork)).Connection;

        public void SetUnitOfWork(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
    }
}
