using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Dtos.User
{
    public class NewUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}