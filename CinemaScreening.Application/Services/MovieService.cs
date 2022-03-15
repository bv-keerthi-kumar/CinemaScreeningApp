using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Infra.Dtos;
using CinemaScreening.Infra.RepositoryInterfaces;

namespace CinemaScreening.Application.Services
{
    public class MovieService : ServiceBase<IMovieRepository>, IMovieService
    {
        public MovieService(IMovieRepository movieRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(movieRepository, unitOfWorkFactory)
        {
        }

        /// <summary>
        /// Mapped Manually for Movie and Movie entity
        /// </summary>
        public async Task<Movie> Create(Movie entity)
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

        public async Task<IEnumerable<Movie>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var movies = await Repository.GetAll();                                        
                return movies;
            }
        }

        public async Task<Movie> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var movie = (await Repository.GetMovieById(id).ConfigureAwait(false)).SingleOrDefault();               
                return movie;
            }
        }

        public async Task<Movie> Update(int id, Movie entity)
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
