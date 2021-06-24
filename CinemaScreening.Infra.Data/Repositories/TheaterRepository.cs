using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.Data.Repositories
{
    public class TheaterRepository : RepositoryBase, ITheaterRepository
    {
        public Task<TheaterDto> Create(TheaterDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TheaterDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TheaterDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TheaterDto> Update(int id, TheaterDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
