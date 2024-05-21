using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Dtos.User
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}