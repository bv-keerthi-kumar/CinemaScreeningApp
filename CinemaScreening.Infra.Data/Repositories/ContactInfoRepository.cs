using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.Models;
using CinemaScreening.Domain.RepositoryInterfaces;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class ContactInfoRepository : RepositoryBase, IContactInfoRepository
    {
        public Task<ContactInfo> Create(ContactInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactInfo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContactInfo> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactInfo> Update(int id, ContactInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
