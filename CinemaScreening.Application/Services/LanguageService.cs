using CinemaScreening.Application.Services.Interfaces;
using CinemaScreening.Infra.Dtos;
using CinemaScreening.Infra.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Application.Services
{
    public class LanguageService : ServiceBase<ILanguageRepository>, ILanguageService
    {
        public LanguageService(ILanguageRepository languageRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(languageRepository,unitOfWorkFactory)
        {
        }

        public async Task<Language> Create(Language entity)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.Create(entity);
                uow.Commit();
                return result;
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

        public async Task<IEnumerable<Language>> GetAll()
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetAll();
                return result;
            }
        }

        public async Task<Language> GetById(int id)
        {
            using (var uow = UnitOfWorkFactory.StartNew(Repository))
            {
                var result = await Repository.GetById(id);
                return result;
            }
        }

        public async Task<Language> Update(int id, Language entity)
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
