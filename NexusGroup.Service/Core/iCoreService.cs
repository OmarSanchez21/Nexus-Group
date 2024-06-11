using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Core
{
    public interface iCoreService<T> where T : class
    {
        Task<ServiceResult>GetAll();
        Task<ServiceResult> GetValue(int id);
        Task<ServiceResult> Save(T obj);
        Task<ServiceResult> Update(T obj);
        Task<ServiceResult> Delete(int id);
    }
}
