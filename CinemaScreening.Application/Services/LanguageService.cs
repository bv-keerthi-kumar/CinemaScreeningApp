using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Domain.Models;
using AutoMapper;

namespace CinemaScreening.Application.Services
{
    public class LanguageService : ServiceBase<ILanguageRepository>, ILanguageService
    {
        public LanguageService(ILanguageRepository languageRepository, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(languageRepository,unitOfWorkFactory,mapper)
        {
        }

        public async Task<LanguageDto> Create(LanguageDto entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Create(Mapper.Map<Language>(entity));
                uow.Commit();
                return Mapper.Map<LanguageDto>(result);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Delete(id);
                uow.Commit();
                return result;
            }
        }

        public async Task<IEnumerable<LanguageDto>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetAll();
                return Mapper.Map<IEnumerable<LanguageDto>>(result);
            }
        }

        public async Task<LanguageDto> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetById(id);
                return Mapper.Map<LanguageDto>(result);
            }
        }

        public async Task<LanguageDto> Update(int id, LanguageDto entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Update(id, Mapper.Map<Language>(entity));
                uow.Commit();
                return Mapper.Map<LanguageDto>(result);
            }
        }
    }
}
