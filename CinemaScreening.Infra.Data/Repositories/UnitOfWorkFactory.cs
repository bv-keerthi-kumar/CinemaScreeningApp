using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CinemaScreening.Infra.Data.Helper;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {      
        public IUnitOfWork StartNew(params ISubscribeUnitOfWork[] subscribers)
        {            
            return new UnitOfWork(ConnectionHelper.ConnectionString, subscribers);
        }
    }
}
