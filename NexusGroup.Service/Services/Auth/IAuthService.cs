using NexusGroup.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResult> Login(string username, string password);
    }
}
