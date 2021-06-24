using CinemaScreening.Domain.Dtos;
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
    public class DirectorRepository : RepositoryBase, IDirectorRepository
    {
        public  async Task<DirectorDto> Create(DirectorDto entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@firstName", entity.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("@lastName", entity.LastName, DbType.String, ParameterDirection.Input);

            parameters.Add("@newId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var query = Connection.QueryAsync<string>("AddDirector", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if(result == 0) throw new RepositoryException("Error creating director", message);
            var newId = parameters.Get<int>("@newId");
            return await GetById(newId).ConfigureAwait(false);
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var query = Connection.QueryAsync<string>("DeleteDirector", parameters, Transaction, commandType: CommandType.StoredProcedure);
            var message = (await query.ConfigureAwait(false)).ToArray();

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error deleting director", message);
            return result;
        }

        public async Task<IEnumerable<DirectorDto>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", null, DbType.Int32, ParameterDirection.Input);
            var query = Connection.QueryAsync<DirectorDto>("ReadDirector", parameters , Transaction, commandType: CommandType.StoredProcedure);
            return await query.ConfigureAwait(false);
        }

        public async Task<DirectorDto> GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            var query = Connection.QueryAsync<DirectorDto>("ReadDirector", parameters, Transaction, commandType: CommandType.StoredProcedure);
            return (await query.ConfigureAwait(false)).SingleOrDefault();
        }

        public async Task<DirectorDto> Update(int id, DirectorDto entity)
        {
            var currentEntity = await GetById(id).ConfigureAwait(false);
            if(currentEntity == null)
            {
                throw new RepositoryEntityNotFoundException($"Could not find a director with id {id}.");
            }

            currentEntity.ApplyChanges(entity);
            var parameters = GetUpdateParameters(id, currentEntity);

            var queryUpdate = Connection.QueryAsync<string>("UpdateDirector", parameters, Transaction, commandType: CommandType.StoredProcedure);
            await queryUpdate.ConfigureAwait(false);

            int result = parameters.Get<int>("@result");
            if (result == 0) throw new RepositoryException("Error while updating the director details");
          
            return await GetById(id).ConfigureAwait(false);
        }

        private static DynamicParameters GetUpdateParameters(int id, DirectorDto changes)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@firstName", changes.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("@lastName", changes.LastName, DbType.String, ParameterDirection.Input);

            parameters.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return parameters;
        }
    }
}
