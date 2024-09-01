using NexusGroup.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.AccessLevels
{
    public interface IAccessLevelsServices
    {
        Task<ServiceResult> GetValue(string id);
        Task<ServiceResult> GetAll();
    }
}
