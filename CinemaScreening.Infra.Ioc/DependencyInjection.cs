using CinemaScreening.Application.Services;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.RepositoryInterfaces;
using CinemaScreening.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            //Application Layer
            RegisterServices(services);

            //Infra.Data layer
            RegisterRepositories(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMovieService, MovieService>();

        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
        }
    }
}
