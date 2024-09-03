using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class AuthDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class ChangePasswordDTO
    {
        public int Id { get; set; }
        public string newPassword { get; set; }
    }
}
