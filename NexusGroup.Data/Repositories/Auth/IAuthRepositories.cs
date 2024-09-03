using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Auth
{
    public interface IAuthRepositories
    {
        Task<LoginResult> Login(string username);
        Task<int> ChangePassword(int id, string password);
    }
}
