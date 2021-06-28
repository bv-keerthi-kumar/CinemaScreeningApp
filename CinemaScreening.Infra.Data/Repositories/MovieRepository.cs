using CinemaScreening.Domain.Models;
using CinemaScreening.Domain.RepositoryInterfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class MovieRepository : RepositoryBase, IMovieRepository
    {
        public async Task<Movie> Create(Movie entity)
        {
            var parameters = new DynamicParameters();
            //For Time being createdBy/modifiedBy is not passing any data, default null is passing till user login creation
            parameters = MapCommonParameters(parameters, entity);
            parameters.Add("@createdDate", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@createdBy", null, DbType.String, ParameterDirection.Input);

            parameters.Add("@newId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var query = Connection.QueryAsync<string>("AddMovie", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error creating movie", message);
            var newId = parameters.Get<int>("@newId");
            return (await GetMovieById(newId).ConfigureAwait(false)).SingleOrDefault();
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var query = Connection.QueryAsync<string>("DeleteMovie", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error deleting movie", message);
            return result;
        }


        /*
        /// <summary>
        /// Get all movies, return data only for one to one mapping
        /// </summary>
        public async Task<IEnumerable<Movie>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", null, DbType.Int32, ParameterDirection.Input);
            var query = QueryTask(parameters);
            return await query.ConfigureAwait(false);
        }

        /// <summary>
        /// Get movie by id, return data for one to one mapping 
        /// </summary>
        public async Task<Movie> GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            var query = QueryTask(parameters);
            return (await query.ConfigureAwait(false)).SingleOrDefault();
        }
        */

        /// <summary>
        /// QueryTask function returns all Movies, with one to one mapping object with Director, Genre, Language
        /// </summary>
        private Task<IEnumerable<Movie>> QueryTask(DynamicParameters parameters)
        {
            var queryTask = Connection.QueryAsync<Movie, Director, Genre, Language, Movie>("ReadMovie",
                                    (movie, director, genre, language) =>
                                    {
                                        movie.Director = director;
                                        movie.Genre = genre;
                                        movie.Language = language;
                                        return movie;
                                    },
                                    parameters,
                                    splitOn: "Id,Id,Id,Id",
                                    transaction: Transaction,
                                    commandType: CommandType.StoredProcedure);
            return queryTask;
        }

        public async Task<Movie> Update(int id, Movie entity)
        {
            var currentEntity = (await GetMovieById(id).ConfigureAwait(false)).SingleOrDefault();
            if (currentEntity == null)
            {
                throw new RepositoryEntityNotFoundException($"Could not find a movie with id {id}.");
            }

            currentEntity.ApplyChanges(entity);

            var parameters = new DynamicParameters();
            parameters = MapCommonParameters(parameters, currentEntity);
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var queryUpdate = Connection.QueryAsync<string>("UpdateMovie", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await queryUpdate.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error while updating the movie details", message);

            return (await GetMovieById(id).ConfigureAwait(false)).SingleOrDefault();
        }

        private DynamicParameters MapCommonParameters(DynamicParameters parameters, Movie entity)
        {
            //For Time being createdBy/modifiedBy is not passing any data, default null is passing till user login creation
            parameters.Add("@title", entity.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("@rating", entity?.Rating, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@releaseDate", entity?.ReleaseDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@directorId", entity.Director?.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@genreId", entity.Genre?.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@languageId", entity.Language?.Id, DbType.Int32, ParameterDirection.Input);

            parameters.Add("@modifiedDate", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@modifiedBy", null, DbType.String, ParameterDirection.Input);

            return parameters;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", null, DbType.Int32, ParameterDirection.Input);
            var myTask = Task.Run(() => QueryTaskForMovie(parameters));
            List<Movie> result = await myTask.ConfigureAwait(false);
            return result;
        }

        public async Task<List<Movie>> GetMovieById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            var myTask = Task.Run(() => QueryTaskForMovie(parameters));
            List<Movie> result = await myTask.ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// QueryTaskForMovie function returns all Movies, with one to many mapping with MoviePromo and   
        /// one to one mapping object with Director, Genre, Language
        /// </summary>
        /// <remarks>
        /// In the db, have 1 Father with ID = 1, and 3 Son with FatherId = 1.
        /// usually sql return query, which gives me an IEnumerable of 3 Father with each Father containing a Son.
        /// SELECT f.*, s.* FROM Father f INNER JOIN Son s ON f.Id = s.FatherId WHERE f.Id = 1       
        /// We want: a single Father object with the Sons property containing 3 Son object.
        /// To achive this we have to go with below approach, Distinct() keyword will make to achieve this for Query()
        /// </remarks>
        private List<Movie> QueryTaskForMovie(DynamicParameters parameters)
        {            
            var movieDictionary = new Dictionary<int, Movie>();
            var queryTask =  Connection.Query<Movie,MoviePromo,Director,Genre,Language,Movie>("ReadMovie",
                                    (movie, moviepromo, director, genre, language) =>
                                    {
                                        Movie movieEntry;

                                        if (!movieDictionary.TryGetValue(movie.Id, out movieEntry))
                                        {
                                            movieEntry = movie;
                                            movieEntry.MoviePromos = new List<MoviePromo>();
                                            movieDictionary.Add(movieEntry.Id, movieEntry);
                                        }
                                        if (moviepromo != null) { moviepromo.Movie = movie; }
                                        movieEntry.MoviePromos.Add(moviepromo);

                                        movieEntry.Director = director;
                                        movieEntry.Genre = genre;
                                        movieEntry.Language = language;
                                        return movieEntry;
                                    },
                                    parameters,
                                    splitOn: "Id,Id,Id,Id",
                                    transaction: Transaction,
                                    commandType: CommandType.StoredProcedure).Distinct().ToList();
            return  queryTask;
        }

        /// <summary>
        ///  No use of this GetById(), have implemented alternative Task<List<Movie>> GetMovieById(int id)
        /// </summary>
        public Task<Movie> GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
