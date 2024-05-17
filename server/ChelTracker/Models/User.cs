using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ChelTracker.Models
{
    public class User : IdentityUser
    {
        public List<Opponent> Opponents { get; set; } = new List<Opponent>();

        public List<Game> Games { get; set; } = new List<Game>();
    }
}