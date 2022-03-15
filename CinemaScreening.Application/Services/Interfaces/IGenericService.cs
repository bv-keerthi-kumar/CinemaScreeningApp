using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaScreening.Application.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(int id, T entity);
        Task<int> Delete(int id);
    }
}
