using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;
using CinemaScreening.Domain.Models;
using AutoMapper;

namespace CinemaScreening.Application.Services
{
    public class GenreService : ServiceBase<IGenreRepository>, IGenreService
    {
        public GenreService(IGenreRepository genreRepository, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(genreRepository, unitOfWorkFactory, mapper)
        {
        }

        public async Task<GenreDto> Create(GenreDto entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Create(Mapper.Map<Genre>(entity));
                uow.Commit();
                return Mapper.Map<GenreDto>(result);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Delete(id);
                uow.Commit();
                return result;
            }
        }

        public async Task<IEnumerable<GenreDto>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetAll();
                return Mapper.Map<IEnumerable<GenreDto>>(result);
            }
        }

        public async Task<GenreDto> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetById(id);
                return Mapper.Map<GenreDto>(result);
            }
        }

        public async Task<GenreDto> Update(int id, GenreDto entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Update(id, Mapper.Map<Genre>(entity));
                uow.Commit();
                return Mapper.Map<GenreDto>(result);
            }
        }
    }
}
