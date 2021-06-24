using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.RepositoryInterfaces
{
    public interface ISubscribeUnitOfWork
    {
        void SetUnitOfWork(IUnitOfWork uow);
    }
}
