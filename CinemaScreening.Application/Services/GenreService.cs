using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Infra.Dtos;
using CinemaScreening.Infra.RepositoryInterfaces;

namespace CinemaScreening.Application.Services
{
    public class GenreService : ServiceBase<IGenreRepository>, IGenreService
    {
        public GenreService(IGenreRepository genreRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(genreRepository, unitOfWorkFactory)
        {
        }

        public async Task<Genre> Create(Genre entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Create(entity);
                uow.Commit();
                return result;
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

        public async Task<IEnumerable<Genre>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetAll();
                return result;
            }
        }

        public async Task<Genre> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetById(id);
                return result;
            }
        }

        public async Task<Genre> Update(int id, Genre entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Update(id, entity);
                uow.Commit();
                return result;
            }
        }
    }
}
