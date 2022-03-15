using CinemaScreening.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Infra.RepositoryInterfaces
{
    public interface ITheaterRepository : IGenericRepository<Theater>, IRepository
    {
    }
}
