using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public Task<AddressDto> Create(AddressDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> Update(int id, AddressDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
