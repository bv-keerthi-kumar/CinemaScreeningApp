using System;
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
    public class DirectorService : ServiceBase<IDirectorRepository>, IDirectorService
    {
        public DirectorService(IDirectorRepository directorRepository, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(directorRepository, unitOfWorkFactory, mapper)
        {
        }

        public async Task<DirectorDto> Create(DirectorDto entity)
        {
            using(var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Create(Mapper.Map<Director>(entity));
                uow.Commit();
                return Mapper.Map<DirectorDto>(result);
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
                var result = await Repository.GetAll();
                return Mapper.Map<IEnumerable<DirectorDto>>(result);
            }
        }

        public async Task<DirectorDto> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetById(id);
                return Mapper.Map<DirectorDto>(result);
            }
        }

        public async Task<DirectorDto> Update(int id, DirectorDto entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Update(id, Mapper.Map<Director>(entity));
                uow.Commit();
                return Mapper.Map<DirectorDto>(result);
            }
        }
    }
}
