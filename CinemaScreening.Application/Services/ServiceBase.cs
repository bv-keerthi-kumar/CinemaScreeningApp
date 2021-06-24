using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Application.Services
{
    /// <summary>
    /// A base class for all services to provide an implementation 
    /// </summary>
    public abstract class ServiceBase<T> where T : IRepository
    {
        protected T Repository { get; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; }

        protected ServiceBase(T repository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            Repository = repository;
            UnitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
