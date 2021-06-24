using CinemaScreening.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Domain.RepositoryInterfaces
{
    public interface IMovieRepository : IGenericRepository<MovieDto>, IRepository
    {
    }
}
