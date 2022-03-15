using CinemaScreening.Application.Utils.Helper;
using CinemaScreening.Infra.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
