using CinemaScreening.Infra.RepositoryInterfaces;
using CinemaScreening.Infra.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class GenreRepository : RepositoryBase, IGenreRepository
    {
        public async Task<Genre> Create(Genre entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);

            parameters.Add("@newId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var query = Connection.QueryAsync<string>("AddGenre", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error creating Genre", message);
            var newId = parameters.Get<int>("@newId");
            return await GetById(newId).ConfigureAwait(false);
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var query = Connection.QueryAsync<string>("DeleteGenre", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error deleting Genre", message);
            return result;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", null, DbType.Int32, ParameterDirection.Input);
            var query = Connection.QueryAsync<Genre>("ReadGenre", parameters, Transaction, commandType: CommandType.StoredProcedure);
            return await query.ConfigureAwait(false);
        }

        public async Task<Genre> GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            var query = Connection.QueryAsync<Genre>("ReadGenre", parameters, Transaction, commandType: CommandType.StoredProcedure);
            return (await query.ConfigureAwait(false)).SingleOrDefault();
        }

        public async Task<Genre> Update(int id, Genre entity)
        {
            var currentEntity = await GetById(id).ConfigureAwait(false);
            if (currentEntity == null)
            {
                throw new RepositoryEntityNotFoundException($"Could not find a Genre with id {id}.");
            }

            currentEntity.ApplyChanges(entity);
            var parameters = GetUpdateParameters(id, currentEntity);

            var queryUpdate = Connection.QueryAsync<string>("UpdateGenre", parameters, Transaction, commandType: CommandType.StoredProcedure);
            await queryUpdate.ConfigureAwait(false);

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error while updating the Genre details");

            return await GetById(id).ConfigureAwait(false);
        }

        private static DynamicParameters GetUpdateParameters(int id, Genre changes)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@name", changes.Name, DbType.String, ParameterDirection.Input);

            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return parameters;
        }
    }
}
