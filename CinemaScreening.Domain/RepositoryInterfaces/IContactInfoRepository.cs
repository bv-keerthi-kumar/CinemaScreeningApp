using CinemaScreening.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Domain.RepositoryInterfaces
{
    public interface IContactInfoRepository : IGenericRepository<ContactInfo>, IRepository
    {
    }
}
