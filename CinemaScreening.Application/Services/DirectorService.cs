using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Infra.Dtos;
using CinemaScreening.Infra.RepositoryInterfaces;

namespace CinemaScreening.Application.Services
{
    public class DirectorService : ServiceBase<IDirectorRepository>, IDirectorService
    {
        public DirectorService(IDirectorRepository directorRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(directorRepository, unitOfWorkFactory)
        {
        }

        public async Task<Director> Create(Director entity)
        {
            using(var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Create(entity);
                uow.Commit();
                return result;
            }
        }

        public  async Task<int> Delete(int id)
        {
            using(var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Delete(id);
                uow.Commit();
                return result;
            }
        }

        public async Task<IEnumerable<Director>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetAll();
                return result;
            }
        }

        public async Task<Director> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetById(id);
                return result;
            }
        }

        public async Task<Director> Update(int id, Director entity)
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
