using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;

namespace CinemaScreening.Application.Services
{
    public class DirectorService : ServiceBase<IDirectorRepository>, IDirectorService
    {
        public DirectorService(IDirectorRepository directorRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(directorRepository, unitOfWorkFactory)
        {
        }

        public async Task<DirectorDto> Create(DirectorDto entity)
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

        public async Task<IEnumerable<DirectorDto>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                return await Repository.GetAll();
            }
        }

        public async Task<DirectorDto> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                return await Repository.GetById(id);
            }
        }

        public async Task<DirectorDto> Update(int id, DirectorDto entity)
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
