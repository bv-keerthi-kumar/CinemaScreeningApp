using CinemaScreening.Domain.Models;
using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class TheaterRepository : RepositoryBase, ITheaterRepository
    {
        public Task<Theater> Create(Theater entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Theater>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Theater> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Theater> Update(int id, Theater entity)
        {
            throw new NotImplementedException();
        }
    }
}
