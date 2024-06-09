using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Base
{
    public interface IService<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int id);
        Task<T> GetByName(string name);
        Task Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}
