using CinemaScreening.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.RepositoryInterfaces
{
    public interface IMovieShowRepository : IGenericRepository<MovieShow>, IRepository
    {
    }
}
