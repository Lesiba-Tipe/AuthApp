using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Repository
{
    interface IGenericRepository<T> where T : class
    {
        Task<T> Insert(T entity);
        Task<T> FindById(string id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Delete(string id);
        Task CompleteAsync();       
    }
}
