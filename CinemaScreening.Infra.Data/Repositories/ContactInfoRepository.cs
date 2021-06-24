using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class ContactInfoRepository : RepositoryBase, IContactInfoRepository
    {
        public Task<ContactInfoDto> Create(ContactInfoDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactInfoDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContactInfoDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactInfoDto> Update(int id, ContactInfoDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
