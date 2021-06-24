using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class MovieRepository : RepositoryBase, IMovieRepository
    {
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
