using CinemaScreening.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.RepositoryInterfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>, IRepository
    {
        Task<List<Movie>> GetMovieById(int id);
    }
}
