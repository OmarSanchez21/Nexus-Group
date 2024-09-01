using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.AccessLevels
{
    public interface IAccessLevelsRepositories
    {
        Task<IEnumerable<M_AccessLevels>> GetAll();
        Task<M_AccessLevels> GetValue(string id);
    }
}
