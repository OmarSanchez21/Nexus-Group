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
        Task<ServiceResult> GetAllDeleted();
        Task<ServiceResult> GetValue(int id);
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> Remove(int id);
        Task<ServiceResult> Recover(int id);

    }
}
