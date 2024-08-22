using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.BaseData
{
    public interface BaseRepositories<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllDeleted();
        Task<T> GetValue(int id);
        Task<int> Add(T entity);
        Task<int> Edit(T entity);
        Task<int> Delete(int id);
        Task<int> Recover(int id);
        Task<int> DeletePermantly(int id);
    }
}

