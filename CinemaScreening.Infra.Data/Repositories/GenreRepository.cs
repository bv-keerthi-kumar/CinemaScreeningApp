using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class GenreRepository : RepositoryBase, IGenreRepository
    {
        public Task<GenreDto> Create(GenreDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenreDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GenreDto> Update(int id, GenreDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
