using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;

namespace CinemaScreening.Application.Services
{
    public class GenreService : ServiceBase<IGenreRepository>, IGenreService
    {
        public GenreService(IGenreRepository genreRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(genreRepository, unitOfWorkFactory)
        {
        }

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
