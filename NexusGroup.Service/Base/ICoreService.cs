using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Base
{
    public interface ICoreService
    {
        Task<ServiceResult> GetAll();
        Task<ServiceResult> Get(int id);
        Task<ServiceResult> GetAllDeletd();
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> DeletePermantly(int id);
        Task<ServiceResult> Recover(int id);
    }
}
