using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChelTracker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<Opponent> Opponents { get; set; } = new List<Opponent>();

        public List<Game> Games { get; set; } = new List<Game>();
    }
}