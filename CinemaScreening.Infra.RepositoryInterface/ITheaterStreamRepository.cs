using CinemaScreening.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.RepositoryInterfaces
{
    public interface ITheaterStreamRepository : IGenericRepository<TheaterStream>, IRepository
    {
    }
}
