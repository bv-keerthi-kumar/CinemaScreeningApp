using System;
using System.Linq;
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
    public class MovieService : ServiceBase<IMovieRepository>, IMovieService
    {
        public MovieService(IMovieRepository movieRepository, IUnitOfWorkFactory unitOfWorkFactory,IMapper mapper) : base(movieRepository, unitOfWorkFactory, mapper)
        {
        }

        /// <summary>
        /// Mapped Manually for Movie and MovieDto entity
        /// </summary>
        public async Task<MovieDto> Create(MovieDto entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Create(GetMovie(entity));
                uow.Commit();
                return GetMovieDto(result);
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

        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var movies = await Repository.GetAll();                                        
                return Mapper.Map<IEnumerable<MovieDto>>(movies);
            }
        }

        public async Task<MovieDto> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var movie = (await Repository.GetMovieById(id).ConfigureAwait(false)).SingleOrDefault();
                var result = Mapper.Map<MovieDto>(movie);
                return result;
            }
        }

        public async Task<MovieDto> Update(int id, MovieDto entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Update(id, Mapper.Map<Movie>(entity));
                uow.Commit();
                return Mapper.Map<MovieDto>(result);
            }
        }

        /// <summary>
        /// Manual Map for Movie
        /// </summary>
        private Movie GetMovie(MovieDto movieDto)
        {
            return new Movie()
            {
                Title = movieDto.Title,
                Rating = movieDto.Rating,
                ReleaseDate = movieDto.ReleaseDate,
                Genre = new Genre()
                {
                    Id = movieDto.GenreDto.Id,
                    Name = movieDto.GenreDto.Name
                },
                Director = new Director()
                {
                    Id = movieDto.DirectorDto.Id,
                    FirstName = movieDto.DirectorDto.FirstName,
                    LastName = movieDto.DirectorDto.LastName
                },
                Language = new Language()
                {
                    Id = movieDto.LanguageDto.Id,
                    Name = movieDto.LanguageDto.Name
                }
            };
        }

        /// <summary>
        /// Manual Map for MovieDto
        /// </summary>
        private MovieDto GetMovieDto(Movie movie)
        {
            var movieDto = new MovieDto()
            {
                Id = movie.Id,
                Title = movie.Title,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                GenreDto = new GenreDto()
                {
                    Id = movie.Genre.Id,
                    Name = movie.Genre.Name
                },
                DirectorDto = new DirectorDto()
                {
                    Id = movie.Director.Id,
                    FirstName = movie.Director.FirstName,
                    LastName = movie.Director.LastName
                },
                LanguageDto = new LanguageDto()
                {
                    Id = movie.Language.Id,
                    Name = movie.Language.Name
                }
                /*
                MoviePromosDto = new List<MoviePromoDto>((IEnumerable<MoviePromoDto>)movie.MoviePromos)                                                                                                                                             
                MoviePromosDto = movie.MoviePromos.Select(x => new MoviePromoDto
                                    {
                                        Id = x.Id,                                        
                                        MovieDto = x.Movie,
                                        ImageUrl = x.ImageUrl,
                                        TeaserUrl = x.TeaserUrl,
                                        TrailerUrl = x.TrailerUrl
                                    })
                */
            };
            return movieDto;
        }
    }
}
