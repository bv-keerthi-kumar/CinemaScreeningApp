using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;

namespace CinemaScreening.Application.Services
{
    public class MovieService : ServiceBase<IMovieRepository>, IMovieService
    {
        public MovieService(IMovieRepository movieRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(movieRepository, unitOfWorkFactory)
        {
        }

        public Task<MovieDto> Create(MovieDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MovieDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDto> Update(int id, MovieDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
