using CinemaScreening.Application.Services;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.RepositoryInterfaces;
using CinemaScreening.Infra.Data.Helper;
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
            RegisterAutoMapper(services);
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
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

        /// <summary>
        /// The appsettings.json file is not getting loaded into the configuration for .net class library project.
        /// The json file can be loaded through configuration for Mvc/Web.api/console/wfp project only
        /// To make life eaiser have register connectionString through dependencyInjection.
        /// </summary>
        public static void RegisterConnectionString(string connectionString)
        {
            ConnectionHelper.ConnectionString = connectionString;
        }
    }
}
