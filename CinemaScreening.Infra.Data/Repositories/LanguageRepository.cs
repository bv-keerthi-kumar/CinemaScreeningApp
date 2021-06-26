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
    public class LanguageRepository : RepositoryBase, ILanguageRepository
    {
        public async Task<Language> Create(Language entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@language", entity.Name, DbType.String, ParameterDirection.Input);

            parameters.Add("@newId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var query = Connection.QueryAsync<string>("AddLanguage", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error creating Language", message);
            var newId = parameters.Get<int>("@newId");
            return await GetById(newId).ConfigureAwait(false);
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var query = Connection.QueryAsync<string>("DeleteLanguage", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error deleting Language", message);
            return result;
        }

        public async Task<IEnumerable<Language>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", null, DbType.Int32, ParameterDirection.Input);
            var query = Connection.QueryAsync<Language>("ReadLanguage", parameters, Transaction, commandType: CommandType.StoredProcedure);
            return await query.ConfigureAwait(false);
        }

        public async Task<Language> GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            var query = Connection.QueryAsync<Language>("ReadLanguage", parameters, Transaction, commandType: CommandType.StoredProcedure);
            return (await query.ConfigureAwait(false)).SingleOrDefault();
        }

        public async Task<Language> Update(int id, Language entity)
        {
            var currentEntity = await GetById(id).ConfigureAwait(false);
            if (currentEntity == null)
            {
                throw new RepositoryEntityNotFoundException($"Could not find a Language with id {id}.");
            }

            currentEntity.ApplyChanges(entity);
            var parameters = GetUpdateParameters(id, currentEntity);

            var queryUpdate = Connection.QueryAsync<string>("UpdateLanguage", parameters, Transaction, commandType: CommandType.StoredProcedure);
            await queryUpdate.ConfigureAwait(false);

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error while updating the Language details");

            return await GetById(id).ConfigureAwait(false);
        }

        private static DynamicParameters GetUpdateParameters(int id, Language changes)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@language", changes.Name, DbType.String, ParameterDirection.Input);

            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return parameters;
        }
    }
}
