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
            return await GetById(newId).ConfigureAwait(false);
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

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", null, DbType.Int32, ParameterDirection.Input);
            var query = QueryTask(parameters);
            return await query.ConfigureAwait(false);
        }

        public async Task<Movie> GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            var query = QueryTask(parameters);
            return (await query.ConfigureAwait(false)).SingleOrDefault();
        }

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
            var currentEntity = await GetById(id).ConfigureAwait(false);
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
            if (result == 0) throw new RepositoryException("Error while updating the movie details",message);

            return await GetById(id).ConfigureAwait(false);
        }

        private  DynamicParameters MapCommonParameters(DynamicParameters parameters, Movie entity)
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
    }
}
