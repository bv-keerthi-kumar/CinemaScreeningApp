using CinemaScreening.Infra.RepositoryInterfaces;
using CinemaScreening.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public Task<Address> Create(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Update(int id, Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
