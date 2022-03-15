using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
