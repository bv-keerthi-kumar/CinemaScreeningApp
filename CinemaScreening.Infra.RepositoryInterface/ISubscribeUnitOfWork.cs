using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.RepositoryInterfaces
{
    public interface ISubscribeUnitOfWork
    {
        void SetUnitOfWork(IUnitOfWork uow);
    }
}
